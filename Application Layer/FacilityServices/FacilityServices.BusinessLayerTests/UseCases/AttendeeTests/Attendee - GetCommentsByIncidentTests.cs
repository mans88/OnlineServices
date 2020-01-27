using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayerTests.UseCases.AttendeeTests
{
    [TestClass]
    public class GetCommentsByIncidentTests
    {
        [TestMethod]
        public void GetCommentsByIncident_ReturnComments()
        {
            //ARRANGE
            var comments = new List<CommentTO>
            {
                new CommentTO { Id = 1, Incident = new IncidentTO { Id = 1 }, Message = "Message 1", SubmitDate = DateTime.Now, UserId = 1 },
                new CommentTO { Id = 2, Incident = new IncidentTO { Id = 1 }, Message = "Message 2", SubmitDate = DateTime.Now.AddDays(1), UserId = 1 },
                new CommentTO { Id = 3, Incident = new IncidentTO { Id = 1 }, Message = "Message 3", SubmitDate = DateTime.Now.AddDays(2), UserId = 1 },
            };
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CommentRepository.GetCommentsByIncident(It.IsAny<int>())).Returns(comments);
            var sut = new AttendeeRole(mockUnitOfWork.Object);

            //ACT
            var result = sut.GetCommentsByIncident(1);

            //ASSERT
            mockUnitOfWork.Verify(u => u.CommentRepository.GetCommentsByIncident(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void GetCommentsByIncident_ThrowException_WhenInvalidIdIsSupplied()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new AttendeeRole(mockUnitOfWork.Object);

            //ACT & ASSERT
            Assert.ThrowsException<LoggedException>(() => sut.GetCommentsByIncident(0));
            Assert.ThrowsException<LoggedException>(() => sut.GetCommentsByIncident(-1));
        }
    }
}
