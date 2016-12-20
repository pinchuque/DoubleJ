using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Model.Models;

namespace DoubleJ.Oms.Service.Interfaces
{
    public interface IScaleService
    {
        Zq375Scale InitializeScale(int scaleId);
        OmsScaleWeighStatus WeighAndLabel(int orderDetailId, OmsLabelType labelType);
        string GetScaleStatusMessage(OmsScaleWeighStatus status);
    }
}