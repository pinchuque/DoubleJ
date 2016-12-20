using System.ComponentModel;

using DoubleJ.Oms.Model.ViewModels.Internal;


namespace DoubleJ.Oms.LabelManager.Models
{
    public class EditLabelsViewModel
    {
        public EditLabelsViewModel()
        {
            Labels = new BindingList<LabelEditItem>();
            OrderSummary = new OrderSummaryViewModel();
        }

        public int OrderId { get; set; }

        public BindingList<LabelEditItem> Labels { get; set; }

        public OrderSummaryViewModel OrderSummary { get; set; }
    }
}