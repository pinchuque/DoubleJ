using DoubleJ.Oms.Model.ViewModels.Internal;

namespace DoubleJ.Oms.Service.Interfaces
{
    public interface IOrderReportService
    {
        OrderReportViewModel Get(int orderId);
    }
}
