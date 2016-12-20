using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class CustomerSearchViewModel : SearchViewModel
    {
        [DisplayName("owner name")]
        public string Name { get; set; }

        [DisplayName("order number")]
        public int? Order { get; set; }

        [DisplayName("product code")]
        public string Product { get; set; }

        [DisplayName("owner type")]
        public OmsCustomerType? CustomerType { get; set; }

        [UIHint("CaseType")]
        public CaseType CaseType { get; set; }
    }
}