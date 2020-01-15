using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_GetFloorsTests
    {
        [TestMethod]
        public void GetFloors_AddThreeFloorsThenRetrieveThem_ReturnCorrectNumberOfFloors()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var floors = new List<FloorTO>
            {
                new FloorTO { Id = 1, Archived = false},
                new FloorTO{ Id = 2, Archived = false },
                new FloorTO{ Id = 3, Archived = false },
            };
            mockUnitOfWork.Setup(u => u.FloorRepository.GetAll()).Returns(floors);
            var sut = new AssistantRole(mockUnitOfWork.Object);            
            //ACT
            var listOfFloors = sut.GetFloors();
            //ASSERT
            mockUnitOfWork.Verify(u => u.FloorRepository.GetAll(), Times.Once);
            Assert.AreEqual(3, listOfFloors.Count());
        }
    }
}