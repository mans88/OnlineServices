using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.MealServices.TransfertObjects;

using System.Collections.Generic;

namespace OnlineServices.Common.MealServices.Interfaces
{
    public interface IMealRepository2 : IRepositoryDO_NOT_USE<MealTO, int>
    {
        List<MealTO> GetMealsBySupplier(SupplierTO Supplier);
        List<MealTO> GetMealsByIngredient(List<IngredientTO> Ingredients);
        List<MealTO> GetMealsWithoutIngredient(List<IngredientTO> Ingredients);
    }
}
