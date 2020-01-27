using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.Enumerations;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.BusinessLayerTests.UseCases.AttendeeTests
{
    [TestClass]
    public class Attendee_GetUserIncidentsTests
    {
        [TestMethod]
        public void GetUserIncidents_AddThreeIncidentsWithSameUserId_ThenRetrieveThem_ReturnsCorrectNumberOfIncidents()
        {
            // Arrange
            var userId = 1;
            var floor = new FloorTO { Number = 2 };
            var room = new RoomTO { Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = floor };
            var componentType = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name1EN", "Name1FR", "Name1NL") };
            var issue = new IssueTO { Description = "Broken thing", Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"), ComponentType = componentType };
            var incident1 = new IncidentTO
            {
                Description = "This thing is broken !",
                Room = room,
                Issue = issue,
                Status = IncidentStatus.Waiting,
                SubmitDate = DateTime.Now,
                UserId = userId,
            };
            var incident2 = new IncidentTO
            {
                Description = "This thing is still broken !",
                Room = room,
                Issue = issue,
                Status = IncidentStatus.Waiting,
                SubmitDate = DateTime.Now.AddDays(7),
                UserId = userId,
            };
            var incident3 = new IncidentTO
            {
                Description = "This hasn't been fixed yet ?!",
                Room = room,
                Issue = issue,
                Status = IncidentStatus.Waiting,
                SubmitDate = DateTime.Now.AddDays(14),
                UserId = userId,
            };

            var incidents = new List<IncidentTO> { incident1, incident2, incident3 };

            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.IncidentRepository.Add(It.IsAny<IncidentTO>())).Returns(new IncidentTO());
            mockUnitOfWork.Setup(uow => uow.IncidentRepository.GetIncidentsByUserId(It.Is<int>(i => i > 0))).Returns(incidents);
            var sut = new AttendeeRole(mockUnitOfWork.Object);

            // Act
            sut.CreateIncident(incident1);
            sut.CreateIncident(incident2);
            sut.CreateIncident(incident3);
            var userIncidents = sut.GetUserIncidents(userId);

            // Assert
            mockUnitOfWork.Verify(u => u.IncidentRepository.Add(It.IsAny<IncidentTO>()), Times.Exactly(3));
            Assert.AreEqual(3, userIncidents.Count());
        }

        [TestMethod]
        public void GetUserIncidents_ThrowException_WhenInvalidIdIsSupplied()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new AttendeeRole(mockUnitOfWork.Object);

            // Act & Assert
            Assert.ThrowsException<LoggedException>(() => sut.GetUserIncidents(0));
            Assert.ThrowsException<LoggedException>(() => sut.GetUserIncidents(-1));
        }
    }
}