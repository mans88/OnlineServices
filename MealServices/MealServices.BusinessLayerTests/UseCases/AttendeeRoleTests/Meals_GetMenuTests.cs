using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.MealServices.Interfaces;
using OnlineServices.Common.Enumerations;
using System.Linq;
using MealServices.BusinessLayer.Extensions;
using OnlineServices.Common.MealServices.TransfertObjects;
using MealServices.BusinessLayerTests;

namespace MealServices.BusinessLayer.UseCases.AttendeeRoleTests
{
    [TestClass()]
    public class Meals_GetMenuTests
    {
        [TestMethod()]
        public void GetMenu_ReturnHasRightCountOfMeals_WhenAValidLanguageIsProvided()
        {
            //ARRANGE
            var SupplierToUse = new SupplierTO() { Id = 33, Name = "MockedSupplier" };

            var fakeMealRepo = new Mock<IMealRepository>();
            //fakeMealRepo.Setup(x => x.GetAll()).Returns(GetTestsListOfMeal());
            fakeMealRepo.Setup(x => x.GetMealsBySupplier(It.IsAny<SupplierTO>())).Returns(TestHelper.GetTestsListOfMeals());

            //var fakeIngredientRepo = new Mock<IRepository<IngredientTO, int>>();

            var fakeSupplierRepo = new Mock<ISupplierRepository>();
            fakeSupplierRepo.Setup(x => x.GetDefaultSupplier()).Returns(SupplierToUse);

            var unitOfWorkMock = new Mock<IMSUnitOfWork>();
            unitOfWorkMock.Setup(x => x.MealRepository).Returns(fakeMealRepo.Object);
            unitOfWorkMock.Setup(x => x.SupplierRepository).Returns(fakeSupplierRepo.Object);

            //ACT
            var participant = new MSAttendeeRole(unitOfWorkMock.Object);
            var listMenu = participant.GetMenu();

            //ASSERT
            Assert.AreEqual(3, listMenu.Count());
        }

        [TestMethod()]
        public void GetMenu_ReturnMealsInEnglish_WhenEnglishLanguageIsProvided()
        {
            //ARRANGE
            var SupplierToUse = new SupplierTO() { Id = 33, Name = "MockedSupplier" };

            var fakeMealRepo = new Mock<IMealRepository>();
            fakeMealRepo.Setup(x => x.GetMealsBySupplier(It.IsAny<SupplierTO>())).Returns(TestHelper.GetTestsListOfMeals());

            var fakeSupplierRepo = new Mock<ISupplierRepository>();
            fakeSupplierRepo.Setup(x => x.GetDefaultSupplier()).Returns(SupplierToUse);

            var unitOfWorkMock = new Mock<IMSUnitOfWork>();
            unitOfWorkMock.Setup(x => x.MealRepository).Returns(fakeMealRepo.Object);
            unitOfWorkMock.Setup(x => x.SupplierRepository).Returns(fakeSupplierRepo.Object);

            //ACT
            var participant = new MSAttendeeRole(unitOfWorkMock.Object);
            var listMenu = participant.GetMenu();

            //ASSERT
            Assert.AreEqual("BrieEN", listMenu.Skip(0).First().ToDomain().ToString(Language.English));
            Assert.AreEqual("ClubEN", listMenu.Skip(1).First().ToDomain().ToString(Language.English));
            Assert.AreEqual("PestoEN", listMenu.Skip(2).First().ToDomain().ToString(Language.English));

            Assert.AreEqual("Brie* - Honey - Nuts*", listMenu.Skip(0).First().ToDomain().GetIngredientsString(Language.English));
            Assert.AreEqual("Ham - Butter - Salad - Cheese*", listMenu.Skip(1).First().ToDomain().GetIngredientsString(Language.English));
            Assert.AreEqual("Pesto - Arugula - Eggs*", listMenu.Skip(2).First().ToDomain().GetIngredientsString(Language.English));
        }

        [TestMethod()]
        public void GetMenu_ReturnMealsInFrench_WhenFrenchLanguageIsProvided()
        {
            //ARRANGE
            var SupplierToUse = new SupplierTO() { Id = 33, Name = "MockedSupplier" };

            var fakeMealRepo = new Mock<IMealRepository>();
            fakeMealRepo.Setup(x => x.GetMealsBySupplier(It.IsAny<SupplierTO>())).Returns(TestHelper.GetTestsListOfMeals());

            var fakeSupplierRepo = new Mock<ISupplierRepository>();
            fakeSupplierRepo.Setup(x => x.GetDefaultSupplier()).Returns(SupplierToUse);

            var unitOfWorkMock = new Mock<IMSUnitOfWork>();
            unitOfWorkMock.Setup(x => x.MealRepository).Returns(fakeMealRepo.Object);
            unitOfWorkMock.Setup(x => x.SupplierRepository).Returns(fakeSupplierRepo.Object);

            //ACT
            var participant = new MSAttendeeRole(unitOfWorkMock.Object);
            var listMenu = participant.GetMenu();

            //ASSERT
            Assert.AreEqual("BrieFR", listMenu.Skip(0).First().ToDomain().ToString(Language.French));
            Assert.AreEqual("ClubFR", listMenu.Skip(1).First().ToDomain().ToString(Language.French));
            Assert.AreEqual("PestoFR", listMenu.Skip(2).First().ToDomain().ToString(Language.French));

            Assert.AreEqual("Brie* - Miel - Noix*", listMenu.Skip(0).First().ToDomain().GetIngredientsString(Language.French));
            Assert.AreEqual("Jambon - Beurre - Salade - Fromage*", listMenu.Skip(1).First().ToDomain().GetIngredientsString(Language.French));
            Assert.AreEqual("Pesto - Roquette - Oeufs*", listMenu.Skip(2).First().ToDomain().GetIngredientsString(Language.French));
        }

        [TestMethod()]
        public void GetMenu_ReturnMealsWithDutch_WhenDutchLanguageIsProvided()
        {
            //ARRANGE
            var SupplierToUse = new SupplierTO() { Id = 33, Name = "MockedSupplier" };

            var fakeMealRepo = new Mock<IMealRepository>();
            fakeMealRepo.Setup(x => x.GetMealsBySupplier(It.IsAny<SupplierTO>())).Returns(TestHelper.GetTestsListOfMeals());

            var fakeSupplierRepo = new Mock<ISupplierRepository>();
            fakeSupplierRepo.Setup(x => x.GetDefaultSupplier()).Returns(SupplierToUse);

            var unitOfWorkMock = new Mock<IMSUnitOfWork>();
            unitOfWorkMock.Setup(x => x.MealRepository).Returns(fakeMealRepo.Object);
            unitOfWorkMock.Setup(x => x.SupplierRepository).Returns(fakeSupplierRepo.Object);

            //ACT
            var participant = new MSAttendeeRole(unitOfWorkMock.Object);
            var listMenu = participant.GetMenu();

            //ASSERT
            Assert.AreEqual("BrieNL", listMenu.Skip(0).First().ToDomain().ToString(Language.Dutch));
            Assert.AreEqual("ClubNL", listMenu.Skip(1).First().ToDomain().ToString(Language.Dutch));
            Assert.AreEqual("PestoNL", listMenu.Skip(2).First().ToDomain().ToString(Language.Dutch));

            Assert.AreEqual("Brie* - Honing - Noten*", listMenu.Skip(0).First().ToDomain().GetIngredientsString(Language.Dutch));
            Assert.AreEqual("Ham - Boter - Salade - Kaas*", listMenu.Skip(1).First().ToDomain().GetIngredientsString(Language.Dutch));
            Assert.AreEqual("Pesto - Rucola - Eien*", listMenu.Skip(2).First().ToDomain().GetIngredientsString(Language.Dutch));
        }
    }
}