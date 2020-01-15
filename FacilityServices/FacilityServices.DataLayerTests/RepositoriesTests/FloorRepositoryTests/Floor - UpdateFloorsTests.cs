using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FacilityServices.DataLayerTests.RepositoriesTests.FloorRepositoryTests
{
    [TestClass]
    public class UpdateFloorsTests
    {
        [TestMethod()]
        public void UpdateFloorByTransfertObject_Successfull()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                   .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                   .Options;

            using (var memoryCtx = new FacilityContext(options))
            {
                var FloorToUseInTest = new FloorTO
                { Number = 0 };
                var FloorToUseInTest2 = new FloorTO
                { Number = -1 };


                var floorRepository = new FloorRepository(memoryCtx);

                var f1 = floorRepository.Add(FloorToUseInTest);
                var f2 = floorRepository.Add(FloorToUseInTest2);
                memoryCtx.SaveChanges();
                f2.Number = 18;
                floorRepository.Update(f2);

                Assert.AreEqual(2, floorRepository.GetAll().Count());
                Assert.AreEqual(18, f2.Number);
            }
        }
    }
}
