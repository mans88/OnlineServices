using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_AddFloorTests
    {
        [TestMethod]
        public void AddFloor_CorrectFloorGiven_ReturnReturnFloorNotNull()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.FloorRepository.Add(It.IsAny<FloorTO>()))
                          .Returns(new FloorTO { Id = 1, Archived = false , Number = 2 });
            var sut = new AssistantRole(mockUnitOfWork.Object);
            var floor = new FloorTO { Archived = false, Number = 2 };
            //ACT
            var addedfloor = sut.AddFloor(floor);
            //ASSERT
            mockUnitOfWork.Verify(u => u.FloorRepository.Add(It.IsAny<FloorTO>()), Times.Once);
            Assert.IsNotNull(addedfloor);
        }

        [TestMethod]
        public void AddFloor_NullFloorSubmitted_ThrowArgumentNullException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => sut.AddFloor(null));
        }
    }
}