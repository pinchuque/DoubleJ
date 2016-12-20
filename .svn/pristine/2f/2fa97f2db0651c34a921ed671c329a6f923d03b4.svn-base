using System.Web.Mvc;
using DoubleJ.Oms.Model.ViewModels;
using DoubleJ.Oms.Service.Services;
using MuscovyTechnology.Mvc.Notification;
using Ninject;

namespace DoubleJ.Oms.Web.Controllers
{
    public class AccountController : Controller
    {
        [Inject]
        public AccountService AccountService { get; set; }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (AccountService.IsValidLogin(viewModel))
                {
                    return RedirectToAction("Index", "Orders", new {area = "Internal"});
                }
                ModelState.AddModelError("", "");
            }
            return View();
        }

        public PartialViewResult _Greeting()
        {
            return PartialView(AccountService.GetGreeting(SessionService.Get().User.FullName));
        }

        public ActionResult Logout()
        {
            AccountService.LogOut();
            this.ShowNotification(NotificationType.Success, "You have been successfully logged out.", true);
            return RedirectToAction("Login");
        }
    }
}