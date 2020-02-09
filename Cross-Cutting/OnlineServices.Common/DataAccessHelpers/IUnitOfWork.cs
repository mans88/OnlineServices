using System;

namespace OnlineServices.Common.DataAccessHelpers
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}