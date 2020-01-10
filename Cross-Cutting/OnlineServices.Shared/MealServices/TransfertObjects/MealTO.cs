using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.MealServices.Enumerations;
using OnlineServices.Common.TranslationServices.TransfertObjects;

using System.Collections.Generic;

namespace OnlineServices.Common.MealServices.TransfertObjects
{
    public class MealTO : IEntity<int>
    {
        public int Id { get; set; }
        public MultiLanguageString Name { get; set; }
        public SupplierTO Supplier { get; set; }
        public List<IngredientTO> Ingredients { get; set; }
        public MealType MealType { get; set; }
    }
}