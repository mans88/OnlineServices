using MealServices.DataLayer.Entities;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MealServices.DataLayer.Extensions
{
    public static class MealsCompositionExtensions
    {
        public static MealCompositionEF UpdateFromDetached(this MealCompositionEF AttachedEF, MealCompositionEF DetachedEF)
        {
            if (AttachedEF is null)
                throw new ArgumentNullException(nameof(AttachedEF));
            if (DetachedEF is null)
                throw new ArgumentNullException(nameof(DetachedEF));

            if ((AttachedEF.IngredientId != DetachedEF.IngredientId)
                && (AttachedEF.MealId != DetachedEF.MealId))
                    throw new Exception("Cannot update MealCompositionEF entity as it is not the same.");

            if ((AttachedEF != default) && (DetachedEF != default))
            {
                AttachedEF.Meal = AttachedEF.Meal.UpdateFromDetached(DetachedEF.Meal);
                AttachedEF.Ingredient = AttachedEF.Ingredient.UpdateFromDetached(DetachedEF.Ingredient);
            }

            return AttachedEF;
        }

        public static List<MealCompositionEF> UpdateFromDetached(this List<MealCompositionEF> AttachedList, List<MealCompositionEF> DetachedList)
        {
            if (AttachedList is null)
                throw new ArgumentNullException(nameof(AttachedList));
            if (DetachedList is null)
                throw new ArgumentNullException(nameof(DetachedList));

            var ListNotModified = AttachedList.Except(DetachedList);
            var ListAdd = DetachedList.Except(AttachedList);
            var ListModifiedDetached = DetachedList.Intersect(AttachedList);//TODO !!! from Attached or BUG
                //Notes: DetachedEF.Except(ListAdd); Same Result

            foreach (var DetachedEF in ListModifiedDetached)
            {
                var AttachedEF = AttachedList.Find(x => x.Equals(DetachedEF));
                AttachedEF = AttachedEF.UpdateFromDetached(DetachedEF);
            }

            return ListModifiedDetached.Concat(ListNotModified).Concat(ListAdd).ToList();
        }
    }
}
