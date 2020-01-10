using MealServices.DataLayer;
using MealServices.DataLayer.Entities;
using MealServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.MealServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MealServices.DataLayerTests
{
    [TestClass]
    public class IngredientGenericTests
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var options = new DbContextOptionsBuilder<MealContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryCtx = new MealContext(options))
            {
                //ARRANGE
                var IngredientToUseInTest = new IngredientTO
                {
                    Id = 1,
                    IsAllergen = true,
                    Name = new MultiLanguageString("Ingr1EN", "Ingr1FR", "Ingr1NL")
                };

                IRepositoryDO_NOT_USE<IngredientTO, int> ingredientRepository2 = new IngredientRepository2(memoryCtx);

                //ACT
                ingredientRepository2.Create(IngredientToUseInTest);
                memoryCtx.SaveChanges();
                //MealToUseInTest.Id = 1;
                IngredientToUseInTest.IsAllergen = false;
                ingredientRepository2.Edit(IngredientToUseInTest);
                var qtdEntriesToAssert = memoryCtx.SaveChanges();

                var IngredientToAssert = ingredientRepository2.GetById(1);
                //ASSERT
                Assert.AreEqual(1, qtdEntriesToAssert);
                Assert.AreEqual(1, ingredientRepository2.GetAll().Count());
                Assert.AreEqual(1, IngredientToAssert.Id);
                Assert.IsFalse(IngredientToAssert.IsAllergen);
                Assert.AreEqual("Ingr1EN", IngredientToAssert.Name.English);
            }
        }
    }
}
