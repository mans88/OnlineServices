using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using RegistrationServices.BusinessLayer.UseCase;
using Moq;
using OnlineServices.Common.Exceptions;
using RegistrationServices.BusinessLayer;
using OnlineServices.Common.RegistrationServices.Interfaces;
using OnlineServices.Common.RegistrationServices.TransferObject;

namespace RegistrationServices.BusinessLayerTests.UseCase
{
    [TestClass]
    public class Assistant_RemoveUserTest
    {
        Mock<IRSUnitOfWork> MockUofW = new Mock<IRSUnitOfWork>();
        Mock<IRSUserRepository> MockUserRepository = new Mock<IRSUserRepository>();
        //Mock<ISessionRepository> MockSessionRepository = new Mock<ISessionRepository>();

        [TestMethod]
        public void RemoveUser_ReturnsTrue_WhenUserIsProvidedAndRemovedFromDB_Test()
        {
            MockUserRepository.Setup(x => x.Remove(It.IsAny<UserTO>()));
            MockUofW.Setup(x => x.UserRepository).Returns(MockUserRepository.Object);

            var assistant = new Assistant(MockUofW.Object);
            var userToRemove = new UserTO { Id = 1, Name = "Enrique", IsActivated = true };

            //Assert
            Assert.IsTrue(assistant.RemoveUser(userToRemove));

        }


    }
}
