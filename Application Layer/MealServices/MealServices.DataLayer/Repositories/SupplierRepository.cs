using MealServices.DataLayer.Extensions;

using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.MealServices.Interfaces;
using OnlineServices.Common.MealServices.TransfertObjects;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MealServices.DataLayer.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly MealContext mealContext;

        public SupplierRepository(MealContext ContextIoC)
        {
            mealContext = ContextIoC ?? throw new ArgumentNullException($"{nameof(ContextIoC)} in SupplierRepository");
        }


        public bool Remove(SupplierTO Entity)
        {
            var mealRepository = new MealRepository(this.mealContext);

            if (mealRepository.GetMealsBySupplier(Entity).Any())
                throw new Exception("Cannot delete supplier that has a meal in db.");
            else
            {
                mealContext.Suppliers.Remove(Entity.ToEF());
                return true;
            }
        }

        public bool Remove(int Id)
            => Remove(GetById(Id));

        public IEnumerable<SupplierTO> GetAll()
        {
            return mealContext.Suppliers
                .AsNoTracking()
                .Include(x => x.Meals)
                    .ThenInclude(Meal => Meal.MealsComposition)
                        .ThenInclude(MealsComposition => MealsComposition.Ingredient)
                .Select(x => x.ToTransfertObject())
                .ToList();
        }

        public SupplierTO GetById(int Id)
        {
            return mealContext.Suppliers
                .AsNoTracking()
                .Include(x => x.Meals)
                    .ThenInclude(Meal => Meal.MealsComposition)
                        .ThenInclude(MealsComposition => MealsComposition.Ingredient)
                .FirstOrDefault(x => x.Id == Id)
                .ToTransfertObject();
        }

        private bool isDefaultSupplierUniquenessWithThrow(string MethodName)
        {
            if (mealContext.Suppliers.Count(x => x.IsDefault == true) != 1)
                throw new Exception($"{MethodName}. Default Supplier not well configured in DB");
            else
                return true;
        }

        public SupplierTO GetDefaultSupplier()
        {
            isDefaultSupplierUniquenessWithThrow("GetCurrentSupplier()");

            return mealContext.Suppliers
                .AsNoTracking()
                .FirstOrDefault(x => x.IsDefault == true)
                .ToTransfertObject();
        }

        public SupplierTO Add(SupplierTO Entity)
            => mealContext
                .Add(Entity.ToEF())
                .Entity
                .ToTransfertObject();

        public void SetDefaultSupplier(SupplierTO Supplier)
        {
            if (Supplier is null)
                throw new ArgumentNullException(nameof(Supplier));
            if (Supplier.Id is default(int))
                throw new Exception("Invalid SupplierID");

            var SupplierToMakeCurrent = GetById(Supplier.Id);
            SupplierToMakeCurrent.IsDefault = true;

            mealContext.Suppliers
                .UpdateRange(
                    GetAll()
                    .Select(x => { x.IsDefault = false; return x.ToEF(); })
                    .ToArray()
                );

            Update(SupplierToMakeCurrent);

            isDefaultSupplierUniquenessWithThrow("SetCurrentSupplier(SupplierTO) after update");
        }

        public SupplierTO Update(SupplierTO Entity)
            => mealContext.Suppliers
                .Find(Entity.Id)
                .UpdateFromDetached(Entity.ToEF())
                .ToTransfertObject();
    }
}
