using Customers.Data.Interface;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Customers.Data.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbSet<T> dbSet;
        private CustomerContext ctx = new CustomerContext();

        public GenericRepository()
        {
            dbSet = ctx.Set<T>();
        }
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }   

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(T entity)
        {
            ctx.Entry(entity).State = EntityState.Modified;
        }

        public int Save()
        {
            return ctx.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
    }
}
