using MealServices.BusinessLayer.Extensions;

using OnlineServices.Common.MealServices.TransfertObjects;

using System;

namespace MealServices.BusinessLayer.UseCases
{
    public partial class AssistantRole
    {
        public bool UpdateSupplier(SupplierTO Supplier)
        {
            try
            {
                if (Supplier is null)
                    throw new ArgumentNullException(nameof(Supplier));

                if (Supplier.Id == 0)
                    throw new Exception("Inexisting supplier");

                iMSUnitOfWork.SupplierRepository.Update(Supplier.ToDomain().ToTransfertObject());

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
