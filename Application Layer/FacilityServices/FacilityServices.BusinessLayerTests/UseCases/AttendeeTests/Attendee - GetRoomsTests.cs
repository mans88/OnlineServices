using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.BusinessLayerTests.UseCases.AttendeeTests
{
    [TestClass]
    public class Attendee_GetRoomsTests
    {
        [TestMethod]
        public void GetRooms_AddThreeRooms_ThenRetrieveThem_ReturnCorrectNumberOfRooms()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var rooms = new List<RoomTO>
            {
                new RoomTO { Id = 1, Archived = false, Name = new MultiLanguageString("Reims2", "Reims2", "Reims2"), Floor = new FloorTO {Id = 1 } },
                new RoomTO{ Id = 2, Archived = false, Name = new MultiLanguageString("Reims2", "Reims2", "Reims2"), Floor = new FloorTO {Id = 2 }  },
                new RoomTO{ Id = 3, Archived = false, Name = new MultiLanguageString("Reims2", "Reims2", "Reims2"), Floor = new FloorTO {Id = 3 } }
            };
            mockUnitOfWork.Setup(u => u.RoomRepository.GetAll()).Returns(rooms);
            var sut = new AttendeeRole(mockUnitOfWork.Object);
            //ACT
            var listOfRooms = sut.GetRooms();
            //ASSERT
            mockUnitOfWork.Verify(u => u.RoomRepository.GetAll(), Times.Once);
            Assert.AreEqual(3, listOfRooms.Count());
        }
    }
}