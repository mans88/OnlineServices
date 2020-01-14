using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.TranslationServices.TransfertObjects;

namespace OnlineServices.Common.MealServices.TransfertObjects
{
    public class IngredientTO : IEntity<int>
    {
        public int Id { get; set; }
        public MultiLanguageString Name { get; set; }
        public bool IsAllergen { get; set; }
    }

}
