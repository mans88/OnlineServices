using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Linq;
using System.Reflection;

namespace FacilityServices.DataLayerTests.RepositoriesTests.RoomRepositoryTest
{
    [TestClass]
    public class GetAllRoomsTests
    {
        [TestMethod]
        public void GetAll_AddThreeRooms_ReturnCorrectNumberOfRooms()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new FacilityContext(options);
            IRoomRepository repository = new RoomRepository(context);
            IFloorRepository floorRepository = new FloorRepository(context);

            var floor = new FloorTO { Number = 2 };
            var floor2 = new FloorTO { Number = -1 };
            var addedFloor1 = floorRepository.Add(floor);
            var addedFloor2 = floorRepository.Add(floor2);
            context.SaveChanges();

            RoomTO room1 = new RoomTO { Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = addedFloor1 };
            RoomTO room2 = new RoomTO { Name = new MultiLanguageString("Room2", "Room2", "Room2"), Floor = addedFloor1 };
            RoomTO room3 = new RoomTO { Name = new MultiLanguageString("Room3", "Room3", "Room3"), Floor = addedFloor2 };
            repository.Add(room1);
            context.SaveChanges();
            repository.Add(room2);
            context.SaveChanges();
            repository.Add(room3);
            context.SaveChanges();
            //ACT
            var rooms = repository.GetAll();
            //ASSERT
            Assert.AreEqual(3, rooms.Count());
        }
    }
}
