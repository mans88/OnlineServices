using System;
using OnlineServices.Common.DataAccessHelpers;

namespace OnlineServices.AttendanceServices.Interfaces
{
    public interface IASUnitOfWork : IUnitOfWork
    {
        ICheckInRepository ChekInRepository { get; }
    }
}