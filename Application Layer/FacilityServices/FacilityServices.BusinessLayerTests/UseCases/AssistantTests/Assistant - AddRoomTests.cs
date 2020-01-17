using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_AddRoomTests
    {
        [TestMethod]
        public void AddRoom_CorrectRoomGiven_ReturnReturnRoomNotNull()
        {
            //Floor
            var floor1 = new FloorTO { Number = 2 };
            var floor2 = new FloorTO { Number = -1 };
            //Room
            RoomTO room1 = new RoomTO { Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = floor1 };
            RoomTO room2 = new RoomTO { Name = new MultiLanguageString("Room2", "Room2", "Room2"), Floor = floor1 };
            RoomTO room3 = new RoomTO { Name = new MultiLanguageString("Room3", "Room3", "Room3"), Floor = floor2 };
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.RoomRepository.Add(It.IsAny<RoomTO>()))
                          .Returns(room1);
            var sut = new AssistantRole(mockUnitOfWork.Object);
            var addedroom = sut.AddRoom(room1);
            //ASSERT
            mockUnitOfWork.Verify(u => u.RoomRepository.Add(It.IsAny<RoomTO>()), Times.Once);
            Assert.IsNotNull(addedroom);
        }

        [TestMethod]
        public void AddRoom_NullRoomSubmitted_ThrowArgumentNullException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => sut.AddRoom(null));
        }
    }
}