using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace SWDRepositoryExample.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext Context;
        public Repository(DbContext dbContext)
        {
            if(dbContext == null) throw new ArgumentNullException(nameof(dbContext));
            Context = dbContext;
        }
        public T Insert(T entity)
        {
            if(entity == null) throw new ArgumentNullException(nameof(entity));
            return Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Context.Set<T>().Attach(entity);
            Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }
    }
}