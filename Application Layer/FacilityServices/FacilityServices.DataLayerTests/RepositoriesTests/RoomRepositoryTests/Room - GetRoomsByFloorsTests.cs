using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Collections.Generic;
using System.Reflection;

namespace FacilityServices.DataLayerTests.RepositoriesTests.RoomRepositoryTest
{
    [TestClass]
    public class GetRoomsByFloorsTests
    {
        [TestMethod]
        public void GetRoomsByFloors_ReturnCorrectNumberOfCorrespondingRooms()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FacilityContext(options);
            IRoomRepository roomRepository = new RoomRepository(context);
            IFloorRepository floorRepository = new FloorRepository(context);

            var floor = new FloorTO { Number = 2 };
            var floor2 = new FloorTO { Number = -1 };
            var addedFloor1 = floorRepository.Add(floor);
            var addedFloor2 = floorRepository.Add(floor2);
            context.SaveChanges();

            RoomTO room1 = new RoomTO { Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = addedFloor1 };
            RoomTO room2 = new RoomTO { Name = new MultiLanguageString("Room2", "Room2", "Room2"), Floor = addedFloor1 };
            RoomTO room3 = new RoomTO { Name = new MultiLanguageString("Room3", "Room3", "Room3"), Floor = addedFloor2 };

            roomRepository.Add(room1);
            roomRepository.Add(room2);
            roomRepository.Add(room3);
            context.SaveChanges();

            var result1 = roomRepository.GetRoomsByFloor(addedFloor1.Id);
            var result2 = roomRepository.GetRoomsByFloor(addedFloor2.Id);

            Assert.IsNotNull(result1);
            Assert.IsNotNull(result2);
            Assert.AreEqual(2, result1.Count);
            Assert.AreEqual(1, result2.Count);
        }

        [TestMethod]
        public void GetRoomsByFloor_ThrowException_WhenUnexistingFloorIdIsSupplied()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FacilityContext(options);
            IRoomRepository roomRepository = new RoomRepository(context);

            //ACT & ASSERT
            Assert.ThrowsException<KeyNotFoundException>(() => roomRepository.GetRoomsByFloor(999));
        }
    }
}