using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayerTests.UseCases.AttendeeTests
{
    [TestClass]
    public class Attendee_GetRoomsByFloorTests
    {
        [TestMethod]
        public void GetRoomsByFloor_ReturnRooms()
        {
            //ARRANGE
            //Floor
            var floor1 = new FloorTO { Id = 1, Number = 2 };
            var floor2 = new FloorTO { Id = 2, Number = -1 };
            //Room
            var rooms = new List<RoomTO>
            {
                new RoomTO {Id = 1, Archived = false, Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = floor1 },
                new RoomTO {Id = 2, Archived = false, Name = new MultiLanguageString("Room2", "Room2", "Room2"), Floor = floor1 },
                new RoomTO {Id = 3, Archived = false, Name = new MultiLanguageString("Room3", "Room3", "Room3"), Floor = floor2 }
            };

            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.RoomRepository.GetRoomsByFloor(It.IsAny<int>())).Returns(rooms);
            var sut = new FSAttendeeRole(mockUnitOfWork.Object);
            //ACT
            var listOfRooms = sut.GetRoomsByFloor(1);
            //ASSERT
            mockUnitOfWork.Verify(u => u.RoomRepository.GetRoomsByFloor(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(3, listOfRooms.Count);
        }

        [TestMethod]
        public void GetRoomsByFloor_IncorrectRoomID_ThrowLoggedException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new FSAttendeeRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<LoggedException>(() => sut.GetRoomsByFloor(0));
            Assert.ThrowsException<LoggedException>(() => sut.GetRoomsByFloor(-1));
        }

    }
}