using System;
using System.Data.Entity;
using SWDRepositoryExample.Database;

namespace SWDRepositoryExample.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext DbContext;
        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
            
        }
        public void Dispose()
        {
            DbContext.Dispose();
        }
        public int Complete()
        {
            return DbContext.SaveChanges();
        }
    }
}