using MealServices.BusinessLayer.Domain;

using OnlineServices.Common.MealServices.TransfertObjects;

namespace MealServices.BusinessLayer.Extensions
{
    public static class IngredientExtensions
    {
        public static Ingredient ToDomain(this IngredientTO IngredientTO)
        {
            return new Ingredient(IngredientTO.Name, IngredientTO.IsAllergen)
            {
                Id = IngredientTO.Id
            };
        }
        public static IngredientTO ToTransfertObject(this Ingredient Ingredient)
        {
            return new IngredientTO()
            {
                Id = Ingredient.Id,
                Name = Ingredient.Name,
                IsAllergen = Ingredient.IsAllergen
            };
        }
    }
}
