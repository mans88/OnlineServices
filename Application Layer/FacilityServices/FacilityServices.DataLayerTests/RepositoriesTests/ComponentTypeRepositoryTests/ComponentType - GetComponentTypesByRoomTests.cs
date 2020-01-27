using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.FacilityServices.Exceptions;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FacilityServices.DataLayerTests.RepositoriesTests.ComponentTypeRepositoryTests
{
    [TestClass]
    public class GetComponentTypesByRoomTests
    {
        [TestMethod]
        public void GetComponentTypeByRoom_ThrowsException_WhenInvalidRoomIdIsProvided()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using (var memoryCtx = new FacilityContext(options))
            {
                var componentTypeRepository = new ComponentTypeRepository(memoryCtx);


                Assert.ThrowsException<KeyNotFoundException>(() => componentTypeRepository.GetComponentTypesByRoom(0));
                Assert.ThrowsException<KeyNotFoundException>(() => componentTypeRepository.GetComponentTypesByRoom(-1));
            }
        }

        [TestMethod]
        public void GetComponentTypeByRoom_Successfull()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FacilityContext(options);
            IRoomRepository roomRepository = new RoomRepository(context);
            IFloorRepository floorRepository = new FloorRepository(context);
            IComponentTypeRepository componentTypeRepository = new ComponentTypeRepository(context);

            //Room(and it's floor)
            var floor = new FloorTO { Number = 2 };
            var addedFloor1 = floorRepository.Add(floor);
            context.SaveChanges();
            //Component
            var componentType1 = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name1En", "Name1Fr", "Name1Nl") };
            var componentType2 = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name2En", "Name2Fr", "Name2Nl") };
            var addedComponentType1 = componentTypeRepository.Add(componentType1);
            var addedComponentType2 = componentTypeRepository.Add(componentType2);
            context.SaveChanges();
            //Floor
            var componentTypes1 = new List<ComponentTypeTO>() { componentType1, componentType2 };
            var componentTypes2 = new List<ComponentTypeTO>() { componentType1 };

            RoomTO room1 = new RoomTO { Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = addedFloor1, ComponentTypes = componentTypes1 };
            RoomTO room2= new RoomTO { Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = addedFloor1, ComponentTypes = componentTypes2 };
            var addedRoom1 = roomRepository.Add(room1);
            var addedRoom2 = roomRepository.Add(room2);
            context.SaveChanges();

            //ACT
            var result = componentTypeRepository.GetComponentTypesByRoom(addedRoom1.Id);
            var result2 = componentTypeRepository.GetComponentTypesByRoom(addedRoom2.Id);
            //ASSERT
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1, result2.Count());
        }
    }
}
