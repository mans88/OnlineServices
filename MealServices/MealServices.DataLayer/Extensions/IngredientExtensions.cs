using MealServices.DataLayer.Entities;

using OnlineServices.Common.Extensions;
using OnlineServices.Common.MealServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;

using System;

namespace MealServices.DataLayer.Extensions
{
    public static class IngredientExtensions
    {
        public static IngredientTO ToTransfertObject(this IngredientEF Ingredient)
        {
            if (Ingredient is null)
                throw new ArgumentNullException(nameof(Ingredient));

            return new IngredientTO
            {
                Id = Ingredient.Id,
                Name = new MultiLanguageString(Ingredient.NameEnglish, Ingredient.NameFrench, Ingredient.NameDutch),
                IsAllergen = Ingredient.IsAllergen
            };
        }

        public static IngredientEF ToEF(this IngredientTO Ingredient)
        {
            if (Ingredient is null)
                throw new ArgumentNullException(nameof(Ingredient));

            return new IngredientEF()
            {
                Id = Ingredient.Id,
                NameEnglish = Ingredient.Name.English,
                NameFrench = Ingredient.Name.French,
                NameDutch = Ingredient.Name.Dutch,

                IsAllergen = Ingredient.IsAllergen
            };
        }

        public static IngredientEF UpdateFromDetached(this IngredientEF AttachedEF, IngredientEF DetachedEF)
        {
            if (AttachedEF is null)
                throw new ArgumentNullException(nameof(AttachedEF));

            if (DetachedEF is null)
                throw new ArgumentNullException(nameof(DetachedEF));

            if (AttachedEF.Id != DetachedEF.Id)
                throw new Exception("Cannot update IngredientEF entity as it is not the same.");

            if ((AttachedEF != default) && (DetachedEF != default))
            {
                AttachedEF.IsAllergen = DetachedEF.IsAllergen;
                AttachedEF = AttachedEF.FillFromMultiLanguageString(DetachedEF.ExtractToMultiLanguageString());
            }

            return AttachedEF;
        }
    }
}
