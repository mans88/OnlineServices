using OnlineServices.Common.MealServices.Enumerations;
using OnlineServices.Common.MealServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Collections.Generic;

namespace MealServices.BusinessLayerTests
{
    public static class TestHelper
    {
        public static List<MealTO> GetTestsListOfMeals()
        {
            //REchercher Founisseur
            var Tomate = new IngredientTO { Id = 1, Name = new MultiLanguageString("Tomato", "Tomate", "Tomaat"), IsAllergen = false };
            var Brie = new IngredientTO { Id = 2, Name = new MultiLanguageString("Brie", "Brie", "Brie"), IsAllergen = true };
            var Fromage = new IngredientTO { Id = 3, Name = new MultiLanguageString("Cheese", "Fromage", "Kaas"), IsAllergen = true };
            var Noix = new IngredientTO { Id = 4, Name = new MultiLanguageString("Nuts", "Noix", "Noten"), IsAllergen = true };
            var Beurre = new IngredientTO { Id = 5, Name = new MultiLanguageString("Butter", "Beurre", "Boter"), IsAllergen = false };
            var Jambon = new IngredientTO { Id = 6, Name = new MultiLanguageString("Ham", "Jambon", "Ham"), IsAllergen = false };
            var Roquette = new IngredientTO { Id = 7, Name = new MultiLanguageString("Arugula", "Roquette", "Rucola"), IsAllergen = false };
            var Salade = new IngredientTO { Id = 8, Name = new MultiLanguageString("Salad", "Salade", "Salade"), IsAllergen = false };
            var Pesto = new IngredientTO { Id = 9, Name = new MultiLanguageString("Pesto", "Pesto", "Pesto"), IsAllergen = false };
            var Oeuf = new IngredientTO { Id = 10, Name = new MultiLanguageString("Eggs", "Oeufs", "Eien"), IsAllergen = true };
            var Miel = new IngredientTO { Id = 11, Name = new MultiLanguageString("Honey", "Miel", "Honing"), IsAllergen = false };

            MealTO Club = new MealTO { Id = 1, Name = new MultiLanguageString("ClubEN", "ClubFR", "ClubNL"), Supplier = new SupplierTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientTO>(), MealType = MealType.Sandwich };
            MealTO BrieNoix = new MealTO { Id = 2, Name = new MultiLanguageString("BrieEN", "BrieFR", "BrieNL"), Supplier = new SupplierTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientTO>(), MealType = MealType.Sandwich };
            MealTO PestoVerde = new MealTO { Id = 3, Name = new MultiLanguageString("PestoEN", "PestoFR", "PestoNL"), Supplier = new SupplierTO { Id = 33, Name = "Supplier1" }, Ingredients = new List<IngredientTO>(), MealType = MealType.Sandwich };

            BrieNoix.Ingredients.Add(Brie);
            BrieNoix.Ingredients.Add(Miel);
            BrieNoix.Ingredients.Add(Noix);

            PestoVerde.Ingredients.Add(Pesto);
            PestoVerde.Ingredients.Add(Roquette);
            PestoVerde.Ingredients.Add(Oeuf);

            Club.Ingredients.Add(Jambon);
            Club.Ingredients.Add(Beurre);
            Club.Ingredients.Add(Salade);
            Club.Ingredients.Add(Fromage);
            //Rechercher la liste de meal

            var lst = new List<MealTO>(); ;

            lst.Add(BrieNoix);
            lst.Add(Club);
            lst.Add(PestoVerde);

            return lst;
        }
    }
}
