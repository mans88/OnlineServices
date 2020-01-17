using OnlineServices.Common.Enumerations;
using OnlineServices.Common.TranslationServices.TransfertObjects;

using System;

namespace MealServices.BusinessLayer.Domain
{
    public class Ingredient
    {
        public int Id { get; set; }

        public MultiLanguageString Name { get; set; }

        public bool IsAllergen { get; set; }

        public Ingredient(MultiLanguageString Name, bool isAllergene)
        {
            this.Name = Name ?? throw new ArgumentNullException(nameof(Name));
            this.IsAllergen = isAllergene;
        }

        public string ToString(Language Langue)
            => Name.ToString(Langue) + (IsAllergen? "*":"");
    }

}
