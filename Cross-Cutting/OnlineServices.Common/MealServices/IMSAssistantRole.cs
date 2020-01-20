using OnlineServices.Common.MealServices.TransfertObjects;

using System.Collections.Generic;

namespace OnlineServices.Common.MealServices
{
    public interface IMSAssistantRole
    {
        //IMSUnitOfWork iUnitOfWork { get; }

        bool AddSupplier(SupplierTO Supplier);
        SupplierTO GetDefaultSupplier();
        List<SupplierTO> GetSuppliers();
        bool RemoveSupplier(SupplierTO Supplier);
        bool SetDefaultSupplier(SupplierTO Supplier);
        bool UpdateSupplier(SupplierTO Supplier);
    }
}