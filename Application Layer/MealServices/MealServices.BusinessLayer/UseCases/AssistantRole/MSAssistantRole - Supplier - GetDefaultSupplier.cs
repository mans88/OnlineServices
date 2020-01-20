using MealServices.BusinessLayer.Extensions;

using OnlineServices.Common.MealServices.TransfertObjects;

using System;
using System.Linq;

namespace MealServices.BusinessLayer.UseCases
{
    public partial class MSAssistantRole
    {
        public SupplierTO GetDefaultSupplier()
        {
            if (GetSuppliers().Count(x => x.IsDefault == true) != 1)
                throw new Exception($"GetDefaultSupplier(). Default Supplier not well configured in DB");

            return iMSUnitOfWork.SupplierRepository
                    .GetDefaultSupplier()
                    .ToDomain().ToTransfertObject();
        }
    }
}
