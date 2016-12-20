using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

using DoubleJ.Oms.DataAccess;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Extensions;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.Models;
using DoubleJ.Oms.Model.Repositories;
using DoubleJ.Oms.Model.ViewModels.Internal;
using DoubleJ.Oms.Service.Interfaces;
using DoubleJ.Oms.Settings;

using NLog;


namespace DoubleJ.Oms.Service.Services.Device
{
    public class LabelCreateService : ILabelCreateService
    {
        public const double LbsKgConversionFactor = 0.453592;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private ILabelRepository _labelRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IOrderRepository _orderRepository;

        public void ProduceLabel(int orderDetailId, ScaleWeight weight, OmsLabelType labelType, DateTime? processDate)
        {
            ProduceLabel(orderDetailId, weight.Gross, labelType,1,processDate);
        }

        public void ProduceLabel(int orderDetailId, double poundWeight, OmsLabelType labelType, int quantity=1, DateTime? processDate = null, QualityGrade qualityGrade = null, AnimalLabelsViewModel animalLabel = null, CaseSize customCaseSize = null)
        {
            var context = new OmsContext();
            _orderDetailRepository = new OrderDetailRepository(context);
            var orderDetail = _orderDetailRepository.GetLabelInfo(orderDetailId);
            var model = GetLabelLayoutViewModel(poundWeight, orderDetail, labelType, false,qualityGrade, animalLabel, customCaseSize);
            for (var i = 0; i < quantity; i++)
            {
                ProduceLabel(labelType, model, orderDetail, false, processDate);
            }
            context.Dispose();
        }

        public void ProduceCustomBagLabels(List<OrderDetail> orderDetails, double poundWeight, OmsLabelType labelType, DateTime? processDate, QualityGrade qualityGrade, AnimalLabelsViewModel animalLabel = null, CaseSize customCaseSize = null)
        {
            if(!orderDetails.Any())
                return;
            var model = GetLabelLayoutViewModel(poundWeight, orderDetails.First(), labelType, false, qualityGrade,animalLabel, customCaseSize);
            foreach (var orderDetail in orderDetails)
            {
                ProduceLabel(labelType, model, orderDetail, true, processDate);
            }
        }

        private void ProduceLabel(OmsLabelType labelType, LabelOutputViewModel model, OrderDetail orderDetail, bool isCustombagLabel,DateTime? processDate)
        {
            model.SerialNumber = GetSerialNumber();
            if (isCustombagLabel)
                model.OrderDetailId = orderDetail.Id;
            model.Printer = SettingsManager.Current.Printer;
            model.LabelFile = SetLabelFile(labelType, orderDetail.Order.Customer, false);
            if (processDate.HasValue)
                model.ProcessDate = processDate.GetValueOrDefault(); 
            CreateLabel(model);
            if (SettingsManager.Current.IsSecondaryLabel)
            {
                model.Printer = SettingsManager.Current.SecondaryPrinter;
                model.LabelFile = SetLabelFile(labelType, orderDetail.Order.Customer, true);
                CreateLabel(model);
            }
        }


        private void CreateLabel(LabelOutputViewModel model)
        {
            var context = new OmsContext();
            _labelRepository = new LabelRepository(context);
            var label = new Label
            {
                OrderDetailId = model.OrderDetailId,
                TypeId = model.Type,
                ItemCode = model.ItemCode,
                LotNumber = model.LotNumber,
                Description = model.Description,
                PoundWeight = model.PoundWeight,
                KilogramWeight = model.KilogramWeight,
                ProcessDate = model.ProcessDate.ToString("d"),
                SlaughterDate = model.SlaughterDate.ToString("d"),
                BestBeforeDate = model.BestBeforeDate,
                SpeciesBugPath = model.SpeciesBugPath,
                LogoPath = model.LogoPath,
                BornIn = model.BornInRegionName,
                RaisedIn = model.RaisedInRegionName,
                ProductOf = model.ProductOfRegionName,
                SlaughteredIn = model.SlaughteredInRegionName,
                DistributedBy = model.DistributedBy,
                GermanDescription = model.GermanDescription,
                FrenchDescription = model.FrenchDescription,
                ItalianDescription = model.ItalianDescription,
                SwedishDescription = model.SwedishDescription,
                IsPrinted = model.IsPrinted,
                CreatedDate = model.WeighedDate,
                LabelFile = model.LabelFile,
                Customer = model.Customer,
                CustomerPO = model.CustomerPO,
                CustomerProductCode = model.CustomerProductCode,
                GradeName = model.GradeName,
                SerialNumber = model.SerialNumber,
                Organic = model.Organic,
                Primal = model.Primal,
                SubPrimal = model.SubPrimal,
                AnimalName = model.AnimalName,
                Species = model.Species,
                Trim = model.Trim,
                Refrigeration = model.Refrigeration,
                PackedFor = model.PackedFor,
                JulianProductionDate = model.JulianProductionDate,
                VarCustomerJobValue = model.VarCustomerJobValue,
                CustomerProductDescription = model.VarCustomerProductValue,
                Gtin = model.Gtin,
                PricePerPound = model.PricePerPound,
                Price = model.Price,
                Printer = model.Printer,
                TareWeight = model.TareWeight,
                NutritionDescription = model.NutritionDescription,
                NutritionServingSize = model.NutritionServingSize,
                NutritionServingContainer = model.NutritionServingContainer,
                NutritionCalories = model.NutritionCalories,
                NutritionCaloriesFat = model.NutritionCaloriesFat,
                NutritionTotalFat = model.NutritionTotalFat,
                NutritionSatFat = model.NutritionSatFat,
                NutritionTransFat = model.NutritionTransFat,
                NutritionPolyFat = model.NutritionPolyFat,
                NutritionMonoFat = model.NutritionMonoFat,
                NutritionCholesterol = model.NutritionCholesterol,
                NutritionSodium = model.NutritionSodium,
                NutritionCarbs = model.NutritionCarbs,
                NutritionProtein = model.NutritionProtein,
                NutritionVitA = model.NutritionVitA,
                NutritionVitC = model.NutritionVitC,
                NutritionCalcium = model.NutritionCalcium,
                NutritionIron = model.NutritionIron,
                CustomerStateCode = model.CustomerStateCode,
                CustomerName = model.CustomerName,
                CustomerPhone = model.CustomerPhone,
                CustomerEmail = model.CustomerEmail,
                CustomerCity = model.CustomerCity,
                CustomerZipCode = model.CustomerZipCode,
                CustomerFax = model.CustomerFax,
                CustomerAddress2 = model.CustomerAddress2,
                CustomerAddress1 = model.CustomerAddress1
                
            };

            Logger.Debug(string.Format("OrderDetailId:{0}; PoundWeight:{1}; KiloWeight:{2}; LabelFile:{3}; LogoPath:{4}; ",
                    label.OrderDetailId,
                    label.PoundWeight,
                    label.KilogramWeight,
                    label.LabelFile,
                    label.LogoPath));

            _labelRepository.Add(label);
            _labelRepository.Save();
            context.Dispose();
        }


        private static decimal GetBoxTareWeight(CaseSize selectedСaseSizeEntity, OrderDetail orderDetail)
        {
            // abs in case when value in db has negative sign
            if (selectedСaseSizeEntity != null)
            {
                return Math.Abs(selectedСaseSizeEntity.TareWeight);
            }
            else
            {
                var customerProductData = orderDetail.Product.CustomerProductData.FirstOrDefault(x => x.CustomerId == orderDetail.Order.CustomerId);
                if (customerProductData != null && orderDetail.Product != null && orderDetail.Product.CustomerProductData != null && orderDetail.Product.CustomerProductData.Any(x => x.CustomerId == orderDetail.Order.CustomerId))
                {
                    if (customerProductData.BoxSizeId.HasValue)
                    {
                        return customerProductData.BoxSizeEntity.TareWeight;
                    }
                }
            }
                return
                    Math.Abs(orderDetail.Product.BoxSizeEntity != null ? orderDetail.Product.BoxSizeEntity.TareWeight : 0);
        }

        private static decimal GetBagTareWeight(CaseSize selectedСaseSizeEntity, OrderDetail orderDetail)
        {
            if (selectedСaseSizeEntity != null)
            {
                return Math.Abs(selectedСaseSizeEntity.TareWeight);
            }
            else
            {
                var customerProductData = orderDetail.Product.CustomerProductData.FirstOrDefault(x => x.CustomerId == orderDetail.Order.CustomerId);
                if (customerProductData != null && orderDetail.Product != null && orderDetail.Product.CustomerProductData != null && orderDetail.Product.CustomerProductData.Any(x => x.CustomerId == orderDetail.Order.CustomerId))
                {
                    if (customerProductData.BagSizeId.HasValue)
                    {
                        return customerProductData.BagSizeEntity.TareWeight;
                    }
                }
            }
            return
               Math.Abs(orderDetail.Product.BagSizeEntity.TareWeight);
        }

        private static double GetTareWeight(CaseSize customCaseSize, OmsLabelType labelType, OrderDetail orderDetail)
        {
            decimal tareWeight;
            switch (labelType)
            {
                // abs in case when value in db has negative sign
                case OmsLabelType.Bag: tareWeight = GetBagTareWeight(customCaseSize, orderDetail); break;
                case OmsLabelType.Box: tareWeight = GetBoxTareWeight(customCaseSize, orderDetail); break;
                default: tareWeight = 0; break;
            }
            return (double)tareWeight;
        }

        public static double GetGrossPoundWeight(double poundWeight, OmsLabelType labelType, OrderDetail orderDetail, CaseSize customCase = null)
        {
            return poundWeight + GetTareWeight(customCase, labelType, orderDetail);
        }

        public static double GetNetPoundWeight(double poundWeight, OmsLabelType labelType, OrderDetail orderDetail, CaseSize customCase = null)
        {
            var tareWeight = GetTareWeight(customCase, labelType, orderDetail);
            poundWeight -= tareWeight;
            return poundWeight < 1000
                ? poundWeight
                : Math.Round(poundWeight, MidpointRounding.AwayFromZero);
        }

        public static double GetCorrectKilogramWeight(double poundWeight)
        {
            return Math.Round(poundWeight*LbsKgConversionFactor, 2, MidpointRounding.AwayFromZero);
        }

        private LabelOutputViewModel GetLabelLayoutViewModel(double poundWeight, OrderDetail orderDetail, OmsLabelType labelType, bool needSetSerialNumber = true, QualityGrade qualityGrade = null, AnimalLabelsViewModel animalLabel = null, CaseSize customCaseSize = null)
        {
            var model = new LabelOutputViewModel();


            model.PoundWeight = GetNetPoundWeight(poundWeight, labelType, orderDetail);
            model.KilogramWeight = GetCorrectKilogramWeight(model.PoundWeight);

            var order = orderDetail.Order;
            var product = orderDetail.Product;
            var customer = order.Customer;

            var productData = GetCustomerProductData(product, order);
            model.CustomerStateCode = orderDetail.CustomerLocation.StateCode;
            model.CustomerAddress1 = orderDetail.CustomerLocation.Address1;
            model.CustomerAddress2 = orderDetail.CustomerLocation.Address2;
            model.CustomerCity = orderDetail.CustomerLocation.City;
            model.CustomerEmail = orderDetail.CustomerLocation.Email;
            model.CustomerFax = orderDetail.CustomerLocation.Fax;
            model.CustomerZipCode = orderDetail.CustomerLocation.ZipCode;
            model.CustomerPhone = orderDetail.CustomerLocation.Phone;
            model.CustomerName = orderDetail.CustomerLocation.Name;
            model.OrderDetailId = orderDetail.Id;
            model.Type = labelType;
            model.ItemCode = product.Upc;
            model.LotNumber = GetLotNumber(order.Id);
            model.Description = product.EnglishDescription;
            model.ProcessDate = order.ProcessDate ?? DateTime.Today;
            model.SlaughterDate = order.SlaughterDate ?? DateTime.Today;
            model.BestBeforeDate = order.BestBeforeDate ?? DateTime.Today.AddDays(45);
            model.SpeciesBugPath = GetSpeciesBugPath(product);
            model.LogoPath = GetLogoPath(customer);
            model.BornInRegionName = order.BornRegion.With(x => x.Name);
            model.RaisedInRegionName = order.RaisedRegion.With(x => x.Name);
            model.ProductOfRegionName = order.ProductOfRegion.With(x => x.Name);
            model.SlaughteredInRegionName = order.SlaughteredRegion.With(x => x.Name);
            model.DistributedBy = customer.DistributedBy;
            model.LabelFile = SetLabelFile(labelType, customer, false);
            model.GermanDescription = product.GermanDescription;
            model.FrenchDescription = product.FrenchDescription;
            model.ItalianDescription = product.ItalianDescription;
            model.SwedishDescription = product.SwedishDescription;
            model.Organic = GetOrganicPath(animalLabel != null && animalLabel.IsOrganic);
            model.SerialNumber = (needSetSerialNumber) ? GetSerialNumber() : null;
            model.JulianProductionDate = DateTime.Now.DayOfYear.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
            model.VarCustomerJobValue = order.AdditionalInfoOnLabel;
            model.AnimalName = animalLabel != null ? animalLabel.Name : "";
            model.Species = (animalLabel != null && animalLabel.Species != null) ? animalLabel.Species.Name : "";
            model.NutritionDescription = product.NutritionDescription;
            model.NutritionServingSize = product.NutritionServingSize;
            model.NutritionServingContainer = product.NutritionServingContainer;
            model.NutritionCalories = product.NutritionCalories;
            model.NutritionCaloriesFat = product.NutritionCaloriesFat;
            model.NutritionTotalFat = product.NutritionTotalFat;
            model.NutritionSatFat = product.NutritionSatFat;
            model.NutritionTransFat = product.NutritionTransFat;
            model.NutritionPolyFat = product.NutritionPolyFat;
            model.NutritionMonoFat = product.NutritionMonoFat;
            model.NutritionCholesterol = product.NutritionCholesterol;
            model.NutritionSodium = product.NutritionSodium;
            model.NutritionCarbs = product.NutritionCarbs;
            model.NutritionProtein = product.NutritionProtein;
            model.NutritionVitA = product.NutritionVitA;
            model.NutritionVitC = product.NutritionVitC;
            model.NutritionCalcium = product.NutritionCalcium;
            model.NutritionIron = product.NutritionIron;

            model.PackedFor = customer.Name;
            model.Refrigeration = order.Refrigeration.Return(x => x.Name);
            model.Trim = product.TrimCut.Return(x => x.Name);
            model.GradeName = qualityGrade != null? qualityGrade.Name: "";

            model.CustomerProductCode = productData == null || productData.ProductCode == null
                ? product.Code
                : productData.ProductCode;
            model.PricePerPound = productData == null || productData.PricePerPound == null
                ? product.PricePerPound
                : productData.PricePerPound;
            model.Price = model.PricePerPound != null
                ? model.PricePerPound.Value * Convert.ToDecimal(model.PoundWeight)
                : (decimal?)null;
            model.Gtin = productData == null || productData.Gtin == null
                ? product.Gtin
                : productData.Gtin.Value;
            model.VarCustomerProductValue = productData == null || productData.ProductDescription == null
                ? null
                : productData.ProductDescription;
            
            model.Customer = customer.Name;
            model.CustomerPO = order.POCustomer;
            model.Printer = SettingsManager.Current.Printer;
            model.WeighedDate = DateTime.Now;

            // todo (alexm): should be checked
            model.TareWeight = labelType==OmsLabelType.Box? GetBoxTareWeight(customCaseSize, orderDetail) : GetBagTareWeight(customCaseSize, orderDetail);
          
            return model;
        }

        private static string GetLogoPath(Customer customer)
        {
            switch (customer.LogoTypeId)
            {
                case OmsLogoType.None:
                    return SettingsManager.Current.NoLogoImageFileName;
                case OmsLogoType.Customer:
                    return customer.LogoFileName ?? SettingsManager.Current.NoLogoImageFileName;
                case OmsLogoType.DoubleJ:
                    return SettingsManager.Current.DoubleJLogoFileName;
                default:
                    return SettingsManager.Current.NoLogoImageFileName;
            }
        }

        private static CustomerProductData GetCustomerProductData(Product product, Order order)
        {
            return product.CustomerProductData.FirstOrDefault(cpc => cpc.CustomerId == order.CustomerId);
        }

        private string GetLotNumber(int orderId)
        {
            var context = new OmsContext();
            _orderRepository = new OrderRepository(context);
            _labelRepository = new LabelRepository(context);
            var order = _orderRepository.Get(orderId);
            if (order.LotNumber != null) return order.LotNumber;
            var year = DateTime.Now.Year;
            var today = year + DateTime.Now.DayOfYear.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
            var max = _labelRepository.Query().Include(x => x.LotNumber)
                .Where(x => x.LotNumber.StartsWith(today))
                .Select(x => x.LotNumber)
                .DefaultIfEmpty(today + "00")
                .Max();

            var lotNumber = (int.Parse(max) + 1).ToString(CultureInfo.InvariantCulture);
            order.LotNumber = lotNumber;
            _orderRepository.Update(order);
            context.Dispose(); 
            return lotNumber;
        }


        private string GetSerialNumber()
        {
            var context = new OmsContext();
            _labelRepository = new LabelRepository(context);
            var today = DateTime.Now.DayOfYear.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
            var max = _labelRepository.Query().Include(x => x.SerialNumber)
                .Where(x => x.SerialNumber.StartsWith(today))
                .Select(x => x.SerialNumber)
                .DefaultIfEmpty(today + "0000")
                .Max();

            var result = (int.Parse(max) + 1).ToString(CultureInfo.InvariantCulture).PadLeft(7, '0');
            context.Dispose();
            return result;
        }

        private bool IsOrganic(Product product)
        {
            return !string.IsNullOrEmpty(product.EnglishDescription) &&
                   product.EnglishDescription.ToLower().Contains("organic");
        }

        private string GetOrganicPath(bool isOrganic)
        {
            return isOrganic
                ? SettingsManager.Current.OrganicFileName
                : SettingsManager.Current.NoLogoImageFileName;
        }

        private string GetSpeciesBugPath(Product product)
        {
            var speciesValue = product.With(x => x.Species).With(x => x.Name);
            if (string.IsNullOrEmpty(speciesValue)) return SettingsManager.Current.NoLogoImageFileName;
            if (speciesValue.ToLowerInvariant().Contains("beef")) return SettingsManager.Current.BeefFileName;
            if (speciesValue.ToLowerInvariant().Contains("bison")) return SettingsManager.Current.BisonFileName;
            return SettingsManager.Current.NoLogoImageFileName;
        }

        private static string SetLabelFile(OmsLabelType labelType, Customer customer, bool isSecondaryLabel)
        {
            const string folderSeparator = "\\";
            string baseDirectory;
            try
            {
                baseDirectory = SettingsManager.Current.LabelBaseFolder;
            }
            catch (Exception)
            {
                baseDirectory = ConfigurationManager.AppSettings["LabelBaseFolder"];
            }

            if (isSecondaryLabel)
                return baseDirectory + SettingsManager.Current.SecondLabel;

            baseDirectory += baseDirectory.Trim().EndsWith(folderSeparator) ? string.Empty : folderSeparator;

            var bagLabel = string.IsNullOrEmpty(customer.BagLabel) ? "bag.lbl" : customer.BagLabel;
            var boxLabel = string.IsNullOrEmpty(customer.BoxLabel) ? "box.lbl" : customer.BoxLabel;
            var trayLabel = string.IsNullOrEmpty(customer.TrayLabel) ? "tray.lbl" : customer.TrayLabel;

            switch (labelType)
            {
                case OmsLabelType.Bag:
                    return string.Format("{0}{1}", baseDirectory, bagLabel);
                case OmsLabelType.Box:
                    return string.Format("{0}{1}", baseDirectory, boxLabel);
                case OmsLabelType.Tray:
                    return string.Format("{0}{1}", baseDirectory, trayLabel);
                default:
                    return string.Empty;
            }
        }
    }
}