namespace OnlineServices.Common.MealServices.Interfaces
{
    public interface IMSUnitOfWork
    {
        IMealRepository MealRepository { get; }
        ISupplierRepository SupplierRepository { get; }

        void Dispose();
        void Save();
    }
}