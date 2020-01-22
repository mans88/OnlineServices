using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Linq;
using System.Reflection;

namespace FacilityServices.DataLayerTests.RepositoriesTests.ComponentTypeRepositoryTests
{
    [TestClass]
    public class RemoveComponentTypesTests
    {
        [TestMethod]
        public void RemoveComponentTypeByTransfertObject_ThrowException_WhenDeletingANonExistantComponentType()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                   .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                   .Options;

            using (var memoryCtx = new FacilityContext(options))
            {
                var ComponentTypeToUseInTest1 = new ComponentTypeTO
                {
                    Archived = false,
                    Name = new MultiLanguageString("Name1En", "Name1Fr", "Name1Nl"),
                };
                var ComponentTypeToUseInTest2 = new ComponentTypeTO
                {
                    Archived = false,
                    Name = new MultiLanguageString("Name2En", "Name2Fr", "Name2Nl"),
                };
                var ComponentTypeToUseInTest3 = new ComponentTypeTO
                {
                    Archived = false,
                    Name = new MultiLanguageString("Name3En", "Name3Fr", "Name3Nl"),
                };


                var componentTypeRepository = new ComponentTypeRepository(memoryCtx);

                componentTypeRepository.Add(ComponentTypeToUseInTest1);
                componentTypeRepository.Add(ComponentTypeToUseInTest2);
                memoryCtx.SaveChanges();

                Assert.ThrowsException<LoggedException>(() => componentTypeRepository.Remove(ComponentTypeToUseInTest3));
            }
        }

        [TestMethod]
        public void RemoveComponentTypeByTransfertObject_Successfull()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                   .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                   .Options;

            using (var memoryCtx = new FacilityContext(options))
            {
                var ComponentTypeToUseInTest1 = new ComponentTypeTO
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

                var f1 = componentTypeRepository.Add(ComponentTypeToUseInTest1);
                var f2 = componentTypeRepository.Add(ComponentTypeToUseInTest2);
                memoryCtx.SaveChanges();
                componentTypeRepository.Remove(f2);
                memoryCtx.SaveChanges();

                var retrievedComponentTypes = componentTypeRepository.GetAll();

                Assert.AreEqual(1, retrievedComponentTypes.Count());
                Assert.IsFalse(retrievedComponentTypes.Any(x => x.Id == 2));
            }

        }

        [TestMethod]
        public void RemoveComponentTypeById_ThrowException_WhenDeletingANonExistantComponentType()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                   .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                   .Options;

            using (var memoryCtx = new FacilityContext(options))
            {
                var ComponentTypeToUseInTest1 = new ComponentTypeTO
                {
                    Archived = false,
                    Name = new MultiLanguageString("Name1En", "Name1Fr", "Name1Nl"),
                };
                var ComponentTypeToUseInTest2 = new ComponentTypeTO
                {
                    Archived = false,
                    Name = new MultiLanguageString("Name2En", "Name2Fr", "Name2Nl"),
                };
                var ComponentTypeToUseInTest3 = new ComponentTypeTO
                {
                    Archived = false,
                    Name = new MultiLanguageString("Name3En", "Name3Fr", "Name3Nl"),
                };


                var componentTypeRepository = new ComponentTypeRepository(memoryCtx);

                componentTypeRepository.Add(ComponentTypeToUseInTest1);
                componentTypeRepository.Add(ComponentTypeToUseInTest2);
                memoryCtx.SaveChanges();

                Assert.ThrowsException<LoggedException>(() => componentTypeRepository.Remove(3));
            }
        }

        [TestMethod]
        public void RemoveComponentTypeById_Successfull()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                   .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                   .Options;

            using (var memoryCtx = new FacilityContext(options))
            {
                var ComponentTypeToUseInTest1 = new ComponentTypeTO
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

                componentTypeRepository.Add(ComponentTypeToUseInTest1);
                componentTypeRepository.Add(ComponentTypeToUseInTest2);
                memoryCtx.SaveChanges();
                componentTypeRepository.Remove(1);
                memoryCtx.SaveChanges();

                var retrievedComponentTypes = componentTypeRepository.GetAll();

                Assert.AreEqual(1, retrievedComponentTypes.Count());
                Assert.IsFalse(retrievedComponentTypes.Any(x => x.Id == 1));
            }
        }

        [TestMethod]
        public void RemoveComponentTypeByTransfertObject_ThrowException_WhenNullIsSupplied()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                   .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                   .Options;

            using (var memoryCtx = new FacilityContext(options))
            {
                var componentTypeRepository = new ComponentTypeRepository(memoryCtx);
                Assert.ThrowsException<ArgumentNullException>(() => componentTypeRepository.Remove(null));
            }
        }
    }
}
