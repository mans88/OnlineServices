using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_RemoveFloor
    {
        [TestMethod]
        public void RemoveFloor_ReturnTrue()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.FloorRepository.GetById(It.IsAny<int>()))
                          .Returns(new FloorTO { Id = 1, Archived = false, Number = 2 });
            mockUnitOfWork.Setup(u => u.FloorRepository.Update(It.IsAny<FloorTO>()))
                          .Returns(new FloorTO { Id = 1, Archived = true, Number = 2 });
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT
            var result = sut.RemoveFloor(1);
            //ASSERT
            mockUnitOfWork.Verify(u => u.FloorRepository.Update(It.IsAny<FloorTO>()), Times.Once);
            mockUnitOfWork.Verify(u => u.FloorRepository.GetById(It.IsAny<int>()), Times.Once);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveFloor_IncorrectFloorID_ThrowLoggedException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<LoggedException>(() => sut.RemoveFloor(0));
        }

        [TestMethod]
        public void Removefloor_FloorDoesntExist_ThrowKeyNotFoundException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.FloorRepository.GetById(It.IsAny<int>())).Returns(() => null);
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<KeyNotFoundException>(() => sut.RemoveFloor(1));
        }
    }
}