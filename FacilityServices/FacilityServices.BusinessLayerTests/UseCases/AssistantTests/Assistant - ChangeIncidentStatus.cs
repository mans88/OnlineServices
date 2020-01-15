using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.FacilityServices.Enumerations;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_ChangeIncidentStatus
    {
        [TestMethod]
        public void ChangeIncidentStatus_AddANewIncidentThenChangeTheStatus_ReturnUpdatedIncident()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.IncidentRepository.GetById(It.IsAny<int>()))
                          .Returns(new IncidentTO { Id = 1, Description = "My description", Status = IncidentStatus.Accepted });

            mockUnitOfWork.Setup(u => u.IncidentRepository.Update(It.IsAny<IncidentTO>()))
                         .Returns(new IncidentTO { Id = 1, Description = "My description", Status = IncidentStatus.Resolved });
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT
            var updatedIncident = sut.ChangeIncidentStatus(IncidentStatus.Resolved, 1);
            //ASSERT
            mockUnitOfWork.Verify(u => u.IncidentRepository.GetById(It.IsAny<int>()), Times.Once);
            mockUnitOfWork.Verify(u => u.IncidentRepository.Update(It.IsAny<IncidentTO>()), Times.Once);
            Assert.AreEqual(IncidentStatus.Resolved, updatedIncident.Status);
        }
    }
}