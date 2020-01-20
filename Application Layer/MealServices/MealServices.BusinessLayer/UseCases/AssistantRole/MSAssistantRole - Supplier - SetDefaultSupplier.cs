using MealServices.BusinessLayer.Extensions;

using OnlineServices.Common.MealServices.TransfertObjects;

using System;

namespace MealServices.BusinessLayer.UseCases
{
    public partial class MSAssistantRole
    {
        public bool SetDefaultSupplier(SupplierTO Supplier)
        {
            if (Supplier is null)
                throw new ArgumentNullException(nameof(Supplier));

            if (Supplier.Id == 0)
                throw new Exception("Inexisting supplier");

            if (!Supplier.IsDefault)
                throw new Exception("Supplier not marked as current supplier.");

            try
            {
                iMSUnitOfWork.SupplierRepository.SetDefaultSupplier(Supplier.ToDomain().ToTransfertObject());

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
