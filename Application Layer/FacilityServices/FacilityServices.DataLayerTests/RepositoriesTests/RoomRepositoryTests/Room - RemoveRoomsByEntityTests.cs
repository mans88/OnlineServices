using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FacilityServices.DataLayerTests.RepositoriesTests.RoomRepositoryTest
{
    [TestClass]
    public class RemoveRoomsByEntityTests
    {
        [TestMethod]
        public void RemoveByEntity_AddANewRoomAndRemoveTheAddedRoom_ReturnTrue()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new FacilityContext(options);
            IRoomRepository repository = new RoomRepository(context);
            IFloorRepository floorRepository = new FloorRepository(context);

            var floor = new FloorTO { Number = 2 };
            var addedFloor1 = floorRepository.Add(floor);
            context.SaveChanges();

            RoomTO room = new RoomTO { Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = addedFloor1 };
            var added = repository.Add(room);
            context.SaveChanges();
            //ACT
            var result = repository.Remove(added);
            context.SaveChanges();
            //ASSERT
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveByEntity_ThrowException_WhenNullIsSupplied()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new FacilityContext(options);
            IRoomRepository repository = new RoomRepository(context);

            //ACT & ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => repository.Remove(null));
        }

        [TestMethod]
        public void RemoveByEntity_ThrowException_WhenUnexistingRoomIsSupplied()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new FacilityContext(options);
            IRoomRepository repository = new RoomRepository(context);
            var room = new RoomTO { Id = 999 };

            //ACT & ASSERT
            Assert.ThrowsException<KeyNotFoundException>(() => repository.Remove(room));
        }
    }
}
