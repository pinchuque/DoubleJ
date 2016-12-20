using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using DoubleJ.Oms.Service.Services;


namespace DoubleJ.Oms.Service.ActionFilters
{
    public class OmsSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);
            if (skipAuthorization) return;

            var context = filterContext.HttpContext;
            if (!context.User.Identity.IsAuthenticated)
            {
                SessionService.End();
                filterContext.Result = GetResult(context);
            }
            else if (context.Session != null)
            {
                if (context.Session.IsNewSession)
                {
                    var sessionCookie = context.Request.Headers["Cookie"];
                    if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        FormsAuthentication.SignOut();
                        filterContext.Result = GetResult(context);
                    }
                }
            }

            base.OnActionExecuting(filterContext);
        }

        private static ActionResult GetResult(HttpContextBase context)
        {
            var redirectTo = "~/Account/Login";
            if (context.Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = new
                    {
                        LogonRequired = true,
                        Url = VirtualPathUtility.ToAbsolute(redirectTo)
                    }
                };
            }

            if (!string.IsNullOrEmpty(context.Request.RawUrl))
            {
                redirectTo = string.Format("~/Account/Login?ReturnUrl={0}", HttpUtility.UrlEncode(context.Request.RawUrl));
            }

            return new RedirectResult(redirectTo);
        }
    }
}