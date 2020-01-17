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
    public class Assistant_AddSessionTest
    {
        Mock<IRSUnitOfWork> MockUofW = new Mock<IRSUnitOfWork>();
        Mock<IRSSessionRepository> MockSessionRepository = new Mock<IRSSessionRepository>();

        CourseTO course = new CourseTO { Id = 1, Name = "Course Name" };
        UserTO teacher = new UserTO { Id = 1, Name = "Teacher" };

        [TestMethod]
        public void AddSession_ThrowException_WhenSessionIDisDiferentThanZero()
        {
            //ARRANGE
            var assistant = new AssistantRole( (new Mock<IRSUnitOfWork>()).Object   );
            var sessionToAdd = new SessionTO { Id = 1, Course = null, Teacher = null  };

            //ASSERT
            Assert.ThrowsException<Exception>(  () => assistant.AddSession(sessionToAdd)  );
        }

        [TestMethod]
        public void AddSession_ThrowException_WhenSessionIsNull()
        {
            //ARRANGE
            var assistant = new AssistantRole(MockUofW.Object);

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>( () => assistant.AddSession(null)  );
        }

        [TestMethod]
        public void AddSession_NewSession_Test()
        {

            //ARRANGE
            var newSession = new SessionTO { Id = 0,  Course = course, Teacher = teacher, Attendees = null };

            MockSessionRepository.Setup(x => x.Add(It.IsAny<SessionTO>()));
            var mockUofW = new Mock<IRSUnitOfWork>();
            mockUofW.Setup(x => x.SessionRepository).Returns(MockSessionRepository.Object);

            var assistant = new AssistantRole(mockUofW.Object);

            //ASSERT
            Assert.IsTrue(assistant.AddSession(newSession));
        }

        [TestMethod]
        public void AddSession_UserRepositoryIsCalledOnce_WhenAValidSessionIsProvidedAndAddInDB()
        {
            //ARRANGE
            MockSessionRepository.Setup( x => x.Add(It.IsAny<SessionTO>()) );
            MockUofW.Setup( x => x.SessionRepository).Returns(MockSessionRepository.Object);

            var ass = new AssistantRole(MockUofW.Object);
            var newSession = new SessionTO { Id = 0,  Course = course, Teacher = teacher };

            //ACT
            ass.AddSession(newSession);
            MockSessionRepository.Verify( x => x.Add(It.IsAny<SessionTO>()), Times.Once );
        }
    }
}
