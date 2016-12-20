using System;
using System.Collections.Generic;
using System.Web;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.ViewModels.Internal;

namespace DoubleJ.Oms.Model.Models
{
    [Serializable]
    public sealed class SessionUser
    {
        private const string SessionContainer = "DOUBLEJ_OMS_SESSION_CONTAINER";

        public SessionUser()
        {
            CustomerSearchViewModel = new CustomerSearchViewModel();
            OrderSearchViewModel = new OrderSearchViewModel();
            ProductSearchViewModel = new ProductSearchViewModel();
        }

        public User User { get; set; }
        public IList<OrderDetailItem> OrderDetailItems { get; set; }
        public Zq375Scale BagScale { get; set; }


        public ProductSearchViewModel ProductSearchViewModel { get; set; }

        public OrderSearchViewModel OrderSearchViewModel { get; set; }

        public CustomerSearchViewModel CustomerSearchViewModel { get; set; }

        public CustomerViewModel CustomerViewModel { get; set; }

        public static SessionUser Current
        {
            get
            {
                HttpContext context = HttpContext.Current;
                var user = context.Session[SessionContainer] as SessionUser;
                if (user != null) return user;
                user = new SessionUser();
                context.Session[SessionContainer] = user;
                return user;
            }
        }
    }
}