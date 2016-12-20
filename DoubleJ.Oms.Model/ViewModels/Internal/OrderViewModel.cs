using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
        }

        public OrderViewModel(Order order)
        {
            Id = order.Id;
            CustomerId = order.CustomerId;
            POCustomer = order.POCustomer;
            StatusId = order.StatusId;
            RequestedProcessDate = order.RequestedProcessDate;
            ReceiveDate = order.ReceiveDate;
            SlaughterDate = order.SlaughterDate;
            ProcessDate = order.ProcessDate;
            ExpectedHeadNumber = order.ExpectedHeadNumber;
            ReceivedHeadNumber = order.ReceivedHeadNumber;
            SlaughteredHeadNumber = order.SlaughteredHeadNumber;
            BestBeforeDate = order.BestBeforeDate;
            BornRegionId = order.BornRegionId;
            RaisedRegionId = order.RaisedRegionId;
            SlaughteredRegionId = order.SlaughteredRegionId;
            ProductOfRegionId = order.ProductOfRegionId;
            SpecialInstructions = order.SpecialInstructions;
            CustomerComments = order.CustomerComments;
            RefrigerationId = order.RefrigerationId;
            AdditionalInfo = order.AdditionalInfoOnLabel;
            BagSuppres = !order.BagEnable;

            if (order.QualityGradeId.HasValue)
                QualityGradeId = order.QualityGradeId;

            if (order.Customer != null)
                IsFabOwner = order.Customer.CustomerTypeId == OmsCustomerType.Fabrication;
        }

        public int? Id { get; set; }

        [DisplayName("Owner"), Required(ErrorMessage = "required")]
        public int CustomerId { get; set; }

        [DisplayName("Owner PO")]
        [MaxLength(50)]
        public string POCustomer { get; set; }

        [DisplayName("Status")]
        public OmsStatus StatusId { get; set; }

        [DisplayName("Requested Process")]
        public DateTime? RequestedProcessDate { get; set; }

        [DisplayName("Received")]
        public DateTime? ReceiveDate { get; set; }

        [DisplayName("Slaughter")]
        public DateTime? SlaughterDate { get; set; }

        [DisplayName("Process")]
        public DateTime? ProcessDate { get; set; }

        [DisplayName("Expected")]
        public int? ExpectedHeadNumber { get; set; }

        [DisplayName("Received")]
        public int? ReceivedHeadNumber { get; set; }

        [DisplayName("Slaughtered")]
        public int? SlaughteredHeadNumber { get; set; }

        [DisplayName("Best Before Date"), Required(ErrorMessage = "required")]
        public DateTime? BestBeforeDate { get; set; }

        [DisplayName("Born In")]
        public int? BornRegionId { get; set; }

        [DisplayName("Raised In")]
        public int? RaisedRegionId { get; set; }

        [DisplayName("Slaughtered In")]
        public int? SlaughteredRegionId { get; set; }

        [DisplayName("Product Of")]
        public int? ProductOfRegionId { get; set; }

        [DisplayName("Special Instructions")]
        public string SpecialInstructions { get; set; }

        [DisplayName("Owner Comments")]
        public string CustomerComments { get; set; }

        [DisplayName("Refrigeration")]
        public int? RefrigerationId { get; set; }

        [ScaffoldColumn(false)]
        public int? CloneDetails { get; set; }

        [MaxLength(20)]
        [DisplayName("ADDL INFO ON LABEL")]
        public string AdditionalInfo { get; set; }

        [Required]
        [DisplayName("Suppress Bag Labelling")]
        public bool BagSuppres { get; set; }

        [DisplayName("Quality Grade")]
        public int? QualityGradeId { get; set; }

        public int? CustomerBestBeforeDays { get; set; }

        public bool IsFabOwner { get; set; }

        public void UpdateEntity(Order order)
        {
            order.CustomerId = CustomerId;
            order.POCustomer = POCustomer;
            order.StatusId = StatusId;
            order.RequestedProcessDate = Convert.ToDateTime(RequestedProcessDate);
            order.ReceiveDate = ReceiveDate;
            order.SlaughterDate = SlaughterDate;
            order.ProcessDate = ProcessDate;
            order.ExpectedHeadNumber = Convert.ToInt32(ExpectedHeadNumber);
            order.ReceivedHeadNumber = ReceivedHeadNumber;
            order.SlaughteredHeadNumber = SlaughteredHeadNumber;
            order.BestBeforeDate = BestBeforeDate;
            order.BornRegionId = BornRegionId;
            order.RaisedRegionId = RaisedRegionId;
            order.SlaughteredRegionId = SlaughteredRegionId;
            order.ProductOfRegionId = ProductOfRegionId;
            order.CreatedDate = DateTime.Now;
            order.CustomerComments = CustomerComments;
            order.SpecialInstructions = SpecialInstructions;
            order.RefrigerationId = RefrigerationId;
            order.AdditionalInfoOnLabel = AdditionalInfo;
            order.BagEnable = !BagSuppres;
            order.QualityGradeId = QualityGradeId;
        }

        public SelectList Customers { get; set; }
        public SelectList Statuses { get; set; }
    }
}