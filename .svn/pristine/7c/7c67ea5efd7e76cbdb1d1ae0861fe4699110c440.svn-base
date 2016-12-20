using System;
using System.Collections.Generic;
using System.Linq;
using DoubleJ.Oms.Domain.Entities;

namespace DoubleJ.Oms.Model.Interfaces
{
    public interface IGenericRepository<T> : IDisposable where T : class, IEntity
    {
        T Get(int id);
        IQueryable<T> Query();
        
        IEnumerable<T> GetAll();
        IEnumerable<T> FindAll(Func<T, bool> predicate);
        IEnumerable<T> FindAndSort<TKey>(Func<T, TKey> order);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        void Save();
        void Detach(T entity);
        void AddRange(IEnumerable<T> entity);
    }
}
