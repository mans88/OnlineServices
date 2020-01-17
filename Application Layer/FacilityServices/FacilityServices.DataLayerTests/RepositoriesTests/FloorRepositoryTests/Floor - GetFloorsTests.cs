using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.FacilityServices.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FacilityServices.DataLayerTests.RepositoriesTests.FloorRepositoryTests
{
    [TestClass]
    public class GetFloorsTests
    {
        [TestMethod]
        public void GetFloorById_ThrowsException_WhenInvalidIdIsProvided()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using (var memoryCtx = new FacilityContext(options))
            {
                var floorRepository = new FloorRepository(memoryCtx);

                Assert.ThrowsException<NullFloorException>(() => floorRepository.GetById(100));
            }
        }
        [TestMethod]
        public void GetFloorById_Successfull()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using (var memoryCtx = new FacilityContext(options))
            {
                //ARRANGE
                var FloorToUseInTest = new FloorTO
                {
                    Id = 2,
                    Number = 0
                };

                var floorRepository = new FloorRepository(memoryCtx);

                //ACT
                floorRepository.Add(FloorToUseInTest);
                memoryCtx.SaveChanges();

                //ASSERT
                var FloorToAssert = floorRepository.GetById(2);
                Assert.AreEqual(2, FloorToAssert.Id);
                Assert.AreEqual(0, FloorToAssert.Number);
            }
        }

        [TestMethod]
        public void GetAllFloors_Successfull()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using (var memoryCtx = new FacilityContext(options))
            {
                //ARRANGE
                var FloorToUseInTest = new FloorTO
                {
                    Id = 1,
                    Number = 0
                };

                var FloorToUseInTest1 = new FloorTO
                {
                    Id = 2,
                    Number = -1
                };
                var FloorToUseInTest2 = new FloorTO
                {
                    Id = 3,
                    Number = -2
                };
                var floorRepository = new FloorRepository(memoryCtx);

                //ACT
                floorRepository.Add(FloorToUseInTest);
                floorRepository.Add(FloorToUseInTest1);
                floorRepository.Add(FloorToUseInTest2);
                memoryCtx.SaveChanges();

                //ASSERT
                Assert.AreEqual(3, floorRepository.GetAll().Count());
            }
        }
    }
}
