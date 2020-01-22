using Microsoft.VisualStudio.TestTools.UnitTesting;
using MealServices.BusinessLayer.Domain;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using OnlineServices.Common.Enumerations;

namespace MealServices.BusinessLayer.DomainTests
{
    [TestClass]
    public class MealTests
    {
        Ingredient Brie = new Ingredient(new MultiLanguageString("Brie", "Brie", "Brie"), true);
        Ingredient Noix = new Ingredient(new MultiLanguageString("Nuts", "Noix", "Noten"), true);
        Ingredient Miel = new Ingredient(new MultiLanguageString("Honey", "Miel", "Honing"), false);


        Meal BrieNoix = new Meal(new MultiLanguageString("Brie", "Brie", "Brie"), new Supplier { Id = 33, Name = "Supplier1" });

        [TestMethod()]
        public void GetIngredientsString_ReturnsACompleteListOFIngredientsWithAllergeneInfo()
        {
            BrieNoix.Ingredients.Add(Brie);
            BrieNoix.Ingredients.Add(Miel);
            BrieNoix.Ingredients.Add(Noix);

            var sute = BrieNoix.GetIngredientsString(Language.English);
            Assert.AreEqual(sute, "Brie* - Honey - Nuts*");
        }
    }
}
