using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using DoubleJ.Oms.Model.Definitions;
using DoubleJ.Oms.Model.Entities;
using DoubleJ.Oms.Model.Extensions;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.Models;
using DoubleJ.Oms.Service.Interfaces;
using DoubleJ.Oms.Settings;
using NLog;

namespace DoubleJ.Oms.Service.Services.Device
{
    public class LabelService : IDeviceLabelService
    {
        public const double LbsKgConversionFactor = .4536;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ILabelRepository _labelRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        public LabelService(ILabelRepository labelRepository, IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository, ICustomerRepository customerRepository)
        {
            _labelRepository = labelRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _customerRepository = customerRepository;
        }

        public int ProduceLabel(int orderDetailId, ScaleWeight weight, OmsLabelType labelType)
        {
            return ProduceLabel(orderDetailId, weight.Gross, labelType);
        }

        public int ProduceLabel(int orderDetailId, double poundWeight, OmsLabelType labelType)
        {
            var viewModel = GetLabelLayoutViewModel(orderDetailId, labelType);
            viewModel.PoundWeight = poundWeight < 1000
                ? poundWeight
                : Math.Round(poundWeight, MidpointRounding.AwayFromZero);
            viewModel.KilogramWeight = Math.Round(viewModel.PoundWeight*LbsKgConversionFactor, 2,
                MidpointRounding.AwayFromZero);
            return CreateLabel(viewModel);
        }

        private int CreateLabel(LabelOutputViewModel model)
        {
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
                DistributedBy = model.DistributedBy,
                GermanDescription = model.GermanDescription,
                FrenchDescription = model.FrenchDescription,
                ItalianDescription = model.ItalianDescription,
                SwedishDescription = model.SwedishDescription,
                IsPrinted = model.IsPrinted,
                CreatedDate = model.WeighedDate,
                LabelFile = model.LabelFile,
                Customer = model.Customer,
                CustomerProductCode = model.CustomerProductCode,
                GradeName = model.GradeName,
                SerialNumber = model.SerialNumber,
                Organic = model.Organic,
                Primal = model.Primal,
                SubPrimal = model.SubPrimal,
                Trim = model.Trim,
                Refrigeration = model.Refrigeration,
                PackedFor = model.PackedFor,
                VarCustomerJobValue = model.VarCustomerJobValue,
                CustomerProductDescription = model.VarCustomerProductValue
            };

            Logger.Debug(
                string.Format("OrderDetailId:{0}; PoundWeight:{1}; KiloWeight:{2}; LabelFile:{3}; LogoPath:{4}; ",
                    label.OrderDetailId, label.PoundWeight, label.KilogramWeight, label.LabelFile,
                    label.LogoPath));
            _labelRepository.Add(label);
            _labelRepository.Save();
            return label.Id;
        }

        private LabelOutputViewModel GetLabelLayoutViewModel(int orderDetailId, OmsLabelType labelType)
        {
            var orderDetail = _orderDetailRepository.Get(orderDetailId);
            var order = orderDetail.Order;
            var product = orderDetail.Product;
            _customerRepository.Detach(order.Customer);
            var customer = order.Customer;

            var model = new LabelOutputViewModel();
            var customerProductCode = product.CustomerProductCode.FirstOrDefault(cpc => cpc.CustomerId == orderDetail.Order.CustomerId);

            model.OrderDetailId = orderDetailId;
            model.Type = labelType;
            model.ItemCode = product.Upc;
            model.LotNumber = GetLotNumber(order);
            model.Description = product.Description;
            model.ProcessDate = order.ProcessDate ?? DateTime.Today;
            model.SlaughterDate = order.SlaughterDate ?? DateTime.Today;
            model.BestBeforeDate = order.BestBeforeDate;
            model.SpeciesBugPath = GetSpeciesBugPath(product);

            switch (customer.LogoTypeId)
            {
                case OmsLogoType.None:
                    model.LogoPath = SettingsManager.Current.NoLogoImageFileName;
                    break;
                case OmsLogoType.Customer:
                    model.LogoPath = customer.LogoFileName ?? SettingsManager.Current.NoLogoImageFileName;
                    break;
                case OmsLogoType.DoubleJ:
                    model.LogoPath = SettingsManager.Current.DoubleJLogoFileName;
                    break;
                default:
                    throw new IndexOutOfRangeException("Order.LogoTypeId");
            }
            model.BornInRegionName = order.BornRegion.With(x => x.Name);
            model.RaisedInRegionName = order.RaisedRegion.With(x => x.Name);
            model.ProductOfRegionName = order.ProductOfRegion.With(x => x.Name);
            model.DistributedBy = customer.DistributedBy;

            model.LabelFile = SetLabelFile(labelType, customer);
            model.GermanDescription = product.GermanDescription;
            model.FrenchDescription = product.FrenchDescription;
            model.ItalianDescription = product.ItalianDescription;
            model.SwedishDescription = product.SwedishDescription;

            model.Organic = GetOrganicPath(product);
            model.SerialNumber = GetSerialNumber();
            model.VarCustomerJobValue = order.AdditionalInfoOnLabel;

            model.Primal = product.PrimalCut.Return(x => x.Name);
            model.SubPrimal = product.SubPrimalCut.Return(x => x.Name);
            model.PackedFor = customer.Name;
            model.Refrigeration = order.Refrigeration.Return(x => x.Name);
            model.Trim = product.TrimCut.Return(x => x.Name);
            model.GradeName = product.QualityGrade.Return(x => x.Name);

            model.CustomerProductCode = customerProductCode == null || customerProductCode.ProductCode == null
                ? product.Code
                : customerProductCode.ProductCode;

            model.VarCustomerProductValue = customerProductCode == null || customerProductCode.ProductDescription == null
                ? null
                : customerProductCode.ProductDescription;

            model.Customer = customer.Name;

            model.WeighedDate = DateTime.Now;
            return model;
        }

        private string GetLotNumber(Order order)
        {
            if (order.LotNumber != null) return order.LotNumber;
            var year = DateTime.Now.Year;
            var today = year + DateTime.Now.DayOfYear.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
            var max =
                _labelRepository.GetAll()
                    .Where(x => x.LotNumber.StartsWith(today))
                    .Select(x => x.LotNumber)
                    .DefaultIfEmpty(today + "00")
                    .Max();
            var lotNumber = (int.Parse(max) + 1).ToString(CultureInfo.InvariantCulture);
            order.LotNumber = lotNumber;
            _orderRepository.Update(order);
            return lotNumber;
        }

        private string GetSerialNumber()
        {
            var today = DateTime.Now.DayOfYear.ToString(CultureInfo.InvariantCulture).PadLeft(3, '0');
            var max =
                _labelRepository.GetAll()
                    .Where(x => x.SerialNumber.StartsWith(today))
                    .Select(x => x.SerialNumber)
                    .DefaultIfEmpty(today + "0000")
                    .Max();
            var serial = (int.Parse(max) + 1).ToString(CultureInfo.InvariantCulture).PadLeft(7, '0');

            return serial;
        }

        private bool IsOrganic(Product product)
        {
            return !string.IsNullOrEmpty(product.Description) && product.Description.Contains("organic");
        }

        private string GetOrganicPath(Product product)
        {
            return IsOrganic(product)
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

        private static string SetLabelFile(OmsLabelType labelType, Customer customer)
        {
            const string folderSeparator = "\\";
            var baseDirectory = ConfigurationManager.AppSettings["LabelBaseFolder"].Trim();
            baseDirectory += baseDirectory.EndsWith(folderSeparator) ? string.Empty : folderSeparator;

            var bagLabel = string.IsNullOrEmpty(customer.BagLabel) ? "bag.lbl" : customer.BagLabel;
            var boxLabel = string.IsNullOrEmpty(customer.BoxLabel) ? "box.lbl" : customer.BoxLabel;

            switch (labelType)
            {
                case OmsLabelType.Bag:
                    return string.Format("{0}{1}", baseDirectory, bagLabel);
                case OmsLabelType.Box:
                    return string.Format("{0}{1}", baseDirectory, boxLabel);
                default:
                    return string.Empty;
            }
        }
    }
}