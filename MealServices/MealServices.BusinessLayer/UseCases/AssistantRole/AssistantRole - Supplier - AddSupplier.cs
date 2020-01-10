using MealServices.BusinessLayer.Extensions;

using OnlineServices.Common.MealServices.TransfertObjects;

using System;

namespace MealServices.BusinessLayer.UseCases
{
    public partial class AssistantRole
    {
        public bool AddSupplier(SupplierTO Supplier)
        {
            if (Supplier is null)
                throw new ArgumentNullException(nameof(Supplier));

            if (Supplier.Id != 0)
                throw new Exception("Existing supplier");

            try
            {

                iMSUnitOfWork.SupplierRepository.Add(Supplier.ToDomain().ToTransfertObject());

                if (Supplier.IsDefault)
                    iMSUnitOfWork.SupplierRepository.SetDefaultSupplier(Supplier.ToDomain().ToTransfertObject());

                return true;
            }

            //TODO Code to test Unique Constraint on Name...
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
