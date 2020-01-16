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
    public class Attendee_GetComponentTypesTests
    {
        [TestMethod]
        public void GetComponentTypes_AddThreeComponentTypes_ThenRetrieveThem_ReturnCorrectNumberOfComponentTypes()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var componentTypes = new List<ComponentTypeTO>
            {
                new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name1En", "Name1Fr", "Name1Nl") },
                new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name2En", "Name2Fr", "Name2Nl") },
                new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name3En", "Name3Fr", "Name3Nl") }
            };
            mockUnitOfWork.Setup(u => u.ComponentTypeRepository.GetAll()).Returns(componentTypes);
            var sut = new AttendeeRole(mockUnitOfWork.Object);
            //ACT
            var listOfComponentTypes = sut.GetComponentTypes();
            //ASSERT
            mockUnitOfWork.Verify(u => u.ComponentTypeRepository.GetAll(), Times.Once);
            Assert.AreEqual(3, listOfComponentTypes.Count());
        }
    }
}