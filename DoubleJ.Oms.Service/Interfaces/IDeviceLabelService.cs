using DoubleJ.Oms.Model.Definitions;
using DoubleJ.Oms.Model.Models;

namespace DoubleJ.Oms.Service.Interfaces
{
    public interface IDeviceLabelService
    {
        int ProduceLabel(int orderDetailId, ScaleWeight weight, OmsLabelType labelType);
        int ProduceLabel(int orderDetailId, double poundWeight, OmsLabelType labelType);
    }
}