using DoubleJ.Oms.Model.ViewModels;

namespace DoubleJ.Oms.Service.Interfaces
{
    public interface IAccountService
    {
        bool IsValidLogin(LoginViewModel loginViewModel);
        void LogOut();
        GreetingViewModel GetGreeting(string userFullName);
    }
}
