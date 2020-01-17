using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using RegistrationServices.BusinessLayer.UseCase;
using Moq;
using RegistrationServices.BusinessLayer;
using OnlineServices.Common.RegistrationServices.Interfaces;
using OnlineServices.Common.RegistrationServices.TransferObject;

namespace RegistrationServices.BusinessLayerTests.UseCase
{
    [TestClass]
    public class Assistant_RemoveSessionTest
    {
        Mock<IRSUnitOfWork> MockUofW = new Mock<IRSUnitOfWork>();
        Mock<IRSSessionRepository> MockSessionRepository = new Mock<IRSSessionRepository>();

        CourseTO course = new CourseTO { Id = 1, Name = "Course Name" };
        UserTO teacher = new UserTO { Id = 1, Name = "Teacher" };

        [TestMethod]
        public void RemoveSession_ThrowException_WhenSessionIsNull()
        {
            //ARRANGE
            var assistant = new AssistantRole(MockUofW.Object);

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => assistant.RemoveSession(null));
        }

        [TestMethod]
        public void RemoveSession_ThrowException_WhenSessionIdIsZero()
        {
            //ARRANGE
            var sessionIdZero = new SessionTO { Id = 0,  Course = null };
            var assistant = new AssistantRole(MockUofW.Object);

            //ASSERT
            Assert.ThrowsException<Exception>(() => assistant.RemoveSession(sessionIdZero));
        }

        [TestMethod]
        public void RemoveSession_ReturnsTrue_WhenSessionIsProvidedAndRemovedFromDB_Test()
        {
            //ARRANGE
            MockSessionRepository.Setup(x => x.Remove(It.IsAny<SessionTO>()));
            MockUofW.Setup(x => x.SessionRepository).Returns(MockSessionRepository.Object);

            var assistant = new AssistantRole(MockUofW.Object);
            var sessionToRemove = new SessionTO { Id = 1, Course = course, Teacher = teacher };

            //ASSERT
            Assert.IsTrue(assistant.RemoveSession(sessionToRemove));
        }

        [TestMethod]
        public void RemoveSession_UserRepositoryIsCalledOnce_WhenAValidSessionIsProvidedAndRemovedFromDB()
        {
            //ARRANGE
            MockSessionRepository.Setup( x => x.Remove(It.IsAny<SessionTO>()));
            MockUofW.Setup(x => x.SessionRepository).Returns(MockSessionRepository.Object);

            var ass = new AssistantRole(MockUofW.Object);
            var sessionToRemoveOnce = new SessionTO { Id = 1, Course = course, Teacher = teacher };

            //ACT
            ass.RemoveSession(sessionToRemoveOnce);
            MockSessionRepository.Verify( x => x.Remove(It.IsAny<SessionTO>()), Times.Once );

        }

    }
}
