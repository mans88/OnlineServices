using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FacilityServices.DataLayerTests.RepositoriesTests.ComponentTypeRepositoryTests
{
    [TestClass]
    public class AddComponentTypesTests
    {
        [TestMethod]
        public void AddComponentType_ThrowsException_WhenANonExistingIdIsProvided()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using (var memoryCtx = new FacilityContext(options))
            {
                var ComponentTypeToUseInTest = new ComponentTypeTO
                {

                };

                var componentTypeRepository = new ComponentTypeRepository(memoryCtx);

                Assert.ThrowsException<ArgumentNullException>(() => componentTypeRepository.Add(null));

            }
        }
            [TestMethod]
        public void AddComponentType_Successfull()
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

                var componentTypeRepository = new ComponentTypeRepository(memoryCtx);

                componentTypeRepository.Add(ComponentTypeToUseInTest);
                memoryCtx.SaveChanges();

                Assert.AreEqual(1, componentTypeRepository.GetAll().Count());
                var ComponentTypeToAssert = componentTypeRepository.GetById(1);
                Assert.AreEqual(1, ComponentTypeToAssert.Id);
                Assert.AreEqual("Name1En", ComponentTypeToAssert.Name.English);
            }
        }
    }
}