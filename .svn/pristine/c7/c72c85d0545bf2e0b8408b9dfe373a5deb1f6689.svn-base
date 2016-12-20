using System.Globalization;
using System.Web.Security;

using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;
using DoubleJ.Oms.Model.ViewModels;
using DoubleJ.Oms.Service.Interfaces;


namespace DoubleJ.Oms.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region Login

        public bool IsValidLogin(LoginViewModel loginViewModel)
        {
            var user = Authenticate(loginViewModel.Email, loginViewModel.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Id.ToString(CultureInfo.InvariantCulture), false);
                SessionService.Add(user);
            }

            return user != null;
        }

        private User Authenticate(string userCode, string password)
        {
            var user = _userRepository.GetByEmail(userCode);
            if (user == null) return null;

            return user.Password == password ? user : null;
        }

        #endregion

        #region Logout

        public void LogOut()
        {
            FormsAuthentication.SignOut();
            SessionService.End();
        }

        #endregion

        #region Greeting

        public GreetingViewModel GetGreeting(string userFullName)
        {
            return new GreetingViewModel {GreetingName = userFullName};
        }

        #endregion
    }
}