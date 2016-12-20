using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using DoubleJ.Oms.Domain;
using DoubleJ.Oms.Domain.Entities;
using DoubleJ.Oms.Model.Interfaces;

namespace DoubleJ.Oms.Model.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        public GenericRepository(IOmsContext context)
        {
            Context = context;
        }

        public IOmsContext Context { get; private set; }


        public virtual T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public IQueryable<T> Query()
        {
            return Context.Set<T>().AsQueryable();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().AsEnumerable();
        }

        public virtual IEnumerable<T> FindAll(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public virtual IEnumerable<T> FindAndSort<TKey>(Func<T, TKey> order)
        {
            return Context.Set<T>().OrderBy(order);
        }

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entity)
        {
            Context.Set<T>().AddRange(entity);
        }

        public virtual void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public virtual void Detach(T entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
        }
    }
}