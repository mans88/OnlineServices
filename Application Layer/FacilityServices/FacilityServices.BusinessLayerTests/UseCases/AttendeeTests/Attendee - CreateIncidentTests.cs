using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.Enumerations;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;

namespace FacilityServices.BusinessLayerTests.UseCases.AttendeeTests
{
    [TestClass]
    public class Attendee_CreateIncidentTests
    {
        [TestMethod]
        public void CreateIncident_ValidIncident_ReturnsIncidentNotNull()
        {
            // Arrange
            var floor = new FloorTO { Number = 2 };
            var room = new RoomTO { Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = floor };
            var componentType = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name1EN", "Name1FR", "Name1NL") };
            var issue = new IssueTO { Description = "Broken thing", Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"), ComponentType = componentType };
            var incident = new IncidentTO
            {
                Description = "This thing is broken !",
                Room = room,
                Issue = issue,
                Status = IncidentStatus.Waiting,
                SubmitDate = DateTime.Now,
                UserId = 1,
            };

            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.IncidentRepository.Add(It.IsAny<IncidentTO>())).Returns((IncidentTO incident) =>
            {
                incident.Id = 1;
                return incident;
            });
            var sut = new AttendeeRole(mockUnitOfWork.Object);

            // Act
            var result = sut.CreateIncident(incident);

            // Assert
            Assert.IsTrue(result);
            mockUnitOfWork.Verify(u => u.IncidentRepository.Add(It.IsAny<IncidentTO>()), Times.Once);
        }

        [TestMethod]
        public void CreateIncident_NullIncident_ThrowsException()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.IncidentRepository.Add(It.IsAny<IncidentTO>()));
            var sut = new AttendeeRole(mockUnitOfWork.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.CreateIncident(null));
            mockUnitOfWork.Verify(u => u.CommentRepository.Add(It.IsAny<CommentTO>()), Times.Never);
        }

        [TestMethod]
        public void CreateIncident_IncidentIdNotZero_ThrowsException()
        {
            // Arrange
            var incident = new IncidentTO { Id = 1 };

            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.IncidentRepository.Add(It.IsAny<IncidentTO>()));
            var sut = new AttendeeRole(mockUnitOfWork.Object);

            // Act & Assert
            Assert.ThrowsException<LoggedException>(() => sut.CreateIncident(incident));
            mockUnitOfWork.Verify(u => u.CommentRepository.Add(It.IsAny<CommentTO>()), Times.Never);
        }

        [TestMethod]
        public void CreateIncident_IncompleteIncident_ThrowsException()
        {
            // Arrange
            var incident1 = new IncidentTO(); // Missing Issue & Room

            var componentType = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name1EN", "Name1FR", "Name1NL") };
            var issue = new IssueTO { Description = "Broken thing", Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"), ComponentType = componentType };
            var incident2 = new IncidentTO { Issue = issue }; // Missing Room

            var floor = new FloorTO { Number = 2 };
            var room = new RoomTO { Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = floor };
            var incident3 = new IncidentTO { Room = room }; // Missing Issue

            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.IncidentRepository.Add(It.IsAny<IncidentTO>()));
            var sut = new AttendeeRole(mockUnitOfWork.Object);

            // Act & Assert
            Assert.ThrowsException<LoggedException>(() => sut.CreateIncident(incident1));
            Assert.ThrowsException<LoggedException>(() => sut.CreateIncident(incident2));
            Assert.ThrowsException<LoggedException>(() => sut.CreateIncident(incident3));
            mockUnitOfWork.Verify(u => u.CommentRepository.Add(It.IsAny<CommentTO>()), Times.Never);
        }

        [TestMethod]
        public void CreateIncident_InvalidStatus_ThrowsException()
        {
            // Arrange
            var floor = new FloorTO { Number = 2 };
            var room = new RoomTO { Name = new MultiLanguageString("Room1", "Room1", "Room1"), Floor = floor };
            var componentType = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name1EN", "Name1FR", "Name1NL") };
            var issue = new IssueTO { Description = "Broken thing", Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"), ComponentType = componentType };
            var incident = new IncidentTO
            {
                Description = "This thing is broken !",
                Room = room,
                Issue = issue,
                Status = IncidentStatus.Accepted,
                SubmitDate = DateTime.Now,
                UserId = 1,
            };

            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.IncidentRepository.Add(It.IsAny<IncidentTO>()));
            var sut = new AttendeeRole(mockUnitOfWork.Object);

            // Act & Assert
            Assert.ThrowsException<LoggedException>(() => sut.CreateIncident(incident));
            mockUnitOfWork.Verify(u => u.CommentRepository.Add(It.IsAny<CommentTO>()), Times.Never);
        }
    }
}
