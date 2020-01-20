using EvaluationServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.Interfaces;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;

namespace EvaluationServices.BusinessLayerTests
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

            //var moqRepo = new Mock<IRepositoryTemp<FormQuestionTO, int>>();
            //moqRepo.Setup(x => x.GetByID(It.IsAny<int>())).Returns(() => default(FormQuestionTO));
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
        public void GetForm_ReturnForm_WhenValidParametersIsPRovided()
        {
            //Arrange
            var SessionID = 1;
            var FormID = 1; //Forms inexistant

            var moqUnitOfWork = new Mock<IESUnitOfWork>();
            moqUnitOfWork.Setup(x => x.QuestionRepository.GetById(It.IsAny<int>())).Returns(() => default(FormQuestionTO));
            var moqUserService = new Mock<IUserServiceTemp>();
            moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(() => true);
           
            var sut = new ESAttendeeRole(moqUnitOfWork.Object, moqUserService.Object);


            //ACT
            var FormToAssert = sut.GetFormById(SessionID, FormID);

            //ASSERT
            Assert.AreEqual(FormID, FormToAssert.Id);
        }
    }
}
