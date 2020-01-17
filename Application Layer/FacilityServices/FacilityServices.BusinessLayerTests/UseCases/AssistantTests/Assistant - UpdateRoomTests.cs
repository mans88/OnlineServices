using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_UpdateRoomTests
    {
        [TestMethod]
        public void UpdateRoom_ReturnUpdatedRoom()
        {
            //Floor
            var floor1 = new FloorTO { Number = 2 };
            var floor2 = new FloorTO { Number = -1 };
            //Room
            var rooms = new List<RoomTO>
            {
                new RoomTO {Id = 1, Archived = false, Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = floor1 },
                new RoomTO {Id = 2, Archived = false, Name = new MultiLanguageString("Room2", "Room2", "Room2"), Floor = floor1 },
                new RoomTO {Id = 3, Archived = false, Name = new MultiLanguageString("Room3", "Room3", "Room3"), Floor = floor2 }
            };
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.RoomRepository.Update(It.IsAny<RoomTO>()))
                          .Returns(new RoomTO { Id = 1, Archived = false, Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = floor1 });
            var sut = new AssistantRole(mockUnitOfWork.Object);
            var room = new RoomTO { Id = 1, Archived = false, Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = floor1 };
            //ACT
            var updatedRoom = sut.UpdateRoom(room);
            //ASSERT
            mockUnitOfWork.Verify(u => u.RoomRepository.Update(It.IsAny<RoomTO>()), Times.Once);
            Assert.IsNotNull(updatedRoom);
        }

        [TestMethod]
        public void UpdateRoom_NullRoomSubmitted_ThrowArgumentNullException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateRoom(null));
        }

        [TestMethod]
        public void UpdateRoom_IncorrectRoomID_ThrowLoggedException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<LoggedException>(() => sut.UpdateRoom(new RoomTO { Archived = false }));
        }
    }
}