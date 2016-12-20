using System.Collections.Generic;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetAllActive();
        User GetByEmail(string email);
    }
}