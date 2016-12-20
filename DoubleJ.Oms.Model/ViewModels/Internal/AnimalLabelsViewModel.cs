using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class AnimalLabelsViewModel : IComparable
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Type")]
        public SpeciesViewModel Species{ get; set; }

        [DisplayName("Organic")]
        public bool IsOrganic{ get; set; }

        public int CompareTo(object obj)
        {
            return String.Compare(Name, ((AnimalLabel)obj).Name, StringComparison.Ordinal);
        }
    }
}