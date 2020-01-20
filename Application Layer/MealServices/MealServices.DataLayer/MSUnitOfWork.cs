using MealServices.DataLayer.Entities;
using MealServices.DataLayer.Repositories;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.MealServices.Interfaces;
using OnlineServices.Common.MealServices.TransfertObjects;

using System;

namespace MealServices.DataLayer
{
    public class MSUnitOfWork : IMSUnitOfWork
    {
        private readonly MealContext mealContext;

        public MSUnitOfWork(MealContext ContextIoC)
        {
            this.mealContext = ContextIoC ?? throw new ArgumentNullException(nameof(ContextIoC));
        }

        private IMealRepository mealRepository;
        public IMealRepository MealRepository
            => mealRepository = new MealRepository(mealContext);
        //=> mealRepository ??= new MealRepository(mealContext);

        private IRepositoryDO_NOT_USE<IngredientTO, int> ingredientRepository2;
        public IRepositoryDO_NOT_USE<IngredientTO, int> IngredientRepository2
            => ingredientRepository2 = new IngredientRepository2(mealContext);
        //=> ingredientRepository ??= new IngredientRepository(mealContext);

        private IRepository<IngredientTO, int> ingredientRepository;
        public IRepository<IngredientTO, int> IngredientRepository
            => ingredientRepository = new IngredientRepository(mealContext);
            //=> ingredientRepository ??= new IngredientRepository(mealContext);

        private ISupplierRepository supplierRepository;
        public ISupplierRepository SupplierRepository
            => supplierRepository = new SupplierRepository(mealContext);
            //=> supplierRepository ??= new SupplierRepository(mealContext);

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    mealContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return mealContext.SaveChanges();
        }
    }
}
