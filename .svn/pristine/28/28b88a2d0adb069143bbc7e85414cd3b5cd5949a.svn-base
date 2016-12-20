using System.Collections.Generic;
using DoubleJ.Oms.Domain.Definitions;
using DoubleJ.Oms.Model.Models;
using DoubleJ.Oms.Model.ViewModels.Internal;

namespace DoubleJ.Oms.Service.Interfaces
{
    public interface IOrderService
    {
        OrderViewModel Get();
        OrderViewModel Get(int orderId);
        int Add(OrderViewModel model);
        void Edit(OrderViewModel model);
        CustomerPreferenceViewModel GetCustomerPreferences(int? customerId);
        List<CheckBoxItem> GetCustomerLocations(int? customerId);
        void SetStatus(OmsStatus status);
        void SetStatus(int orderId, OmsStatus status);

       
    }
}