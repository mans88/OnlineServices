using MealServices.BusinessLayer.Extensions;

using OnlineServices.Common.MealServices.TransfertObjects;

using System.Collections.Generic;
using System.Linq;

namespace MealServices.BusinessLayer.UseCases
{
    public partial class MSAttendeeRole
    {
        public List<MealTO> GetMenu()
        {
            var Supplier = iMSUnitOfWork.SupplierRepository.GetDefaultSupplier();

            return iMSUnitOfWork.MealRepository
                    .GetMealsBySupplier(Supplier)
                    .Select(x => x.ToDomain().ToTransfertObject())
                     .ToList();
        }
    }
}
