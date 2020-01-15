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
    public class Assistant_RemoveComponentType
    {
        [TestMethod]
        public void RemoveComponentTypeById__ReturnTrue()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var componentTypes = new List<ComponentTypeTO>
            {
                new ComponentTypeTO{ Id = 1, Archived = false, Name = new MultiLanguageString("Coffee machin", "Machine à café", "en deutch")},
                new ComponentTypeTO{ Id = 2, Archived = false, Name = new MultiLanguageString("PC", "Ordinanteur", "en deutch")}
            };
            mockUnitOfWork.Setup(u => u.ComponentTypeRepository.Remove(It.IsAny<int>())).Returns(true);
            mockUnitOfWork.Setup(u => u.ComponentTypeRepository.GetAll()).Returns(componentTypes);

            var sut = new AssistantRole(mockUnitOfWork.Object);
            var componentType = new ComponentTypeTO { Id = 1, Archived = false, Name = new MultiLanguageString("Coffee machin", "Machine à café", "en deutch") };
            //ACT
            var result = sut.RemoveComponentType(1);
            //ASSERT
            mockUnitOfWork.Verify(u => u.ComponentTypeRepository.Remove(It.IsAny<int>()), Times.Once);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveComponentType_IncorrectComponentTypeID_ThrowLoggedException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<LoggedException>(() => sut.RemoveComponentType(0));
        }

        [TestMethod]
        public void RemoveComponentType_ComponentTypeDoesntExist_ThrowKeyNotFoundException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var componentTypes = new List<ComponentTypeTO>();
            mockUnitOfWork.Setup(u => u.ComponentTypeRepository.GetAll()).Returns(componentTypes);
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<KeyNotFoundException>(() => sut.RemoveComponentType(1));
        }
    }
}