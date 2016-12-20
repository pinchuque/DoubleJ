using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.Models;
using DoubleJ.Oms.Model.ViewModels.Internal;
using DoubleJ.Oms.Service.Interfaces;
using DoubleJ.Oms.Service.Services;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.Ajax.Utilities;
using MuscovyTechnology.Mvc.Notification;


namespace DoubleJ.Oms.Web.Areas.Internal.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerLocationRepository _customerLocationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogoTypeRepository _logoTypeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICustomerProductDataRepository _customerProductDataRepository;

        private readonly IProductRepository _productRepository;
        private readonly ICaseSizeRepository _caseSizeRepository;

        public CustomerController(ICustomerRepository customerRepository,
            ICustomerLocationRepository customerLocationRepository,
            ILogoTypeRepository logoTypeRepository,
            IUserRepository userRepository,
            ICustomerProductDataRepository customerProductDataRepository,
            IProductRepository productRepository,
            ICaseSizeRepository caseSizeRepository)
        {
            _customerRepository = customerRepository;
            _customerLocationRepository = customerLocationRepository;
            _logoTypeRepository = logoTypeRepository;
            _userRepository = userRepository;
            _customerProductDataRepository = customerProductDataRepository;
            _productRepository = productRepository;
            _caseSizeRepository = caseSizeRepository;
        }

        public CustomerSearchViewModel CustomerSearchData
        {
            get { return SessionService.Get().CustomerSearchViewModel; }
            set { SessionService.Get().CustomerSearchViewModel = value; }
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(CustomerSearchData);
        }

        [HttpPost]
        public ActionResult Index(CustomerSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.HasSessionCriteria = true;
                CustomerSearchData = model;
            }
            return View(model);
        }

        public ActionResult Reset()
        {
            CustomerSearchData = new CustomerSearchViewModel();
            return RedirectToAction("Index");
        }

        public ActionResult SearchResultGridRead([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_customerRepository.Search(CustomerSearchData).ToDataSourceResult(request));
        }

        public ActionResult UpdateCustomer( //string update, string save, string cancel, string remove, CustomerLocationViewModel model, string cancelCustomer, 
            string updateCustomer, CustomerViewModel customerModel)
        {
            FillLookups();

            if (!ModelState.IsValid) return View("Edit", SessionService.Get().CustomerViewModel);
            if (string.IsNullOrEmpty(updateCustomer)) return View("Edit");

            var customer = _customerRepository.Get(customerModel.Id);
            customer.BestBeforeDays = customerModel.BestBeforeDays;
            customer.LogoTypeId = (OmsLogoType) Enum.Parse(typeof (OmsLogoType), customerModel.UseLogoOnLabels.ToString());
            customer.Name = customerModel.CustomerName;
            customer.PONumber = customerModel.CustomerPo;
            customer.IsArchived = customerModel.IsArchive;
            customer.DistributedBy = customerModel.LabelDistributedBy;
            customer.BoxLabel = customerModel.BoxLabel;
            customer.TrayLabel = customerModel.TrayLabel;
            customer.BagLabel = customerModel.BagLabel;
            customer.CustomerTypeId = customerModel.CustomerType;

            customer.User.FirstName = customerModel.OrderContactFirstName;
            customer.User.LastName = customerModel.OrderContactLastName;
            customer.User.Email = customerModel.OrderContactEmail;
            customer.User.Phone = customerModel.OrderContactPhone;
            customer.User.Password = customerModel.PortalPassword;

            bool isValidPicture;
            string pictureName = GetLabelPath(customer.CustomerTypeId == OmsCustomerType.Custom, customerModel.CustomerLogoFileName, customer.Id, out isValidPicture);

            if (!isValidPicture)
            {
                ModelState.AddModelError(string.Empty, pictureName);
                return UpdateView(customerModel.Id);
            }

            customer.LogoFileName = pictureName;

            _customerRepository.Update(customer);
            _customerRepository.Save();

            this.ShowNotification(NotificationType.Success, "Customer Updated");
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCustomerLocation(CustomerLocationViewModel model, CustomerLocationAction submit)
        {
            switch (submit)
            {
                case CustomerLocationAction.Add:
                    if (ModelState.IsValid && model.IsValid())
                    {
                        var location = model.ToCustomerLocation();

                        var customer = _customerRepository.Get(model.CustomerId);
                        customer.CustomerLocation.Add(location);

                        _customerRepository.Save();

                        return Json(new {Success = true}, JsonRequestBehavior.AllowGet);
                    }
                    foreach (var pair in model.Validate())
                    {
                        ModelState.AddModelError(pair.Key, pair.Value);
                    }
                    break;

                case CustomerLocationAction.Update:
                    if (ModelState.IsValid && model.IsValid())
                    {
                        var location = _customerLocationRepository.Get(model.LocationId);
                        location = model.ToCustomerLocation(location);

                        _customerLocationRepository.Update(location);
                        _customerLocationRepository.Save();

                        return Json(new {Success = true}, JsonRequestBehavior.AllowGet);
                    }
                    foreach (var pair in model.Validate())
                    {
                        ModelState.AddModelError(pair.Key, pair.Value);
                    }
                    break;

                case CustomerLocationAction.Remove:
                    try
                    {
                        var customerLocation = _customerLocationRepository.Get(model.LocationId);
                        _customerLocationRepository.Remove(customerLocation);
                        _customerLocationRepository.Save();

                        return Json(new {Success = true}, JsonRequestBehavior.AllowGet);
                    }
                    catch
                    {
                        ModelState.Clear();
                        ModelState.AddModelError("", "Location can not be deleted");

                        return PartialView("CustomerLocation", model);
                    }
            }

            return PartialView("CustomerLocation", model);
        }

        private static string SafeDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        [HttpGet]
        public ActionResult Add()
        {
            FillLookups();
            return View(new AddCustomerViewModel());
        }

        private string GetLabelPath(bool isCustomCustomer, string customerLogoName, int customerId,
            out bool isValidPicture)
        {
            if (customerLogoName.IsNullOrWhiteSpace())
            {
                //image can be null
                isValidPicture = true;
                return null;
            }

            string[] allowedFormats = {".jpg", ".png", ".gif", ".jpeg"};
            string filePath = "";
            if (isCustomCustomer)
            {
                filePath = ConfigurationManager.AppSettings["CustomCustomerLogoPath"];
            }
            else
            {
                filePath = ConfigurationManager.AppSettings["FabricCustomerLogoPath"];
            }
            string subPath = filePath;
            if (subPath == null)
            {
                isValidPicture = false;
                return "Specify directory path to owner labels. Add CustomerLogoFolder and AdminReportFolder keys to <appsettings> section in web.config";
            }
            bool exists = System.IO.Directory.Exists(subPath);
            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);

            var filename = Path.GetFileName(customerLogoName);
            var path = string.Join("", filePath, customerLogoName);
            if (!System.IO.File.Exists(path))
            {
                    isValidPicture = false;
                    return "The filename is not correct or file do not exists";
            }
            var uploadedFileExtension = Path.GetExtension(filename);
            if (uploadedFileExtension == null || uploadedFileExtension.IsNullOrWhiteSpace() ||
                !allowedFormats.Any(
                    x => string.Equals(x, uploadedFileExtension, StringComparison.InvariantCultureIgnoreCase)))
            {
                isValidPicture = false;

                return string.Format("\"{0}\" logo image  extension is not allowed", uploadedFileExtension);
            }
            isValidPicture = true;
            return path;
        }

        [HttpPost]
        public ActionResult Add(AddCustomerViewModel model)
        {
            FillLookups();
            string pictureName ="";
            if (ModelState.IsValid)// && model.Location.IsValid())
            {
                var newCustomerId = _customerRepository.GetAll().Last().Id + 1;

                if (!string.IsNullOrWhiteSpace(model.LogoFileName))
                {
                    bool isValidPicture;
                    pictureName = GetLabelPath(model.CustomerType == OmsCustomerType.Custom, model.LogoFileName,
                        newCustomerId, out isValidPicture);

                    if (!isValidPicture)
                    {
                        ModelState.AddModelError(string.Empty, pictureName);
                        return View("Add", model);
                    }
                }

                var user = new User
                {
                    FirstName = model.OrderContactFirstName,
                    LastName = model.OrderContactLastName,
                    Email = model.OrderContactEmail,
                    Phone = model.OrderContactPhone,
                    Password = model.PortalPassword,
                    IsActive = true,
                    TypeId = 2
                };

                _userRepository.Add(user);
                _userRepository.Save();

                var customer = new Customer
                {
                    BestBeforeDays = model.BestBeforeDays,
                    LogoTypeId = model.UseLogoOnLabels,
                    LogoFileName = pictureName,
                    Name = model.CustomerName,
                    CustomerTypeId = model.CustomerType,
                    PONumber = model.CustomerPo,
                    DistributedBy = model.LabelDistributedBy,
                    BoxLabel = model.BoxLabel,
                    TrayLabel = model.TrayLabel,
                    BagLabel = model.BagLabel,
                    User = user,
                    IsArchived = model.IsArchived,
                    UserId = user.Id
                };

                _customerRepository.Add(customer);
                _customerRepository.Save();

                var products =_productRepository.GetByCustomerType(model.CustomerType).Where(x => x.IsActive).ToList();
                var customerProducts = new List<CustomerProductData>();

                foreach (var product in products)
                {
                    customerProducts.Add(new CustomerProductData
                    {
                        CustomerId = customer.Id,
                        ProductId = product.Id,
                        ProductCode = product.Code,
                        ProductDescription = product.EnglishDescription,
                        Gtin = product.Gtin,
                        PricePerPound = product.PricePerPound
                    });
                }
                _customerProductDataRepository.AddRange(customerProducts);
                _customerProductDataRepository.Save();

                    if (model.Location.IsExists())
                    {
                        var location = model.Location.ToCustomerLocation();
                        location.CustomerId = customer.Id;

                        _customerLocationRepository.Add(location);
                        _customerLocationRepository.Save();
                    }
                    return RedirectToAction("EditCustomer", new { customerId = customer.Id });
                }

                foreach (var pair in model.Location.Validate())
                {
                    ModelState.AddModelError(pair.Key, pair.Value);
                }

                return View(model);
        }

        public ActionResult Edit(string add, string remove, int customerId)
        {
            FillLookups();

            if (!string.IsNullOrEmpty(add))
            {
                SessionService.Get().CustomerViewModel.CurrentEditLocation = new CustomerLocationViewModel
                {
                    CustomerId = customerId
                };

                return View(SessionService.Get().CustomerViewModel);
            }

            return View();
        }

        public ActionResult EditCustomer(int? customerId, int? locationId)
        {
            var itemsBags = _caseSizeRepository.FindAll(x => x.CaseTypeId == 1).Select(x => new CaseSize()
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();
            ViewBag.Bags = itemsBags;
            var itemsBoxes = _caseSizeRepository.FindAll(x => x.CaseTypeId == 2).Select(x => new CaseSize()
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();
            ViewBag.Boxes = itemsBoxes;
            FillLookups();
            if (customerId != null)
            {
                return UpdateView(customerId.Value);
            }
            if (locationId != null)
            {
                var customerViewModel = SessionService.Get().CustomerViewModel;
                customerViewModel.CurrentEditLocation = customerViewModel.CustomerLocations.FirstOrDefault(l => l.LocationId == locationId);
                return View("Edit", customerViewModel);
            }
            return View("Edit");
        }

        private ActionResult UpdateView(int customerId, string message = null)
        {
            var customer = _customerRepository.Get(customerId);
            //var customerProductItems = _customerProductDataRepository.GetByCustomer(customerId).Select(x => new CustomerProductItem()
            //not necessary
            //{
            //    not necessary
            //    Id = x.Product.Id,
            //    Name = x.Product.EnglishDescription,
            //    Upc = x.Product.Upc,
            //    Gtin = x.Gtin,
            //    PricePerPound = x.PricePerPound,
            //    ProductCode = x.ProductCode,
            //    ProductDescription = x.ProductDescription,
            //    IsSelected = true,
            //    BagSize = x.BagSizeEntity != null ? new CaseSize() { Name = x.BagSizeEntity.Name, Id = x.BagSizeEntity.Id } : null,
            //    BoxSize = x.BoxSizeEntity != null ? new CaseSize() { Name = x.BagSizeEntity.Name, Id = x.BagSizeEntity.Id } : null,
            //});
            var customerViewModel = new CustomerViewModel(customer, null);
            SessionService.Get().CustomerViewModel = customerViewModel;
            ViewBag.Message = message;

            return View("Edit", customerViewModel);
        }

        public ActionResult Products_Read([DataSourceRequest] DataSourceRequest request)
        {
            var customerProductItems = _customerProductDataRepository.GetByCustomer(SessionService.Get().CustomerViewModel.Id).Select(x => new CustomerProductItem()
            {
                Id = x.Product.Id,
                Name = x.Product.EnglishDescription,
                Upc = x.Product.Upc,
                Gtin = x.Gtin,
                PricePerPound = x.PricePerPound,
                ProductCode = x.ProductCode,
                BoxQuantity = x.BoxQuantity,
                PieceQuantity = x.PieceQuantity,
                ProductDescription = x.ProductDescription,
                IsSelected = true,
                BagSize = x.BagSizeEntity != null ? new CaseSize() { Name = x.BagSizeEntity.Name, Id = x.BagSizeEntity.Id } : null,
                BoxSize = x.BoxSizeEntity != null ? new CaseSize() { Name = x.BoxSizeEntity.Name, Id = x.BoxSizeEntity.Id } : null,
            }).ToList();
            var productItems =
                    _productRepository.GetAll().ToList().Where(i => customerProductItems.Any(x => x.Id != i.Id) && (i.CustomerTypeId == null || i.CustomerTypeId.Value == SessionService.Get().CustomerViewModel.CustomerType)).Select(x => new CustomerProductItem()
                    {
                        Id = x.Id,
                        Name = x.EnglishDescription,
                        Upc = x.Upc,
                        Gtin = x.Gtin,
                        PricePerPound = x.PricePerPound,
                        ProductCode = x.Code,
                        ProductDescription = x.EnglishDescription,
                        IsSelected = false,
                        BagSize = x.BagSizeEntity != null ? new CaseSize() { Name = x.BagSizeEntity.Name, Id = x.BagSizeEntity.Id } : null,
                        BoxSize = x.BoxSizeEntity != null ? new CaseSize() { Name = x.BoxSizeEntity.Name, Id = x.BoxSizeEntity.Id } : null,
                    }).ToList();
            var allProductItems= customerProductItems.Concat(productItems).OrderByDescending(p => p.IsSelected).ThenBy(p => p.Name);
            
            return Json(allProductItems.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Update([DataSourceRequest] DataSourceRequest request,
            [Bind(Prefix = "models")] IEnumerable<CustomerProductItem> products)
        {
            foreach (var product in products)
            {
                var customerId = SessionService.Get().CustomerViewModel.Id;
              
                var cpd =
                    _customerProductDataRepository.GetByProduct(product.Id)
                        .SingleOrDefault(p => p.CustomerId == customerId);
                
                if (product.IsSelected)
                {
                    var target = new CustomerProductData
                    {
                        CustomerId = customerId,
                        ProductId = product.Id,
                        ProductCode = product.ProductCode,
                        ProductDescription = product.ProductDescription,
                        Gtin = product.Gtin,
                        PricePerPound = product.PricePerPound,
                        BoxQuantity = product.BoxQuantity,
                        PieceQuantity = product.PieceQuantity,
                        BagSizeId = product.BagSize != null ? product.BagSize.Id : (int?) null,
                        BoxSizeId = product.BoxSize != null ? product.BoxSize.Id : (int?) null
                    };
                    if (cpd != null)
                        _customerProductDataRepository.Remove(cpd);
                    _customerProductDataRepository.Add(target);
                }
                else
                {
                    _customerProductDataRepository.Remove(cpd);
                }
                _customerProductDataRepository.Save();
            }
            return Json(products.ToDataSourceResult(request));
        }

        public ActionResult CustomerLocations([DataSourceRequest] DataSourceRequest request)
        {
            return Json(SessionService.Get().CustomerViewModel.CustomerLocations.ToDataSourceResult(request));
        }

        private void FillLookups()
        {
            ViewBag.LogoType = _logoTypeRepository.GetAll();
        }

        public ActionResult EditCustomerLocation(int locationId)
        {
            FillLookups();
            var customerViewModel = SessionService.Get().CustomerViewModel;
            customerViewModel.CurrentEditLocation = customerViewModel.CustomerLocations.FirstOrDefault(l => l.LocationId == locationId);
            return View("Edit", customerViewModel);
        }

        public ActionResult ProcessProducts(CustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = _customerRepository.Get(viewModel.Id);
                if (customer != null && viewModel.CustomerProductCodeList != null)
                {
                    //customer.CustomerProductData.Clear();
                    //_customerRepository.Update(customer);
                    //_customerRepository.Save();

                    var productCodeItems = viewModel.CustomerProductCodeList.Where(x => x.IsSelected).ToArray();
                    //foreach (var item in productCodeItems)
                    //{
                    //    _customerProductDataRepository.Add(new CustomerProductData
                    //    {
                    //        CustomerId = viewModel.Id,
                    //        ProductId = item.Id,
                    //        ProductCode = item.ProductCode,
                    //        ProductDescription = item.ProductDescription,
                    //        Gtin = item.Gtin,
                    //        PricePerPound = item.PricePerPound
                    //    });
                    //}

                    //_customerProductDataRepository.Save();
                }

                return RedirectToAction("EditCustomer", new { customerId = viewModel.Id });
            }

            return View("Edit", viewModel);
        }

        public ActionResult CustomerLocation(int? locationId = null)
        {
            if (locationId.HasValue)
            {
                SessionService.Get().CustomerViewModel.CurrentEditLocation = SessionService.Get().CustomerViewModel.CustomerLocations.FirstOrDefault(l => l.LocationId == locationId);
            }
            else
            {
                SessionService.Get().CustomerViewModel.CurrentEditLocation = new CustomerLocationViewModel
                {
                    CustomerId = SessionService.Get().CustomerViewModel.Id,
                };
            }

            SessionService.Get().CustomerViewModel.CurrentEditLocation = SessionService.Get().CustomerViewModel.CurrentEditLocation ?? new CustomerLocationViewModel
            {
                CustomerId = SessionService.Get().CustomerViewModel.Id,
            };

            return View("CustomerLocation", SessionService.Get().CustomerViewModel.CurrentEditLocation);
        }
    }
}