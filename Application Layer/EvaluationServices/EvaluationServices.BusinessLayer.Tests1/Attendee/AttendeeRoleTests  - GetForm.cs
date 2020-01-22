using EvaluationServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.Interfaces;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;

namespace EvaluationServices.BusinessLayerTests.Attendee
{
    [TestClass]
    public class AttendeeRole_GetForm
    {
        [TestMethod]
        public void GetForm_Throws_FomrIDInexistant()
        {
            //Arrange
            var moqUnitOfWork = new Mock<IESUnitOfWork>();
            moqUnitOfWork.Setup(x => x.QuestionRepository.GetById(It.IsAny<int>())).Returns(() => default(FormQuestionTO));

            var moqUserService = new Mock<IUserServiceTemp>();
            moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(() => true);


            var sut = new ESAttendeeRole(moqUnitOfWork.Object, moqUserService.Object);
            var SessionID = 1;
            var FormID = 999; //Forms inexistant

            Assert.ThrowsException<Exception>(() => sut.GetFormById(SessionID, FormID));
        }

        [TestMethod]
        public void GetForm_Throws_SessionIDInexistant()
        {
            //Arrange
            var moqUnitOfWork = new Mock<IESUnitOfWork>();
            moqUnitOfWork.Setup(x => x.QuestionRepository.GetById(It.IsAny<int>())).Returns(() => default(FormQuestionTO));
            var moqUserService = new Mock<IUserServiceTemp>();
            moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(() => false);

            var sut = new ESAttendeeRole(moqUnitOfWork.Object, moqUserService.Object);
            var SessionID = 999999999;//session inexistant
            var FormID = 1;

            Assert.ThrowsException<Exception>(() => sut.GetFormById(SessionID, FormID));
        }

        [TestMethod]
        public void GetFormById_ReturnForm_WhenValidParametersIsProvided()
        {
            //Arrange
            var moqUnitOfWork = new Mock<IESUnitOfWork>();

            var forms = new List<FormQuestionTO>();
            forms.Add(new FormQuestionTO { Id = 1 });
            forms.Add(new FormQuestionTO { Id = 2 });

            moqUnitOfWork.Setup(x => x.QuestionRepository.GetAll()).Returns(forms);

            moqUnitOfWork.Setup(x => x.QuestionRepository.GetById(It.IsAny<int>())).Returns(new FormQuestionTO { Id = 1 });

            var moqUserService = new Mock<IUserServiceTemp>();
            moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(true);

            var sut = new ESAttendeeRole(moqUnitOfWork.Object, moqUserService.Object);
            var SessionID = 1;
            var FormID = 1; //Forms inexistant


            //ACT
            var FormToAssert = sut.GetFormById(SessionID, FormID);

            //ASSERT
            moqUnitOfWork.Verify(u => u.QuestionRepository.GetById(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(FormID, FormToAssert.Id);
        }
    }
}
