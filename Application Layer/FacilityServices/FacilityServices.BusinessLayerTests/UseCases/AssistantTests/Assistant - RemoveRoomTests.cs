using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_RemoveRoom
    {
        [TestMethod]
        public void RemoveRoom_ReturnTrue()
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

            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.RoomRepository.Update(It.IsAny<RoomTO>()))
                         .Returns(new RoomTO { Id = 1, Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = floor1 });
            mockUnitOfWork.Setup(u => u.RoomRepository.GetAll()).Returns(rooms);

            var sut = new AssistantRole(mockUnitOfWork.Object);
            var room = new RoomTO { Id = 1, Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = floor1 }; 
            //ACT
            var result = sut.RemoveRoom(1);
            //ASSERT
            mockUnitOfWork.Verify(u => u.RoomRepository.Update(It.IsAny<RoomTO>()), Times.Once);
            mockUnitOfWork.Verify(u => u.RoomRepository.GetById(It.IsAny<int>()), Times.Once);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveRoom_IncorrectRoomID_ThrowLoggedException()
        {
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new AssistantRole(mockUnitOfWork.Object);
            Assert.ThrowsException<LoggedException>(() => sut.RemoveRoom(0));
        }

        [TestMethod]
        public void Removeroom_RoomDoesntExist_ThrowKeyNotFoundException()
        {
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.RoomRepository.GetById(It.IsAny<int>())).Returns(() => null);
            var sut = new AssistantRole(mockUnitOfWork.Object);
            
            Assert.ThrowsException<KeyNotFoundException>(() => sut.RemoveRoom(1));
        }
    }
}