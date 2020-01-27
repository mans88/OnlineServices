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
using System.Text;

namespace FacilityServices.DataLayerTests.RepositoriesTests.RoomRepositoryTest
{
    [TestClass]
    public class RemoveRoomsByIDTests
    {
        [TestMethod]
        public void RemoveById_AddANewRoomAndRemoveTheAddedRoom_ReturnTrue()
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
            var result = repository.Remove(added.Id);
            context.SaveChanges();
            //ASSERT
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveById_ThrowException_WhenInvalidIdIsSupplied()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new FacilityContext(options);
            IRoomRepository repository = new RoomRepository(context);

            //ACT & ASSERT
            Assert.ThrowsException<ArgumentException>(() => repository.Remove(0));
            Assert.ThrowsException<ArgumentException>(() => repository.Remove(-1));
        }
    }
}
