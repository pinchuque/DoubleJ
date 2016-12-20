using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;


namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class ColdWeightEntryModel
    {
        [Display(Name = "Order")]
        [Required]
        public int? OrderId { get; set; }

        [Display(Name = "Owner")]
        public string Customer { get; set; }

        [Display(Name = "Head Expected")]
        [Required]
        public int HeadExpected { get; set; }

        [Display(Name = "Head Received")]
        public int? HeadReceived { get; set; }

        [Display(Name = "Head Processed")]
        public int? HeadProcessed { get; set; }

        [Display(Name = "Quality Grade")]
        public int? QualityGradeId { get; set; }

        [Display(Name = "Cold Weight")]
        [Range(0, double.MaxValue)]
        public double? ColdWeight { get; set; }

        [Display(Name = "Count Received")]
        public int TotalCount { get; set; }

        [Display(Name = "Total Weight Entered")]
        [DisplayFormat(DataFormatString = "{0} LBS")]
        public decimal TotalWeight { get; set; }

        [Display(Name = "Animal Number")]
        public string AnimalNumber { get; set; }

        [Display(Name = "Ear Tag")]
        public string EarTag { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        [Display(Name = "Orders Status")]
        public int StatusId { get; set; }

        public IEnumerable<OmsStatus> OrderStatuses { get; set; }

        [Display(Name = "Section")]
        public ColdWeightSections Section { get; set; }
    }

    public enum ColdWeightSections
    {
        Halves = 1,
        Quarters,
    }
    public class ColdWeightEntryDetailItem
    {
        public OmsEntryMode OmsEntryMode { get; set; }
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ColdWeightId { get; set; }

        [Display(Name = "Quality Grade")]
        [UIHint("QualityGradesEditor")]
        public QualityGrade QualityGrade { get; set; }
        public int Rank { get; set; }

        [Display(Name = "Animal Number")]
        public string AnimalNumber { get; set; }

        [Display(Name = "Ear Tag")]
        public string EarTag { get; set; }

        [UIHint("OwnerCustomerTemplate")]
        public OrderDetailCustomerLocationItem FirstCustomer { get; set; }

        [UIHint("OwnerCustomerTemplate")]
        public OrderDetailCustomerLocationItem SecondCustomer { get; set; }

        [UIHint("OwnerCustomerTemplate")]
        public OrderDetailCustomerLocationItem ThirdCustomer { get; set; }

        [UIHint("OwnerCustomerTemplate")]
        public OrderDetailCustomerLocationItem FourthCustomer { get; set; }
        

        [Display(Name = "Hot Weight")]
        [Required]
        public decimal HotWeight { get; set; }

        [Display(Name = "Organic")]
        public bool Organic { get; set; }

        [Display(Name = "Organic")]
        public bool IsOrganic { get; set; }

        [Display(Name = "Cold Weight")]
        [Required]
        public decimal ColdWeight { get; set; }

        [Display(Name = "Start Number")]
        [Required]
        [Range(1, Int32.MaxValue)]
        public int? StartNumber { get; set; }

        [Display(Name = "End Number")]
        [Range(1, Int32.MaxValue)]
        public int? EndNumber { get; set; }

        [Display(Name = "Customer")]
        [Required(ErrorMessage = "Need at least a one customer")]
        public OrderDetailCustomerLocationItem CustomerLocationID { get; set; }
        [UIHint("AnimalLabelsTemplate")]
        public AnimalLabelsViewModel AnimalLabel { get; set; }
        [DisplayName("Species")]
        public int? AnimalLabelId { get; set; }
        public SelectList CustomerLocations { get; set; }
        public SelectList SpeciesList { get; set; }

        public SelectList QualityGradeList { get; set; }

        [DisplayName("Default Grade")]
        public QualityGrade QualityGradeId { get; set; }
        [Display(Name = "Track Animal By")]
        public TrackAnimal TrackAnimalBy { get; set; }

        [Display(Name = "Sectioning")]
        [UIHint("TrackAnimalByEditor")]
        public TrackAnimal TrackAnimalBySelectColumn { get; set; }

        public bool IsEditable { get; set; }
        public bool IsExist { get; set; }

        public ColdWeightEntryDetailItem()
        {
            QualityGrade = new QualityGrade()
            {
                Id = 0,
                Name = "Ungraded",
                SortOrder = 1
            };
            IsEditable = true;
        }
    }

    public class ColdWeightSpeciesModel : IComparable
    {
        public int LabelId { get; set; }

        public string SpeciesName { get; set; }

        public int CompareTo(object obj)
        {
            return String.Compare(SpeciesName, ((ColdWeightSpeciesModel)obj).SpeciesName, StringComparison.Ordinal);
        }
    }

    public class ColdWeightStatusModel
    {
        [Display(Name = "Orders Status")]
        public int StatusId { get; set; }

        public int? OrderId { get; set; }
    }
}
