using EvaluationServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.Enumerations;
using OnlineServices.Common.EvaluationServices.Interfaces;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.RegistrationServices;
using OnlineServices.Common.RegistrationServices.TransferObject;
using OnlineServices.Common.TranslationServices.TransfertObjects;
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

        [DataTestMethod]
        [DataRow(0,1,2,1)]
        [DataRow(0,147,258,1)]
        [DataRow(2,1,0,1)]
        [DataRow(-2,-1,0,2)]
        [DataRow(0,-1,-2,2)]
        [DataRow(0,-145,-278,2)]
        public void GetForm_ReturnsRequestedFormTO_WhenAllValuesProvidedAreValid_FinalForm(int deltaDay1, int deltaDay2, int deltaDay3, int expectedFormId)
        {
            //ARRANGE - DATA INPUTS
            var TrainingDay1 = DateTime.Now.AddDays(deltaDay1);
            var TrainingDay2 = DateTime.Now.AddDays(deltaDay2);
            var TrainingDay3 = DateTime.Now.AddDays(deltaDay3);

            //ARRANGE - MOCKS IESUnitOfWork
            var mockUnitOfWork = new Mock<IESUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SubmissionRepository.IsAlreadySubmitted(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(false);
            mockUnitOfWork.Setup(x => x.FormRepository.GetById(It.IsAny<int>()))
                .Returns((int id) => new FormTO() { Id = id, Name = new MultiLanguageString("Form1", "Form1", "Form1") });
            mockUnitOfWork.Setup(x => x.QuestionRepository.GetAllOfForm(It.IsAny<int>()))
                .Returns(new List<QuestionTO> {
                    new QuestionTO() { Id=1, Libelle = new MultiLanguageString("Q1", "Q1", "Q1"), Position=1, Type = QuestionType.Open }
                });

            //ARRANGE - MOCKS IRSServiceRole
            var mockRSServiceRole = new Mock<IRSServiceRole>();
            var SessionToForRSService = new SessionTO
            {
                Id = 1,
                Attendees = new List<UserTO>() { new UserTO { Id = 1 } },
                SessionDays = new List<SessionDayTO>()
                {
                    new SessionDayTO { Id=1, Date = TrainingDay1},
                    new SessionDayTO { Id=2, Date = TrainingDay2},
                    new SessionDayTO { Id=3, Date = TrainingDay3}
                }
            };
            mockRSServiceRole.Setup(x => x.GetSession(It.IsAny<int>())).Returns(SessionToForRSService);

            //ACT
            var attendee = new ESAttendeeRole(mockUnitOfWork.Object, mockRSServiceRole.Object);
            var returnedValue = attendee.GetActiveForm(1, 1);

            //ASSERT
            Assert.IsNotNull(returnedValue);
            Assert.AreEqual(expectedFormId, returnedValue.Id);
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
