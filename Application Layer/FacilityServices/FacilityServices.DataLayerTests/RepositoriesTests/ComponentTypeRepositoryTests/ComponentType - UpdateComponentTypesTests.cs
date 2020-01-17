using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Linq;
using System.Reflection;

namespace FacilityServices.DataLayerTests.RepositoriesTests.ComponentTypeRepositoryTests
{
    [TestClass]
    public class UpdateComponentTypesTests
    {
        [TestMethod]
        public void UpdateComponentTypeByTransfertObject_Successfull()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                   .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                   .Options;

            using (var memoryCtx = new FacilityContext(options))
            {
                var ComponentTypeToUseInTest = new ComponentTypeTO
                {
                    Archived = false,
                    Name = new MultiLanguageString("Name1En", "Name1Fr", "Name1Nl"),
                };
                var ComponentTypeToUseInTest2 = new ComponentTypeTO
                {
                    Archived = false,
                    Name = new MultiLanguageString("Name2En", "Name2Fr", "Name2Nl"),
                };
              
                var componentTypeRepository = new ComponentTypeRepository(memoryCtx);

                var f1 = componentTypeRepository.Add(ComponentTypeToUseInTest);
                var f2 = componentTypeRepository.Add(ComponentTypeToUseInTest2);
                memoryCtx.SaveChanges();
                f2.Name.French = "UpdatedFrenchName";
                f2.Archived = true;
                componentTypeRepository.Update(f2);

                Assert.AreEqual(2, componentTypeRepository.GetAll().Count());
                Assert.AreEqual("UpdatedFrenchName", f2.Name.French);
                Assert.AreEqual(true, f2.Archived);
            }
        }
    }
}
