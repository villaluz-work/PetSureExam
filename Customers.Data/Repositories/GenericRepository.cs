﻿using Customers.Data.Interface;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Customers.Data.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbSet<T> dbSet;
        private readonly CustomerContext _ctx;
        public GenericRepository(CustomerContext ctx)
        {
            _ctx = ctx;
            dbSet = _ctx.Set<T>();
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
            _ctx.Entry(entity).State = EntityState.Modified;
        }
        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public int Save()
        {
            return _ctx.SaveChanges();
        }

        
    }
}
