using AttendanceServices.DataLayer;

namespace OnlineServices.Common.MealServices.Interfaces
{
    public interface IMSUnitOfWork : IUnitOfWork
    {
        IMealRepository MealRepository { get; }
        ISupplierRepository SupplierRepository { get; }
    }
}