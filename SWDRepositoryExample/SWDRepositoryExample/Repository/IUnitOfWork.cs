using System;
using SWDRepositoryExample.Database;

namespace SWDRepositoryExample.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        void Dispose();
    }
}