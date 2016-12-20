using System.Web;
using System.Web.Mvc;
using DoubleJ.Oms.Service.ActionFilters;
using MuscovyTechnology.Mvc.Notification;

namespace DoubleJ.Oms.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Elmah already adds this
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new AjaxNotificationsFilter());
            filters.Add(new OmsSessionAttribute());
        }
    }
}