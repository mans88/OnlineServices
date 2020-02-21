using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using RegistrationServices.BusinessLayer.UseCase;
using Moq;
using System.Linq;
using OnlineServices.Common.RegistrationServices.Interfaces;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.BusinessLayer.UseCase.Assistant;

namespace RegistrationServices.BusinessLayerTests.UseCase.AssistantSessionTests
{
    [TestClass]
    public class Assistant_GetSessionsTest
    {
        Mock<IRSUnitOfWork> MockUofW = new Mock<IRSUnitOfWork>();
        Mock<IRSSessionRepository> MockSessionRepository = new Mock<IRSSessionRepository>();

        CourseTO course = new CourseTO { Id = 1, Name = "Course" };
        UserTO teacher = new UserTO { Id = 1, Name = "teacher" };

        public List<SessionTO> SessionList()
        {
            return new List<SessionTO>
            {
                new SessionTO { Id=1,  Course = course,  Teacher = teacher },
                new SessionTO { Id=2, Course  = course,  Teacher = teacher},
                new SessionTO { Id=3, Course = course,  Teacher = teacher}
            };
        }

        [TestMethod]
        public void GetSessions_ReturnsAllSessionsFromDB()
        {
            //ARRANGE
            MockSessionRepository.Setup(x => x.GetAll()).Returns(SessionList);
            MockUofW.Setup(x => x.SessionRepository).Returns(MockSessionRepository.Object);

            var ass = new RSAssistantRole(MockUofW.Object);

            //ACT
            var sessions = ass.GetSessions();

            //ASSERT
            Assert.AreEqual(SessionList().Count, sessions.Count);
            Assert.AreEqual(3, sessions.Count);
        }

        [TestMethod]
        public void GetSessions_SessionRepositoryIsCalledOnce()
        {
            //ARRANGE
            MockSessionRepository.Setup(x => x.GetAll()).Returns(SessionList);
            MockUofW.Setup(x => x.SessionRepository).Returns(MockSessionRepository.Object);

            var ass = new RSAssistantRole(MockUofW.Object);

            //ACT
            var SessionsAll = ass.GetSessions();

            //ASSERT
            MockSessionRepository.Verify(x => x.GetAll(), Times.Once);

        }

        [TestMethod]
        public void GetSession_NullReferenceException_WhenSessionIdIsZero()
        {
            //ARRANGE
            int SessionId = 0;
            var Assistante = new RSAssistantRole(new Mock<IRSUnitOfWork>().Object);

            //ASSERT
            Assert.ThrowsException<NullReferenceException>(() => Assistante.GetSessionById(SessionId));
        }

        [TestMethod]
        public void GetSession_ReturnsSessionByIDFromDB()
        {
            //ARRANGE
            int sessionId = 1;
            MockSessionRepository.Setup(x => x.GetById(sessionId)).Returns(SessionList().FirstOrDefault(x => x.Id == sessionId));
            MockUofW.Setup(x => x.SessionRepository).Returns(MockSessionRepository.Object);

            var ass = new RSAssistantRole(MockUofW.Object);

            //ACT
            var SessionById = ass.GetSessionById(sessionId);

            //ASSERT
            Assert.AreEqual(sessionId, SessionById.Id);

        }

        [TestMethod]
        public void GetSession_ReturnsNull_WhenSessionDoesNotExist()
        {
            //ARRANGE
            int SessionId = 10000;
            MockSessionRepository.Setup(x => x.GetById(SessionId)).Returns(SessionList().FirstOrDefault(x => x.Id == SessionId));
            MockUofW.Setup(x => x.SessionRepository).Returns(MockSessionRepository.Object);

            var ass = new RSAssistantRole(MockUofW.Object);

            //ACT
            var SessionById = ass.GetSessionById(SessionId);

            //ASSERT
            Assert.IsNull(SessionById);
        }



    }
}
