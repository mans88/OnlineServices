using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_UpdateComponentType
    {
        [TestMethod]
        public void UpdateComponentType_ChangeComponentTypeArchivedProp_ReturnUpdatedComponentType()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.ComponentTypeRepository.Update(It.IsAny<ComponentTypeTO>()))
                          .Returns(new ComponentTypeTO { Id = 1, Archived = false, Name = new MultiLanguageString("Coffee machin", "Machine à café", "en deutch") });
            var sut = new AssistantRole(mockUnitOfWork.Object);
            var componentType = new ComponentTypeTO { Id = 1, Archived = false, Name = new MultiLanguageString("Coffee machin", "Machine à café", "en deutch") };
            //ACT
            var updatedComponentType = sut.UpdateComponentType(componentType);
            //ASSERT
            mockUnitOfWork.Verify(u => u.ComponentTypeRepository.Update(It.IsAny<ComponentTypeTO>()), Times.Once);
            Assert.IsNotNull(updatedComponentType);
        }

        [TestMethod]
        public void UpdateComponentType_NullComponentType_ThrowArgumentNullException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateComponentType(null));
        }

        [TestMethod]
        public void UpdateComponentType_IncorrectComponentTypeID_ThrowLoggedException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<LoggedException>(() => sut.UpdateComponentType(new ComponentTypeTO { Archived = false }));
        }
    }
}