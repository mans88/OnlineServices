using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.MealServices.TransfertObjects;

namespace OnlineServices.Common.MealServices.Interfaces
{
    public interface ISupplierRepository2 : IRepositoryDO_NOT_USE<SupplierTO, int>
    {
        SupplierTO GetDefaultSupplier();
        void SetDefaultSupplier(SupplierTO Supplier);
    }
}
