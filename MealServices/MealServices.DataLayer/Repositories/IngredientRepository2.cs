using MealServices.DataLayer.Entities;
using MealServices.DataLayer.Extensions;

using Microsoft.EntityFrameworkCore;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.MealServices.TransfertObjects;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MealServices.DataLayer.Repositories
{
    public class IngredientRepository2 : GenericRepositoryTO<IngredientEF,IngredientTO, int>
    {
        private readonly MealContext mealContext;

        public IngredientRepository2(MealContext ContextIoC) : base(ContextIoC)
        {
            mealContext = ContextIoC ?? throw new ArgumentNullException($"{nameof(ContextIoC)} in IngredientRepository");
        }

        public override IngredientEF ToEF(IngredientTO transfertObject)
        {
            return transfertObject.ToEF();
        }

        public override IngredientTO ToTransfertObject(IngredientEF entity)
        {
            return entity.ToTransfertObject();
        }

        public override IngredientEF UpdateFromDetached(IngredientEF AttachedEF, IngredientEF DetachedEF)
        {
            return AttachedEF.UpdateFromDetached(DetachedEF);
        }
    }
}
