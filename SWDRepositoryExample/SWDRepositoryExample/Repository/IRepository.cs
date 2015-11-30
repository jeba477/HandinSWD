using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SWDRepositoryExample.Repository
{
    public interface IRepository<T>
    {
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void InsertRange(IEnumerable<T> entities);
    }
}