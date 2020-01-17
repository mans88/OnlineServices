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
    public class Assistant_UpdateSessionTest
    {
        Mock<IRSUnitOfWork> MockUofW = new Mock<IRSUnitOfWork>();
        Mock<IRSSessionRepository> MockSessionRepository = new Mock<IRSSessionRepository>();

        CourseTO course = new CourseTO {Id = 1, Name = "Course" };
        UserTO teacher = new UserTO { Id = 1, Name = "teacher" };

        [TestMethod]
        public void UpdateSession_ThrowException_WhenSessionIsNull()
        {
            //ARRANGE
            var assistant = new AssistantRole(MockUofW.Object);

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => assistant.UpdateSession(null));
        }

        [TestMethod]
        public void UpdateSession_ThrowException_WhenSessionIdIsZero()
        {
            //ARRANGE
            var sessionIdZero = new SessionTO { Id = 0, Course = null };
            var assistant = new AssistantRole(MockUofW.Object);

            //ASSERT
            Assert.ThrowsException<Exception>(() => assistant.UpdateSession(sessionIdZero));
        }

        [TestMethod]
        public void UpdateSession_ReturnsTrue_WhenAValidSessionIsProvidedAndUpdatedInDB()
        {
            //ARRANGE
            MockSessionRepository.Setup(x => x.Update(It.IsAny<SessionTO>()));
            MockUofW.Setup(x => x.SessionRepository).Returns(MockSessionRepository.Object);
            
            var assistant = new AssistantRole(MockUofW.Object);
            var user = new SessionTO { Id = 1, Course = course, Teacher = teacher };

            //ASSERT
            Assert.IsTrue(assistant.UpdateSession(user));
        }

        [TestMethod]
        public void UpdateSession_UserRepositoryIsCalledOnce_WhenAValidSessionIsProvidedAndUpdatedInDB()
        {
            //ARRANGE
            MockSessionRepository.Setup(x => x.Update(It.IsAny<SessionTO>()));
            MockUofW.Setup( x => x.SessionRepository).Returns(MockSessionRepository.Object);
            
            var ass = new AssistantRole(MockUofW.Object);
            var userToUpdate = new SessionTO { Id = 1, Course = course, Teacher = teacher };

            //ACT
            ass.UpdateSession(userToUpdate);
            MockSessionRepository.Verify( x => x.Update(It.IsAny<SessionTO>()), Times.Once);
        }
    }
}
