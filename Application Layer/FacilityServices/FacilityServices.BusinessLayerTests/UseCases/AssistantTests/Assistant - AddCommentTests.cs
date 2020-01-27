using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.Enumerations;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_AddCommentTests
    {
        [TestMethod]
        public void AddComment_ValidComment_ReturnsCommentNotNull()
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
            var comment = new CommentTO
            {
                Incident = incident,
                Message = "I got in touch with the right people, it'll get fixed soon!",
                SubmitDate = DateTime.Now,
                UserId = 1
            };

            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.CommentRepository.Add(It.IsAny<CommentTO>())).Returns(comment);
            var sut = new AssistantRole(mockUnitOfWork.Object);

            // Act
            var addedComment = sut.AddComment(comment);

            // Assert
            Assert.IsNotNull(addedComment);
            mockUnitOfWork.Verify(u => u.CommentRepository.Add(It.IsAny<CommentTO>()), Times.Once);
        }

        [TestMethod]
        public void AddComment_NullComment_ThrowsException()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.CommentRepository.Add(It.IsAny<CommentTO>()));
            var sut = new AssistantRole(mockUnitOfWork.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.AddComment(null));
            mockUnitOfWork.Verify(u => u.CommentRepository.Add(It.IsAny<CommentTO>()), Times.Never);
        }

        [TestMethod]
        public void AddComment_CommentIdNotZero_ThrowsException()
        {
            // Arrange
            var comment = new CommentTO { Id = 1 };

            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.CommentRepository.Add(It.IsAny<CommentTO>()));
            var sut = new AssistantRole(mockUnitOfWork.Object);

            // Act & Assert
            Assert.ThrowsException<LoggedException>(() => sut.AddComment(comment));
            mockUnitOfWork.Verify(u => u.CommentRepository.Add(It.IsAny<CommentTO>()), Times.Never);
        }

        [TestMethod]
        public void AddComment_IncompleteComment_ThrowsException()
        {
            // Arrange
            var comment = new CommentTO();

            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(uow => uow.CommentRepository.Add(It.IsAny<CommentTO>()));
            var sut = new AssistantRole(mockUnitOfWork.Object);

            // Act & Assert
            Assert.ThrowsException<LoggedException>(() => sut.AddComment(comment));
            mockUnitOfWork.Verify(u => u.CommentRepository.Add(It.IsAny<CommentTO>()), Times.Never);
        }
    }
}