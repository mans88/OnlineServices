using MealServices.BusinessLayer.Domain;

using OnlineServices.Common.MealServices.TransfertObjects;

using System.Linq;

namespace MealServices.BusinessLayer.Extensions
{
    public static class MealExtensions
    {
        //public static MealTO ToBTO(this Meal Meal, Language Langue)
        //{
        //    return new MealTO
        //    {
        //        Id = Meal.Id,
        //        Name = Meal.ToString(Langue),
        //        Ingredients = String.Join(" - ", Meal.Ingredients.Select(x => x.ToString(Langue))),
        //        //Supplier = Meal.Supplier.ToTransfertObject()
        //    };
        //}

        public static Meal ToDomain(this MealTO MealTO)
        {
            return new Meal(MealTO.Name, MealTO.Supplier.ToDomain())
            {
                Id = MealTO.Id,
                Ingredients = MealTO.Ingredients.Select(x => x.ToDomain()).ToList(),
                MealType = MealTO.MealType
            };
        }

        public static MealTO ToTransfertObject(this Meal Meal)
        {
            return new MealTO
            {
                Id = Meal.Id,
                Name = Meal.Name,
                MealType = Meal.MealType,
                Ingredients = Meal.Ingredients.Select(x => x.ToTransfertObject()).ToList(),
                Supplier = Meal.Supplier.ToTransfertObject()
            };
        }
    }
}
