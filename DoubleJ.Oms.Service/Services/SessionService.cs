using System.Web;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Models;

namespace DoubleJ.Oms.Service.Services
{
    public static class SessionService
    {
        public static SessionUser Get()
        {
            return SessionUser.Current;
        }

        public static void Add(User user)
        {
            SessionUser.Current.User = user;
        }

        public static void End()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}