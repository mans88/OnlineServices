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
    public class Assistant_AddComponentTypeTests
    {
        [TestMethod]
        public void AddComponentType_CorrectComponentType_ReturnComponentTypeNotNull()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.ComponentTypeRepository.Add(It.IsAny<ComponentTypeTO>()))
                          .Returns(new ComponentTypeTO { Id = 1, Archived = false, Name = new MultiLanguageString("Coffee machin", "Machine à café", "en deutch")});
            var sut = new AssistantRole(mockUnitOfWork.Object);
            var componentType = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Coffee machin", "Machine à café", "en deutch") };
            //ACT
            var addedComponentType = sut.AddComponentType(componentType);
            //ASSERT
            mockUnitOfWork.Verify(u => u.ComponentTypeRepository.Add(It.IsAny<ComponentTypeTO>()), Times.Once);
            Assert.IsNotNull(addedComponentType);
            Assert.AreNotEqual(0, addedComponentType.Id);
        }

        [TestMethod]
        public void AddComponentType_NullComponentType_ThrowArgumentNullException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
           var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => sut.AddComponentType(null));
        }
    }
}