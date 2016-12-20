﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

using DoubleJ.Oms.DataAccess;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.Repositories;
using DoubleJ.Oms.Model.ViewModels.Internal;
using DoubleJ.Oms.Model.ViewModels.Mobile;
using DoubleJ.Oms.Service.Interfaces;
using DoubleJ.Oms.Service.Services.Device;
using DoubleJ.Oms.Utils.Extensions;
using ProductViewModel = DoubleJ.Oms.Model.ViewModels.Mobile.ProductViewModel;


namespace DoubleJ.Oms.Service.Services.Internal
{
    public class LabelService : ILabelService
    {
        public const string SerialNumberMarker = "(21)";
        public const int SerialNumberLength = 7;

        private ILabelRepository _labelRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IOrderRepository _orderRepository;
        private IColdWeightEntryRepository _coldWeightEntryRepository;
        private IColdWeightEntryDetailRepository _coldWeightEntryDetailRepository;
        private ICustomerLocationRepository _customerLocationRepository;
        private IAnimalOrderDetailRepository _animalOrderDetailRepository;
        private IProductRepository _productRepository;
        private ILabelCreateService _labelCreateService;
        private ICustomerRepository _customerRepository;
        private IPrimalCutRepository _primalCutRepository;
        private ISpeciesRepository _speciesRepository;
        public LabelService()
        {
            Init();
        }

        private void Init()
        {
            var context = new OmsContext();
            _labelRepository = new LabelRepository(context);
            _orderRepository = new OrderRepository(context);
            _orderDetailRepository = new OrderDetailRepository(context);
            _coldWeightEntryRepository = new ColdWeightEntryRepository(context);
            _coldWeightEntryDetailRepository = new ColdWeightEntryDetailRepository(context);
            _customerLocationRepository = new CustomerLocationRepository(context);
            _animalOrderDetailRepository = new AnimalOrderDetailRepository(context);
            _productRepository = new ProductRepository(context);
            _customerRepository = new CustomerRepository(context);
            _labelCreateService = new LabelCreateService();
            _primalCutRepository = new PrimalCutRepository(context);
            _speciesRepository = new SpeciesRepository(context);
        }

        public List<Order> GetOrders()
        {
            var statusList = new List<OmsStatus>
            {
                OmsStatus.InProcess,
                OmsStatus.Parked,
                OmsStatus.NotStarted
            };

            return _orderRepository.GetByStatus(statusList).ToList();
        }

        public LabelViewModel Get(int? orderId)
        {
            if (!orderId.HasValue) return new LabelViewModel();

            var order = _orderRepository.Get(orderId.Value);
            var orderDetails = order.OrderDetail.ToList();

            return new LabelViewModel
            {
                OrderId = orderId,
                CustomerName = order.Customer.Name,
                CustomerLocationsTotal = orderDetails.Select(od => od.CustomerLocation).Distinct().Count(),
                PieceTotal = orderDetails.Sum(od => od.PieceQuantity),
                BagTotal = orderDetails.Sum(od => (od.Product.BoxBagQuantity * od.BoxQuantity)),
                BoxTotal = orderDetails.Sum(od => od.BoxQuantity),
                SpecialInstructions = order.SpecialInstructions,
                CustomerComments = order.CustomerComments
            };
        }

        public LabelGridViewModel GetLabelGridDefinition(int orderId)
        {
            var orderDetails = _orderDetailRepository.GetAllByOrder(orderId).ToArray();
            var locations = GetCustomerLocations(orderDetails).ToList();

            var result = new LabelGridViewModel
            {
                OrderId = orderId,
                Locations = locations,
            };

            return result;
        }

        public IEnumerable<LabelGridItem> GetBagGridItems(int orderId)
        {
            var orderDetails = GetOrderDetailsWithoutOffalProducts(orderId);
            var locations = GetCustomerLocations(orderDetails);
            var products = GetProducts(orderDetails);

            var gridItems = new List<LabelGridItem>();
            foreach (var product in products)
            {
                var gridItem = new LabelGridItem
                {
                    ProductId = product.Id,
                    ProductName = ProductService.GetFormattedProductName(product),
                    Locations = new ObservableCollection<LabelGridItem.LocationTemplate>()
                };

                for (var locationId = 0; locationId < locations.Length; locationId++)
                {
                    var location = locations.ElementAtOrDefault(locationId);
                    if (location == null) continue;

                    var item = orderDetails.FirstOrDefault(it => it.CustomerLocationId == location.Id && it.ProductId == product.Id);
                    if (item == null) continue;

                    int bagQuantity = item.Product.BagPieceQuantity;
                    var customerProducts =
                        product.CustomerProductData.Where(x => x.CustomerId == item.Order.CustomerId);
                    var customerProduct = customerProducts.FirstOrDefault();
                    if (customerProduct != null)
                    {
                        if (customerProduct.BoxQuantity.HasValue)
                        {
                            bagQuantity = customerProduct.BoxQuantity.Value;
                        }
                    }
                    gridItem.Locations.Add(new LabelGridItem.LocationTemplate
                    {
                        Id = item.CustomerLocationId,
                        OrderDetailId = item.Id,
                        CompletedCount = item.Label.Count(label => label.TypeId == OmsLabelType.Bag),
                        Total = item.PieceQuantity /
                            // in case when db has incorrect data
                        (bagQuantity == 0 ? 1 : bagQuantity),
                    });
                }

                gridItems.Add(gridItem);
            }

            return gridItems;
        }

        public IEnumerable<LabelGridItem> GetBoxGridItems(int orderId, bool bagSuppress)
        {
            var orderDetails = GetOrderDetailsWithoutOffalProducts(orderId);
            var locations = GetCustomerLocations(orderDetails);
            var products = GetProducts(orderDetails);

            var gridItems = new List<LabelGridItem>();
            foreach (var product in products)
            {
                var gridItem = new LabelGridItem
                {
                    ProductId = product.Id,
                    ProductName = ProductService.GetFormattedProductName(product),
                    Locations = new ObservableCollection<LabelGridItem.LocationTemplate>()
                };

                for (var locationId = 0; locationId < locations.Length; locationId++)
                {
                    var location = locations.ElementAtOrDefault(locationId);
                    if (location == null) continue;

                    var item = orderDetails.FirstOrDefault(it => it.CustomerLocationId == location.Id && it.ProductId == product.Id);
                    if (item == null) continue;
                    int boxQuantity = item.Product.BoxBagQuantity;
                    int bagQuantity = item.Product.BagPieceQuantity;
                    var customerProducts =
                        product.CustomerProductData.Where(x => x.CustomerId == item.Order.CustomerId);
                    var customerProduct = customerProducts.FirstOrDefault();
                    if (customerProduct != null)
                    {
                        if (customerProduct.BoxQuantity.HasValue)
                        {
                            bagQuantity = customerProduct.BoxQuantity.Value;
                        }
                        if (customerProduct.PieceQuantity.HasValue)
                        {
                            boxQuantity = customerProduct.PieceQuantity.Value;
                        }
                    }
                    gridItem.Locations.Add(new LabelGridItem.LocationTemplate
                    {
                        Id = item.CustomerLocationId,
                        OrderDetailId = item.Id,
                        CompletedCount = item.Label.Count(label => label.TypeId == OmsLabelType.Box),
                        Total = bagSuppress ? item.PieceQuantity :
                        (item.PieceQuantity /
                            // in case when db has incorrect data
                        (bagQuantity == 0 ? 1 : bagQuantity)
                        / (boxQuantity == 0 ? 1 : boxQuantity))
                    });
                }

                gridItems.Add(gridItem);
            }

            return gridItems;
        }
        /// <summary>
        /// group list by nine items
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<List<OrderDetail>> SplitCustomerList(List<OrderDetail> source)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / 9)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
        /// <param name="orderId"></param>
        /// <param name="bagSuppress"></param>
        /// <returns>Item1 - box labels; Item2 - bag labels</returns>
        public Tuple<IEnumerable<LabelGridItem>, IEnumerable<LabelGridItem>> GetLabelGridItems(int orderId, bool bagSuppress)
       {
            var orderDetails = GetOrderDetailsWithoutOffalProducts(orderId);
            var products = GetProducts(orderDetails);

            var boxItems = new List<LabelGridItem>();
            var bagItems = new List<LabelGridItem>();
           // var trayItems = new List<LabelGridItem>();

            foreach (var product in products)
            {
                var locationsFiltered = from ods in orderDetails
                                        where ods.ProductId == product.Id
                                        select ods;

                var splitCustomerList = SplitCustomerList(locationsFiltered.GroupBy(x => x.CustomerLocationId).Select(x => x.First()).ToList());
                foreach (var items in splitCustomerList)
                {
                    var boxItem = CreateLabelGridItem(product);
                    var bagItem = CreateLabelGridItem(product);
                    var trayItem = CreateLabelGridItem(product);
                    int countForBag = 0;
                    int countForBox = 0;
                    int countForTray = 0;
                    foreach (var item in items)
                    {
                        int boxQuantity= item.Product.BoxBagQuantity;
                        int bagQuantity = item.Product.BagPieceQuantity; 
                        var customerProducts =
                            product.CustomerProductData.Where(x => x.CustomerId == item.Order.CustomerId);
                        var customerProduct = customerProducts.FirstOrDefault();
                        if (customerProduct != null)
                        {
                            if (customerProduct.BoxQuantity.HasValue)
                            {
                                bagQuantity = customerProduct.BoxQuantity.Value;
                            }
                            if (customerProduct.PieceQuantity.HasValue)
                            {
                                boxQuantity = customerProduct.PieceQuantity.Value;
                            }
                        }
                        boxItem.Locations.Add(new LabelGridItem.LocationTemplate
                        {
                            Id = item.CustomerLocationId,
                            OrderDetailId = item.Id,
                            CompletedCount =
                                item.Label.Where(l => l.TypeId == OmsLabelType.Box || l.TypeId == OmsLabelType.Tray).GroupBy(l => l.SerialNumber).Count(),
                            Total = bagSuppress
                                    ? item.PieceQuantity
                                    : (int)Math.Ceiling((float)item.PieceQuantity / bagQuantity.AsQuantity() / boxQuantity.AsQuantity()),
                            BagBoxShort = item.CustomerLocation.ShortName,
                            BagBox = item.CustomerLocation.Name,
                            LocationTemplateId = countForBox++
                        });
                        //trayItem.Locations.Add(new LabelGridItem.LocationTemplate
                        //{
                        //    Id = item.CustomerLocationId,
                        //    OrderDetailId = item.Id,
                        //    CompletedCount =
                        //        item.Label.Where(l => l.TypeId == OmsLabelType.Tray).GroupBy(l => l.SerialNumber).Count(),
                        //    Total = bagSuppress
                        //            ? item.PieceQuantity
                        //            : (int)Math.Ceiling((float)item.PieceQuantity / bagQuantity.AsQuantity() / boxQuantity.AsQuantity()),
                        //    BagBoxShort = item.CustomerLocation.ShortName,
                        //    BagBox = item.CustomerLocation.Name,
                        //    LocationTemplateId = countForBox++
                        //});
                        if (!bagSuppress)
                        {
                            bagItem.Locations.Add(new LabelGridItem.LocationTemplate
                            {
                                Id = item.CustomerLocationId,
                                OrderDetailId = item.Id,
                                CompletedCount =
                                    item.Label.Where(l => l.TypeId == OmsLabelType.Bag)
                                        .GroupBy(l => l.SerialNumber)
                                        .Count(),
                                Total = (int)Math.Ceiling((float)item.PieceQuantity / bagQuantity.AsQuantity()),
                                BagBoxShort = item.CustomerLocation.ShortName,
                                BagBox = item.CustomerLocation.Name,
                                LocationTemplateId = countForBag++
                            });
                        }
                    }
                    boxItems.Add(boxItem);
                    bagItems.Add(bagItem);
                   // trayItems.Add(trayItem);
                }
            }

            return new Tuple<IEnumerable<LabelGridItem>, IEnumerable<LabelGridItem>>(boxItems, bagItems);
        }

        private static IEnumerable<Product> GetProducts(OrderDetail[] orderDetails)
        {
            var products = orderDetails
                .Select(od => od.Product)
                .Distinct()
                .ToArray();
            return products;
        }

        public BindingList<LabelBagItem> GetAnimalNumbers(int orderId)
        {
            var coldWeight = _coldWeightEntryRepository.GetByOrderId(orderId);
            if (coldWeight == null)
            {
                return new BindingList<LabelBagItem>();
            }
            var animalNumbersList = coldWeight.ColdWeightEntryDetails.Select(x => new LabelBagItem
            {
                OrderId = orderId,
                SpeciesId = x.AnimalLabel.SpeciesId,
                BaseSpecies = x.AnimalLabel.Species.BaseSpecies,
                Name = x.AnimalNumber,
                ColdWeightDetailId = x.Id
                
            }).ToList();

            return new BindingList<LabelBagItem>(animalNumbersList);
        }

        public BindingList<LabelBoxItem> GetBoxesCustomList(int orderId)
        {
            var coldWeight = _coldWeightEntryRepository.GetByOrderId(orderId);
            if (coldWeight == null)
                return new BindingList<LabelBoxItem>();

            var list = new List<LabelBoxItem>();
            var animalOrderDetails = coldWeight.ColdWeightEntryDetails.SelectMany(cw => cw.AnimalOrderDetails).ToList();
            foreach (var detail in coldWeight.ColdWeightEntryDetails)
            {
                var sides = _coldWeightEntryDetailRepository.GetSideWeigths(detail.Id);
                foreach (var side in sides)
                {
                    if (!side.Value.HasValue)
                        continue;

                    var orderDetailsForSide = animalOrderDetails.Where(a => a.ColdWeightDetailId == detail.Id).Select(a => a.OrderDetail)
                        .ToList().FindAll(x => x.SideTypeId == side.Key).ToList();

                    if (!orderDetailsForSide.Any()) continue;

                    var cl = orderDetailsForSide.First().CustomerLocation;
                    var count = orderDetailsForSide.SelectMany(s => s.Label)
                        .Where(s => s.TypeId == OmsLabelType.Box)
                        .GroupBy(l => l.SerialNumber)
                        .Count();

                    
                    list.Add(new LabelBoxItem
                    {
                        QualityGrade = detail.QualityGrade,
                        AnimalLabel  = detail.AnimalLabel,
                        OrderId = orderId,
                        Name = string.Format("Back Tag '{0}' {2} '{1}'", detail.AnimalNumber, cl.Name, side.Key),
                        CustomerLocationId = cl.Id,
                        ColdWeightDetailId = detail.Id,
                        CompletedCount = count,
                        Side = side.Key
                    });
                }
            }

            return new BindingList<LabelBoxItem>(list);
        }

        public BindingList<LabelBoxItem> GetTraysCustomList(int orderId)
        {
            var coldWeight = _coldWeightEntryRepository.GetByOrderId(orderId);
            if (coldWeight == null)
                return new BindingList<LabelBoxItem>();

            var list = new List<LabelBoxItem>();
            var animalOrderDetails = coldWeight.ColdWeightEntryDetails.SelectMany(cw => cw.AnimalOrderDetails).ToList();
            foreach (var detail in coldWeight.ColdWeightEntryDetails)
            {
                var sides = _coldWeightEntryDetailRepository.GetSideWeigths(detail.Id);
                foreach (var side in sides)
                {
                    if (!side.Value.HasValue)
                        continue;

                    var orderDetailsForSide = animalOrderDetails.Where(a => a.ColdWeightDetailId == detail.Id).Select(a => a.OrderDetail)
                        .ToList().FindAll(x => x.SideTypeId == side.Key).ToList();

                    if (!orderDetailsForSide.Any()) continue;

                    var cl = orderDetailsForSide.First().CustomerLocation;
                    var count = orderDetailsForSide.SelectMany(s => s.Label)
                        .Where(s => s.TypeId == OmsLabelType.Tray)
                        .GroupBy(l => l.SerialNumber)
                        .Count();

                    
                    list.Add(new LabelBoxItem
                    {
                        QualityGrade = detail.QualityGrade,
                        AnimalLabel  = detail.AnimalLabel,
                        OrderId = orderId,
                        Name = string.Format("Back Tag '{0}' {2} '{1}'", detail.AnimalNumber, cl.Name, side.Key),
                        CustomerLocationId = cl.Id,
                        ColdWeightDetailId = detail.Id,
                        CompletedCount = count,
                        Side = side.Key
                    });
                }
            }

            return new BindingList<LabelBoxItem>(list);
        }

        public IEnumerable<SideWeightItem> GetSideWeigths(int coldWeightDetailId, int orderId)
        {
            var sideWeigths = _coldWeightEntryDetailRepository.GetSideWeigths(coldWeightDetailId);
            var coldWeightEntry= _coldWeightEntryDetailRepository.Get(coldWeightDetailId);
            var speciesId = coldWeightEntry.AnimalLabel.SpeciesId;
            var animalPart = coldWeightEntry.ColdWeightEntry.TrackAnimalId.GetEnumDescription();
            Dictionary<OmsSideType, string> sideParts = null;  
            if (coldWeightEntry.ColdWeightEntry.TrackAnimalId == TrackAnimal.Half)
            {
                sideParts = new Dictionary<OmsSideType, string>()
                {
                    {OmsSideType.FirstSide, "Half 1"},
                    {OmsSideType.SecondSide, "Half 2"},
                    {OmsSideType.ThirdSide, ""},
                    {OmsSideType.FourthSide, ""}
                };
            }
            else if (coldWeightEntry.ColdWeightEntry.TrackAnimalId == TrackAnimal.HalfAndTwoQuaters)
            {
                sideParts = new Dictionary<OmsSideType, string>()
                {
                    {OmsSideType.FirstSide, "Half"},
                    {OmsSideType.SecondSide, "Quater 1"},
                    {OmsSideType.ThirdSide, "Quater 2"},
                    {OmsSideType.FourthSide, ""}
                };
            }
            else if (coldWeightEntry.ColdWeightEntry.TrackAnimalId == TrackAnimal.Quarter)
            {
                sideParts = new Dictionary<OmsSideType, string>()
                {
                    {OmsSideType.FirstSide, "Quater 1"},
                    {OmsSideType.SecondSide, "Quater 2"},
                    {OmsSideType.ThirdSide, "Quater 3"},
                    {OmsSideType.FourthSide, "Quater 4"}
                };
            }
            else if (coldWeightEntry.ColdWeightEntry.TrackAnimalId == TrackAnimal.ThreeQuatersAndQuater)
            {
                sideParts = new Dictionary<OmsSideType, string>()
                {
                    {OmsSideType.FirstSide, "3/4"},
                    {OmsSideType.SecondSide, "Quater"},
                    {OmsSideType.ThirdSide, ""},
                    {OmsSideType.FourthSide, ""}
                };
            }    
            return (from sideWeigt in sideWeigths
                    select new SideWeightItem
                    {
                        AnimalPart = animalPart,
                        IsWeight = sideWeigt.Value.HasValue,
                        Name = sideWeigt.Value.HasValue ? _customerLocationRepository.Get(sideWeigt.Value.Value).Name : null,
                        CustomerLocationId = sideWeigt.Value ?? 0,
                        OrderId = orderId,
                        ColdWeightDetailId = coldWeightDetailId,
                        SpeciesId = speciesId,
                        Products = GetProductsList(sideWeigt.Value, coldWeightDetailId, sideWeigt.Key),
                        SideNumber = sideWeigt.Key,
                        QualityGrade = coldWeightEntry.QualityGrade,
                        AnimalLabel = coldWeightEntry.AnimalLabel,
                        SideMark = sideParts!= null? sideParts[sideWeigt.Key]:""
                    }).ToList();
        }

        private ObservableCollection<CutItem> GetProductsList(int? customerLocationId, int coldWeightDetailId, OmsSideType sideNumber)
        {
            if (!customerLocationId.HasValue)
                return null;

            var animalNumbersWithOrderDetail = _animalOrderDetailRepository.GetByColdWeghtDetailId(coldWeightDetailId);
            var productslabels = new List<CutItem>();
            foreach (var item in animalNumbersWithOrderDetail.Where(x => x.OrderDetail.SideTypeId == sideNumber))
            {
                if (item.OrderDetail.CustomerLocationId != customerLocationId.Value)
                    continue;
                var label = GetLabels(item.OrderDetail.Id).LastOrDefault();
                if (label != null)
                    productslabels.Add(new CutItem
                    {
                        ProductId = item.OrderDetail.ProductId,
                        ProductName = ProductService.GetFormattedProductName(item.OrderDetail.Product),
                        Id = Guid.NewGuid().ToString("D"),
                        OrderDetailId = item.OrderDetail.Id,
                        Weight = string.Format("{0} lbs", LabelCreateService.GetGrossPoundWeight(label.PoundWeight, label.TypeId, item.OrderDetail))
                    });
            }
            var products = new ObservableCollection<CutItem>(productslabels.OrderByDescending(x => x.OrderDetailId));
            return products;
        }

        private LabelGridItem CreateLabelGridItem(Product product)
        {
            return new LabelGridItem
            {
                ProductId = product.Id,
                ProductName = ProductService.GetFormattedProductName(product),
                UPC =  product.Upc,
                EnglishDescription = product.EnglishDescription,
                Locations = new ObservableCollection<LabelGridItem.LocationTemplate>()
            };
        }

        public IEnumerable<LabelEditItem> GetPrintedLabels(int orderId)
        {
            var orderDetails = _orderDetailRepository
                .GetAllByOrder(orderId)
                .ToArray();

            var result = orderDetails
                .SelectMany(x => x.Label)
                .Select(x => new LabelEditItem
                {
                    LabelId = x.Id,
                    LabelType = x.TypeId,
                    LocationName = x.OrderDetail.CustomerLocation.Name,
                    PoundWeight = LabelCreateService.GetNetPoundWeight(x.PoundWeight, x.TypeId, x.OrderDetail),
                    PrintedDate = x.CreatedDate,
                    ProductName = ProductService.GetFormattedProductName(x.OrderDetail.Product)
                })
                .ToArray();

            return result;
        }

        public void UpdateLabel(int labelId, double poundWeight, OmsLabelType labelType)
        {
            Label label = _labelRepository.Get(labelId);
            var od = _orderDetailRepository.Get(label.OrderDetailId);
            label.IsPrinted = false;
            label.PoundWeight = LabelCreateService.GetNetPoundWeight(poundWeight, labelType, od);
            label.KilogramWeight = LabelCreateService.GetCorrectKilogramWeight(label.PoundWeight);
            label.CreatedDate = DateTime.Now;
            label.ProcessDate = od.Order.ProcessDate.GetValueOrDefault().ToString("d");
            _labelRepository.Update(label);
            _labelRepository.Save();
        }

        public void RemoveLabel(int labelId)
        {
            var label = _labelRepository.Get(labelId);
            _labelRepository.Remove(label);
            _labelRepository.Save();
        }

        public List<ProductViewModel> GetPendingProducts(int orderId)
        {
            var model = _orderRepository
                .Get(orderId)
                .OrderDetail
                .SelectMany(x => x.Label)
                .Where(x => (x.CurrentLocationId == OmsCurrentLocation.FinishedGoods || x.CurrentLocationId == null) && x.SerialNumber != null)
                .Select(label => new ProductViewModel
                {
                    LabeId = label.Id,
                    SerialNumber = label.SerialNumber,
                    ProductNumber = label.OrderDetail.ProductId,
                    Product = label.OrderDetail.Product.EnglishDescription
                })
                .ToList();

            return model;
        }

        public List<ProductViewModel> GetAllocatedProducts(int orderId)
        {
            var model = _orderRepository
                .Get(orderId)
                .OrderDetail
                .SelectMany(x => x.Label)
                .Where(x => x.CurrentLocationId == OmsCurrentLocation.Shipped && x.SerialNumber != null)
                .Select(label => new ProductViewModel
                {
                    LabeId = label.Id,
                    SerialNumber = label.SerialNumber,
                    ProductNumber = label.OrderDetail.ProductId,
                    Product = label.OrderDetail.Product.EnglishDescription
                })
                .ToList();

            return model;
        }

        private IEnumerable<Label> SearchLabelsBySerialNumber(string inputString)
        {
            var serial = inputString;
            if (inputString.Contains(SerialNumberMarker))
            {
                var index = inputString.IndexOf(SerialNumberMarker, StringComparison.Ordinal);
                if (index != -1)
                {
                    try
                    {
                        serial = inputString.Substring(index + SerialNumberMarker.Length, SerialNumberLength);
                    }
                    catch
                    {
                        return Enumerable.Empty<Label>();
                    }
                }
            }

            var result = _labelRepository
                .FindAll(x => x.SerialNumber == serial)
                .ToArray();

            return result;
        }

        public SnLookupViewModel GetBySn(string serialNumber)
        {
            var result = SearchLabelsBySerialNumber(serialNumber)
                .Select(label => new SnLookupViewModel
                {
                    SerialNumber = serialNumber,
                    OrderNumber = label.OrderDetail.OrderId,
                    ProductId = label.OrderDetail.ProductId,
                    CurrentLocation = label.CurrentLocation == null ? null : label.CurrentLocation.Name
                })
                .FirstOrDefault();

            return result;
        }

        public void ResetLocation(string serialNumber)
        {
            var label = _labelRepository.Query().FirstOrDefault(x => x.SerialNumber == serialNumber);
            if (label == null) return;

            label.CurrentLocationId = OmsCurrentLocation.FinishedGoods;
            _labelRepository.Save();
        }

        public bool Associate(string serialNumber)
        {
            var label = SearchLabelsBySerialNumber(serialNumber).FirstOrDefault(x => x.CurrentLocationId != OmsCurrentLocation.Shipped);
            if (label == null) return false;

            label.CurrentLocationId = OmsCurrentLocation.Shipped;
            _labelRepository.Save();

            return true;
        }

        public IEnumerable<Order> GetByStatus(IEnumerable<OmsStatus> statuses)
        {
            return _orderRepository.GetByStatus(statuses.ToList());
        }

        public List<CustomerLocation> GetOrderLocations(int orderId)
        {
            var orderDetails = _orderDetailRepository
                .Query()
                .Where(x => x.OrderId == orderId && x.Product != null && !x.Product.Upc.Contains("-Y"))
                .ToArray();

            var result = orderDetails
                .Select(od => od.CustomerLocation)
                .Distinct()
                .ToList();

            return result;
        }

        public Order GetOrder(int orderId)
        {
            var result = _orderRepository.Get(orderId);
            return result;
        }

        public List<ProductViewModel> GetPendingProducts(int orderId, int destinationId)
        {
            var result = _orderRepository
                .Get(orderId)
                .OrderDetail
                .Where(orderDetail => orderDetail.CustomerLocationId == destinationId)
                .SelectMany(orderDetail => orderDetail.Label)
                .Where(label => (label.CurrentLocationId == null || label.CurrentLocationId == OmsCurrentLocation.FinishedGoods) && label.SerialNumber != null)
                .Select(label => new ProductViewModel
                {
                    LabeId = label.Id,
                    SerialNumber = label.SerialNumber,
                    ProductNumber = label.OrderDetail.ProductId,
                    Product = label.OrderDetail.Product.EnglishDescription
                })
                .ToList();

            return result;
        }

        public List<ProductViewModel> GetAllocatedProducts(int orderId, int destinationId)
        {
            var model = _orderRepository.Get(orderId)
                .OrderDetail.Where(x => x.CustomerLocationId == destinationId)
                .SelectMany(x => x.Label)
                .Where(x => x.CurrentLocationId == OmsCurrentLocation.Shipped && x.SerialNumber != null)
                .Select(label => new ProductViewModel
                {
                    LabeId = label.Id,
                    SerialNumber = label.SerialNumber,
                    ProductNumber = label.OrderDetail.ProductId,
                    Product = label.OrderDetail.Product.EnglishDescription
                })
                .ToList();

            return model;
        }

        public bool IsCompleted(int orderId, int locationId)
        {
            var products = GetPendingProducts(orderId, locationId);
            return !products.Any();
        }

        public void Complete(int orderId)
        {
            var order = _orderRepository.Get(orderId);
            order.StatusId = OmsStatus.Shipped;
            _orderRepository.Update(order);
            _orderRepository.Save();
        }

        public List<CutItem> GetCustomProducts(string baseSpecies, int orderId, int primalCutId)
        {
            var order = _orderRepository.Get(orderId);
            var items = 
                _productRepository.GetByCustomer(order.CustomerId)
                    .Where(x => x.CustomerTypeId == OmsCustomerType.Custom && x.PrimalCutId == primalCutId)
                    .OrderBy(x => x.PrimalCut.BackgroundSort)
                    .ThenBy(x => x.EnglishDescription)
                    .ToList();

            return items.Where(x => x.Species.BaseSpecies.Equals(baseSpecies)).Select(item => new CutItem
            {
                ProductId = item.Id,
                ProductName = ProductService.GetFormattedProductName(item),
                TextColor = item.PrimalCut.TextColor,
                BackGroundColor = item.PrimalCut.BackgroundColor
            }).ToList();
        }

        public List<PrimalCut> GetPrimals(int speciesId, int orderId)
        {
            var order = _orderRepository.Get(orderId);
            var products = _productRepository.GetByCustomer(order.CustomerId)
                .Where(x => x.SpeciesId == speciesId && x.CustomerTypeId == OmsCustomerType.Custom).ToList();
            var cuts = products.Select(x => x.PrimalCut).Distinct().Select(x => new PrimalCut()
            {
                Name = x.Name,
                BackgroundColor = x.BackgroundColor,
                SortOrder = x.SortOrder,
                Id = x.Id,
                TextColor = x.TextColor
            });
           
            return cuts.ToList();
        }

        public List<Label> GetLabels(int orderDetailId)
        {
            return _labelRepository.FindAll(l => l.OrderDetailId == orderDetailId).ToList();
        }

        private static CustomerLocation[] GetCustomerLocations(OrderDetail[] orderDetails)
        {
            var locations = orderDetails
                .Select(od => od.CustomerLocation)
                .Distinct()
                .ToArray();
            return locations;
        }

        private OrderDetail[] GetOrderDetailsWithoutOffalProducts(int orderId)
        {
            var orderDetails = _orderDetailRepository
                .Query()
                .Where(x => x.OrderId == orderId && x.Product != null && !x.Product.Upc.Contains("-Y") && x.Product.IsOffal == false)
                .ToArray();
            return orderDetails;
        }

        public LabelReport GetLabelReports(int CustomerTypeId, DateTime date)
        {
            var labelDetail =
                _labelRepository.Query()
                    .Join(_orderDetailRepository.Query(), label => label.OrderDetailId, detail => detail.Id,
                        (label, detail) =>
                            new
                            {
                                CustomerName = label.Customer,
                                CreateDate = label.CreatedDate, detail.ProductId, detail.OrderId,
                                ProductName = detail.Product.EnglishDescription
                            });
            var labelDetailOrder = labelDetail.Join(_orderRepository.Query(), labeldetail => labeldetail.OrderId,
                order => order.Id,
                (labeldetail, order) =>
                    new
                    {
                        labeldetail.CustomerName, labeldetail.CreateDate, labeldetail.ProductId, labeldetail.OrderId,
                        labeldetail.ProductName, order.CustomerId
                    });
            var labelDetailOrderCustomer = labelDetailOrder.Join(_customerRepository.Query(), lbo => lbo.CustomerId,
                customer => customer.Id,
                (lbo, customer) =>
                    new
                    {
                        lbo.CustomerName, lbo.CreateDate, lbo.ProductId, lbo.OrderId,lbo.ProductName, lbo.CustomerId, customer.CustomerTypeId
                    });
            var enumerable = labelDetailOrderCustomer.ToList().Where(x=>x.CreateDate.Date == date);
            if (CustomerTypeId != 0)
            {
                enumerable = enumerable.Where(x => (int) x.CustomerTypeId == CustomerTypeId);
            }

            var itemsByCustomers = enumerable.GroupBy(x => new {x.CustomerName},x=>x);
            LabelReport  report = new LabelReport() {Date = date};
            foreach (var grouperdByCustomers in itemsByCustomers)
            {
                var reportItem = new LabelReportItem()
                {
                    CustomerName = grouperdByCustomers.Key.CustomerName
                };
                var itemsByProduct = grouperdByCustomers.GroupBy(x => x.ProductId, x => x);
                foreach (var groupItem in itemsByProduct)
                {
                    reportItem.Products.Add(new ProductQuantityItem {ProductName = groupItem.First().ProductName,Quantity = groupItem.Count()});
                } 
                report.Items.Add(reportItem);  
            }
            return report;
        }
    }

}