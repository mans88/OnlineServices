using MealServices.DataLayer.Entities;
using MealServices.DataLayer.Extensions;

using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.MealServices.Interfaces;
using OnlineServices.Common.MealServices.TransfertObjects;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MealServices.DataLayer.Repositories
{
    public class MealRepository2 : GenericRepositoryTO<MealEF, MealTO, int>, IMealRepository2
    {
        private readonly MealContext mealContext;

        public MealRepository2(MealContext ContextIoC) : base(ContextIoC)
        {
            mealContext = ContextIoC ?? throw new ArgumentNullException($"{nameof(ContextIoC)} in MealRepository");
        }

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

        public override MealEF ToEF(MealTO transfertObject)
        {
            return transfertObject.ToEF();
        }

        public override MealTO ToTransfertObject(MealEF entity)
        {
            return entity.ToTransfertObject();
        }

        public override MealEF UpdateFromDetached(MealEF AttachedEF, MealEF DetachedEF)
        {
            return AttachedEF.UpdateFromDetached(DetachedEF);
        }
    }
}

//DOC TO IMPLEMENT? https://www.codeproject.com/Articles/25418/Object-Cloning-Using-Generic-in-C
