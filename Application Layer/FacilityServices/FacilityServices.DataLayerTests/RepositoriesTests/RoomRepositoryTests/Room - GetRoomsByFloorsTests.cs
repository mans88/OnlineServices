using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Linq;
using System.Reflection;

namespace FacilityServices.DataLayerTests.RepositoriesTests.RoomRepositoryTest
{
    [TestClass]
    public class GetRoomsByFloorsTests
    {
        [TestMethod]
        //[Ignore]
        public void GetRoomsByFloors_ReturnCoorectNumberOfCorrespondingRooms()
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

            var firstRoomAdded = roomRepository.Add(room1);
            var secondRoomAdded = roomRepository.Add(room2);
            var thirdRoomAdded = roomRepository.Add(room3);
            context.SaveChanges();

            var retrievedRooms = roomRepository.GetRoomsByFloors(addedFloor1);

            Assert.IsNotNull(retrievedRooms);
            Assert.AreEqual(2, retrievedRooms.Count());
        }
    }
}