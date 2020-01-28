using EvaluationServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.Interfaces;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.RegistrationServices;
using OnlineServices.Common.RegistrationServices.TransferObject;
using System;
using System.Collections.Generic;

namespace EvaluationServices.BusinessLayerTests
{
    [TestClass]
    public class AttendeeRole_GetFormTests
    {

        [TestMethod]
        public void GetForm_ThrowsSessionInexistante_WhenInvalidSessionIdIsProvided()
        {
            //ESAttendeeRole(IESUnitOfWork iESUnitOfWork, IRSServiceRole iRSServiceRole)
            var mockUnitOfWork = new Mock<IESUnitOfWork>();
            var mockRSServiceRole = new Mock<IRSServiceRole>();
            mockRSServiceRole.Setup(x => x.GetSession(It.IsAny<int>())).Throws<LoggedException>();

            var attendee = new ESAttendeeRole(mockUnitOfWork.Object, mockRSServiceRole.Object);

            Assert.ThrowsException<LoggedException>(() => attendee.GetActiveForm(8888, 4));
        }

        [TestMethod]
        public void GetForm_ThrowsSessionUserNotInSession_WhenValidUserIsProvidedButNotInSession()
        {
            //ESAttendeeRole(IESUnitOfWork iESUnitOfWork, IRSServiceRole iRSServiceRole)
            var mockUnitOfWork = new Mock<IESUnitOfWork>();
            var mockRSServiceRole = new Mock<IRSServiceRole>();
            var SessionToForRSService = new SessionTO
            {
                Id = 1,
                Attendees = new List<UserTO>() { new UserTO { Id = 1 } }
            };

            mockRSServiceRole.Setup(x => x.GetSession(It.IsAny<int>())).Returns(SessionToForRSService);

            var attendee = new ESAttendeeRole(mockUnitOfWork.Object, mockRSServiceRole.Object);

            Assert.ThrowsException<LoggedException>(() => attendee.GetActiveForm(1, 4));
        }
        [TestMethod]
        public void GetForm_ThrowsSessionIsNotHeldToday_WhenValidUserValidSessionIsProvidedAndSessionDaysIsNotToday()
        {
            //ESAttendeeRole(IESUnitOfWork iESUnitOfWork, IRSServiceRole iRSServiceRole)
            var mockUnitOfWork = new Mock<IESUnitOfWork>();
            var mockRSServiceRole = new Mock<IRSServiceRole>();
            var SessionToForRSService = new SessionTO
            {
                Id = 1,
                Attendees = new List<UserTO>() { new UserTO { Id = 1 } },
                SessionDays = new List<SessionDayTO>()
                {
                    new SessionDayTO { Id=1, Date = DateTime.Now.AddDays(-1)},
                    new SessionDayTO { Id=1, Date = DateTime.Now.AddDays(+1)}
                }
            };

            mockRSServiceRole.Setup(x => x.GetSession(It.IsAny<int>())).Returns(SessionToForRSService);

            var attendee = new ESAttendeeRole(mockUnitOfWork.Object, mockRSServiceRole.Object);

            Assert.ThrowsException<LoggedException>(() => attendee.GetActiveForm(1, 1));
        }

        [TestMethod]
        public void GetForm_ReturnsNULL_WhenTodayIsDoesNotHaveAnActiveForm()
        {
            //ESAttendeeRole(IESUnitOfWork iESUnitOfWork, IRSServiceRole iRSServiceRole)
            var mockUnitOfWork = new Mock<IESUnitOfWork>();
            var mockRSServiceRole = new Mock<IRSServiceRole>();
            var SessionToForRSService = new SessionTO
            {
                Id = 1,
                Attendees = new List<UserTO>() { new UserTO { Id = 1 } },
                SessionDays = new List<SessionDayTO>()
                {
                    new SessionDayTO { Id=1, Date = DateTime.Now.AddDays(-1)},
                    new SessionDayTO { Id=1, Date = DateTime.Now},
                    new SessionDayTO { Id=1, Date = DateTime.Now.AddDays(+1)}
                }
            };

            mockRSServiceRole.Setup(x => x.GetSession(It.IsAny<int>())).Returns(SessionToForRSService);

            var attendee = new ESAttendeeRole(mockUnitOfWork.Object, mockRSServiceRole.Object);

            var returnedValue = attendee.GetActiveForm(1, 1);

            Assert.IsNull(returnedValue);
        }

        [TestMethod]
        public void GetForm_ThrowExceptionFormAlreadySubmitted_WhenTodaHasAnActiveFormAlreadySubmmitted_day1()
        {
            //ESAttendeeRole(IESUnitOfWork iESUnitOfWork, IRSServiceRole iRSServiceRole)
            var mockUnitOfWork = new Mock<IESUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SubmissionRepository.IsAlreadySubmitted(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);

            var mockRSServiceRole = new Mock<IRSServiceRole>();
            var SessionToForRSService = new SessionTO
            {
                Id = 1,
                Attendees = new List<UserTO>() { new UserTO { Id = 1 } },
                SessionDays = new List<SessionDayTO>()
                {
                    new SessionDayTO { Id=1, Date = DateTime.Now.AddDays(+1)},
                    new SessionDayTO { Id=1, Date = DateTime.Now},
                    new SessionDayTO { Id=1, Date = DateTime.Now.AddDays(+2)}
                }
            };

            mockRSServiceRole.Setup(x => x.GetSession(It.IsAny<int>())).Returns(SessionToForRSService);

            var attendee = new ESAttendeeRole(mockUnitOfWork.Object, mockRSServiceRole.Object);

            Assert.ThrowsException<LoggedException>(() => attendee.GetActiveForm(1, 1));
        }
        [TestMethod]
        public void GetForm_ThrowExceptionFormAlreadySubmitted_WhenTodaHasAnActiveFormNotSubmmittedButSubmittedDay2Previously_day1()
        {
            //ESAttendeeRole(IESUnitOfWork iESUnitOfWork, IRSServiceRole iRSServiceRole)
            var mockUnitOfWork = new Mock<IESUnitOfWork>();
            mockUnitOfWork.SetupSequence(x => x.SubmissionRepository.IsAlreadySubmitted(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(false) //Form 1 not submitted
                .Returns(true); //Form 2 submitted

            var mockRSServiceRole = new Mock<IRSServiceRole>();
            var SessionToForRSService = new SessionTO
            {
                Id = 1,
                Attendees = new List<UserTO>() { new UserTO { Id = 1 } },
                SessionDays = new List<SessionDayTO>()
                {
                    new SessionDayTO { Id=1, Date = DateTime.Now.AddDays(+1)},
                    new SessionDayTO { Id=1, Date = DateTime.Now},
                    new SessionDayTO { Id=1, Date = DateTime.Now.AddDays(+2)}
                }
            };

            mockRSServiceRole.Setup(x => x.GetSession(It.IsAny<int>())).Returns(SessionToForRSService);

            var attendee = new ESAttendeeRole(mockUnitOfWork.Object, mockRSServiceRole.Object);

            Assert.ThrowsException<LoggedException>(() => attendee.GetActiveForm(1, 1));
        }

        [TestMethod]
        public void GetForm_ThrowExceptionFormAlreadySubmitted_WhenTodaHasAnActiveFormAlreadySubmmitted_day2()
        {
            //ESAttendeeRole(IESUnitOfWork iESUnitOfWork, IRSServiceRole iRSServiceRole)
            var mockUnitOfWork = new Mock<IESUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SubmissionRepository.IsAlreadySubmitted(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);

            var mockRSServiceRole = new Mock<IRSServiceRole>();
            var SessionToForRSService = new SessionTO
            {
                Id = 1,
                Attendees = new List<UserTO>() { new UserTO { Id = 1 } },
                SessionDays = new List<SessionDayTO>()
                {
                    new SessionDayTO { Id=1, Date = DateTime.Now.AddDays(-1)},
                    new SessionDayTO { Id=1, Date = DateTime.Now},
                    new SessionDayTO { Id=1, Date = DateTime.Now.AddDays(-2)}
                }
            };

            mockRSServiceRole.Setup(x => x.GetSession(It.IsAny<int>())).Returns(SessionToForRSService);

            var attendee = new ESAttendeeRole(mockUnitOfWork.Object, mockRSServiceRole.Object);

            Assert.ThrowsException<LoggedException>(() => attendee.GetActiveForm(1, 1));
        }

        [TestMethod]
        public void GetForm_ReturnsFormTO_WhenAllValuesProvidedAreValid_Day1()
        {
            //ESAttendeeRole(IESUnitOfWork iESUnitOfWork, IRSServiceRole iRSServiceRole)
            var mockUnitOfWork = new Mock<IESUnitOfWork>();
            var mockRSServiceRole = new Mock<IRSServiceRole>();
            var SessionToForRSService = new SessionTO
            {
                Id = 1,
                Attendees = new List<UserTO>() { new UserTO { Id = 1 } },
                SessionDays = new List<SessionDayTO>()
                {
                    new SessionDayTO { Id=1, Date = DateTime.Now},
                    new SessionDayTO { Id=1, Date = DateTime.Now.AddDays(+2)},
                    new SessionDayTO { Id=1, Date = DateTime.Now.AddDays(+1)}
                }
            };

            mockRSServiceRole.Setup(x => x.GetSession(It.IsAny<int>())).Returns(SessionToForRSService);

            var attendee = new ESAttendeeRole(mockUnitOfWork.Object, mockRSServiceRole.Object);

            var returnedValue = attendee.GetActiveForm(1, 1);

            Assert.IsNotNull(returnedValue);
        }
    }
}



//        [TestMethod]
//        public void GetForm_Throws_FomrIDInexistant()
//        {
//            //Arrange
//            var moqUnitOfWork = new Mock<IESUnitOfWork>();
//            moqUnitOfWork.Setup(x => x.FormQuestionRepository.GetById(It.IsAny<int>())).Returns(() => default(FormTO));

//            //var moqRepo = new Mock<IRepositoryTemp<Form, int>>();
//            //moqRepo.Setup(x => x.GetByID(It.IsAny<int>())).Returns(() => default(Form));
//            var moqUserService = new Mock<IUserServiceTemp>();
//            moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(() => true);


//            var sut = new ESAttendeeRole(moqUnitOfWork.Object, moqUserService.Object);
//            var SessionID = 1;
//            var FormID = 999; //Forms inexistant

//            Assert.ThrowsException<Exception>(() => sut.GetFormById(SessionID, FormID));
//        }

//        [TestMethod]
//        public void GetForm_Throws_SessionIDInexistant()
//        {
//            //Arrange
//            var moqUnitOfWork = new Mock<IESUnitOfWork>();
//            moqUnitOfWork.Setup(x => x.FormQuestionRepository.GetById(It.IsAny<int>())).Returns(() => default(FormTO));
//            var moqUserService = new Mock<IUserServiceTemp>();
//            moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(() => false);

//            var sut = new ESAttendeeRole(moqUnitOfWork.Object, moqUserService.Object);
//            var SessionID = 999999999;//session inexistant
//            var FormID = 1;

//            Assert.ThrowsException<Exception>(() => sut.GetFormById(SessionID, FormID));
//        }

//        [TestMethod]
//        public void GetForm_ReturnForm_WhenValidParametersIsPRovided()
//        {
//            //Arrange
//            var SessionID = 1;
//            var FormID = 1; //Forms inexistant

//            var moqUnitOfWork = new Mock<IESUnitOfWork>();
//            moqUnitOfWork.Setup(x => x.FormQuestionRepository.GetById(It.IsAny<int>())).Returns(() => default(FormTO));
//            var moqUserService = new Mock<IUserServiceTemp>();
//            moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(() => true);

//            var sut = new ESAttendeeRole(moqUnitOfWork.Object, moqUserService.Object);


//            //ACT
//            var FormToAssert = sut.GetFormById(SessionID, FormID);

//            //ASSERT
//            Assert.AreEqual(FormID, FormToAssert.Id);
//        }
//    }
//}
