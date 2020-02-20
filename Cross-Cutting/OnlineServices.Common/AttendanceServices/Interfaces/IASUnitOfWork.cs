using System;
using OnlineServices.Common.DataAccessHelpers;

namespace OnlineServices.Common.AttendanceServices.Interfaces
{
    public interface IASUnitOfWork : IUnitOfWork
    {
        ICheckInRepository ChekInRepository { get; }
    }
}