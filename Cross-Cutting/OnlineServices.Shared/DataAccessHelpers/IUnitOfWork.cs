using AttendanceServices.BusinessLayer.UseCases;
using System;

namespace AttendanceServices.DataLayer
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
}