using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class TareWeightViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Side")]
        public CustomerTypeViewModel CustomerType { get; set; }

        [DisplayName("Type")]
        public CaseTypeViewModel CaseType { get; set; }

        [DisplayName("Tare Weight")]
        [UIHint("BagTare")]
        [Required]
        public decimal TareWeight_ { get; set; }
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }
    }

    public class AdminReportsViewModel
    {
        public int SideId { get; set; }
        public DateTime Date { get; set; }
    }
}