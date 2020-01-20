using MealServices.BusinessLayer.Domain;

using OnlineServices.Common.Enumerations;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.TranslationServices.TransfertObjects;

namespace MealServices.BusinessLayer.DomainTests
{
    [TestClass]
    public class IngredientTests
    {
        private readonly Ingredient Tomate = new Ingredient(new MultiLanguageString("Tomato", "Tomate", "Tomaat"), false);
        private readonly Ingredient Brie = new Ingredient(new MultiLanguageString("Brie", "Brie", "Brie"), true);
        private readonly Ingredient Fromage = new Ingredient(new MultiLanguageString("Cheese", "Fromage", "Kaas"), true);
        private readonly Ingredient Noix = new Ingredient(new MultiLanguageString("Nuts", "Noix", "Noten"), true);
        private readonly Ingredient Beurre = new Ingredient(new MultiLanguageString("Butter", "Beurre", "Boter"), false);
        private readonly Ingredient Jambon = new Ingredient(new MultiLanguageString("Ham", "Jambon", "Ham"), false);
        private readonly Ingredient Roquette = new Ingredient(new MultiLanguageString("Arugula", "Roquette", "Rucola"), false);
        private readonly Ingredient Salade = new Ingredient(new MultiLanguageString("Salad", "Salade", "Salade"), false);
        private readonly Ingredient Pesto = new Ingredient(new MultiLanguageString("Pesto", "Pesto", "Pesto"), false);
        private readonly Ingredient Oeuf = new Ingredient(new MultiLanguageString("Eggs", "Oeufs", "Eien"), true);
        private readonly Ingredient Miel = new Ingredient(new MultiLanguageString("Honey", "Miel", "Honing"), false);

        private readonly Meal Club = new Meal(new MultiLanguageString("Club", "Club", "Club"), new Supplier { Id = 33, Name = "Supplier1" });
        private readonly Meal BrieNoix = new Meal(new MultiLanguageString("Brie", "Brie", "Brie"), new Supplier { Id = 33, Name = "Supplier1" });
        private readonly Meal PestoVerde = new Meal(new MultiLanguageString("Pesto", "Pesto", "Pesto"), new Supplier { Id = 33, Name = "Supplier1" });

        [TestMethod()]
        public void ShowAllergene_ReturnsStart_WhenIngredientIsAllergen()
        {
            Assert.AreEqual(false, Tomate.IsAllergen);
            Assert.AreEqual(true, Fromage.IsAllergen);
            Assert.AreEqual(true, Noix.IsAllergen);
        }

        [TestMethod()]
        public void ToString_ReturnsEnglishName_WhenEnglishEnumISProvided()
        {
            var sutd = Tomate.ToString(Language.English);
            Assert.AreEqual(sutd, "Tomato");
        }
        [TestMethod()]
        public void ToString_ReturnsFrenchName_WhenFrenchEnumISProvided()
        {
            var sutd = Tomate.ToString(Language.French);
            Assert.AreEqual(sutd, "Tomate");
        }

        [TestMethod()]
        public void ToString_ReturnsDutchName_WhenDutchEnumISProvided()
        {
            var sut = Tomate.ToString(Language.Dutch);
            Assert.AreEqual("Tomaat", sut);
        }

        [TestMethod()]
        public void ToString_ReturnsIngredientWithAllergenInfo_WhenAllergenIsProvided()
        {
            var sut = Noix.ToString(Language.English);
            Assert.AreEqual("Nuts*", sut);
        }

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
