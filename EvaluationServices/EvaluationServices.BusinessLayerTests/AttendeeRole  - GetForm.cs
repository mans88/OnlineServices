using EvaluationServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using System;
using System.Collections.Generic;

namespace EvaluationServices.BusinessLayerTests
{
    [TestClass]
    public class AttendeeRole_GetForm
    {
        [TestMethod]
        public void GetForm_Throws_FomrIDInexistant()
        {
            //Arrange
            var moqRepo = new Mock<IRepository<FormTO, int>>();
            moqRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(()=>default(FormTO));
            var moqUserService = new Mock<IUserServiceTemp>();
            moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(() =>true);


            var sut = new AttendeeRole(moqRepo.Object, moqUserService.Object);
            var SessionID = 1;
            var FormID = 999; //Forms inexistant
            
            Assert.ThrowsException<Exception>(() => sut.GetForm(SessionID, FormID));
        }

        [TestMethod]
        public void GetForm_Throws_SessionIDInexistant()
        {
            //Arrange
            var moqRepo = new Mock<IRepository<FormTO, int>>();
            moqRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => default(FormTO));
            var moqUserService = new Mock<IUserServiceTemp>();
            moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(() => false);

            var sut = new AttendeeRole(moqRepo.Object, moqUserService.Object);
            var SessionID = 999999999;//session inexistant
            var FormID = 1; 

            Assert.ThrowsException<Exception>(() => sut.GetForm(SessionID, FormID));
        }

        [TestMethod]
        public void GetForm_ReturnForm_WhenValidParametersIsPRovided()
        {
            //Arrange
            var SessionID = 1;
            var FormID = 1; //Forms inexistant

            var moqRepo = new Mock<IRepository<FormTO, int>>();

            moqRepo.Setup(x => x.GetAll()).Returns(() => new List<FormTO> { new FormTO { Id = FormID, SessionID = SessionID } } );
            moqRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => new FormTO { Id = FormID, SessionID = SessionID } );
            var moqUserService = new Mock<IUserServiceTemp>();
            moqUserService.Setup(x => x.IsExistentSession(It.IsAny<int>())).Returns(() => true);

            var sut = new AttendeeRole(moqRepo.Object, moqUserService.Object);


            //ACT
            var FormToAssert = sut.GetForm(SessionID, FormID);

            //ASSERT
            Assert.AreEqual(SessionID, FormToAssert.SessionID);
            Assert.AreEqual(FormID, FormToAssert.Id);
        }
    }
}
