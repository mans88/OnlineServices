using MealServices.DataLayer.Extensions;

using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.MealServices.Interfaces;
using OnlineServices.Common.MealServices.TransfertObjects;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MealServices.DataLayer.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly MealContext mealContext;

        public MealRepository(MealContext ContextIoC)
        {
            mealContext = ContextIoC ?? throw new ArgumentNullException($"{nameof(ContextIoC)} in MealRepository");
        }

        public bool Remove(MealTO Entity)
            => Remove(Entity.Id);

        public bool Remove(int Id)
        {
            var ReturnValue = false;
            if (!mealContext.Meals.Any(x => x.Id == Id))
                throw new Exception($"MealRepository. Delete(MealId = {Id}) no record to delete.");

            var meal = mealContext.Meals.FirstOrDefault(x => x.Id == Id);
            if (meal != default)
            {
                try
                {
                    mealContext.Meals.Remove(meal);
                    ReturnValue = true;
                }
                catch (Exception)
                {
                    ReturnValue = false;
                }
            }

            return ReturnValue;
        }

        public IEnumerable<MealTO> GetAll()
            => mealContext.Meals
                .AsNoTracking()
                .Include(x => x.MealsComposition)
                    .ThenInclude(x => x.Ingredient)
                .Include(x => x.Supplier)
                .Select(x => x.ToTransfertObject())
                .ToList();

        public MealTO GetById(int Id)
            => mealContext.Meals
            .AsNoTracking()
            .Include(x => x.MealsComposition)
                .ThenInclude(x => x.Ingredient)
            .Include(x => x.Supplier)
            .FirstOrDefault(x => x.Id == Id).ToTransfertObject();

        public List<MealTO> GetMealsByIngredient(List<IngredientTO> Ingredients)
        {
            throw new NotImplementedException();
        }

        public List<MealTO> GetMealsBySupplier(SupplierTO Supplier)
            => mealContext.Meals
            .Include(x => x.Supplier)
            .Include(x => x.MealsComposition)
            .Where(x => x.Supplier.Id == Supplier.Id)
            .Select(x => x.ToTransfertObject())
            .ToList();

        public List<MealTO> GetMealsWithoutIngredient(List<IngredientTO> Ingredients)
        {
            throw new NotImplementedException();
        }

        public MealTO Add(MealTO Entity)
        {
            //if (!mealContext.Meals.Any(x => x.Id == Entity.Id))
            return mealContext.Meals
                .Add(Entity.ToEF())
                .Entity
                .ToTransfertObject();
        }

        public MealTO Update(MealTO Entity)
        {
            if (!mealContext.Meals.Any(x => x.Id == Entity.Id))
                throw new Exception($"MealRepository. Update(MealTransfertObject) no record to update.");

            var attachedMeal = mealContext.Meals
                .Include(x=>x.MealsComposition)
                    .ThenInclude(x=>x.Ingredient)
                .FirstOrDefault(x => x.Id == Entity.Id);

            if (attachedMeal != default)
            {
                attachedMeal.UpdateFromDetached(Entity.ToEF());
                //attachedMeal.MealsComposition = attachedMeal.MealsComposition
                //    .ToList()
                //    .UpdateListFromDetached(Entity.ToEF().MealsComposition.ToList());
            }

            return mealContext.Meals.Update(attachedMeal).Entity.ToTransfertObject();
        }
    }
}

//DOC TO IMPLEMENT? https://www.codeproject.com/Articles/25418/Object-Cloning-Using-Generic-in-C
