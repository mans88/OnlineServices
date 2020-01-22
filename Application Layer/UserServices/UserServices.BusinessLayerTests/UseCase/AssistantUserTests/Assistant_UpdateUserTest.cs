using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using RegistrationServices.BusinessLayer.UseCase;
using Moq;
using RegistrationServices.BusinessLayer;
using OnlineServices.Common.RegistrationServices.Interfaces;
using OnlineServices.Common.RegistrationServices.TransferObject;
using OnlineServices.Common.Exceptions;

namespace RegistrationServices.BusinessLayerTests.UseCase
{
    [TestClass]
    public class Assistant_UpdateUserTest
    {
        Mock<IRSUnitOfWork> MockUofW = new Mock<IRSUnitOfWork>();
        Mock<IRSUserRepository> MockUserRepository = new Mock<IRSUserRepository>();

        [TestMethod]
        public void UpdateUser_ThrowException_WhenUserIsNull()
        {
            //ARRANGE
            var assistant = new AssistantRole(MockUofW.Object);

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => assistant.UpdateSession(null));
        }

        [TestMethod]
        public void UpdateUser_ThrowException_WhenUserIdIsZero()
        {
            //ARRANGE
            var userIdZero = new UserTO { Id = 0, Name = "User Name" };
            var assistant = new AssistantRole(MockUofW.Object);

            //ASSERT
            Assert.ThrowsException<Exception>(() => assistant.UpdateUser(userIdZero));
        }

        [TestMethod]
        public void UpdateUser_ThrowsIsNullOrWhiteSpaceException_WhenUserNameIsNullIsProvided()
        {
            //ARRANGE
            var userNameWhiteSpace = new UserTO { Id = 1, Name = null };
            var assistant = new AssistantRole(MockUofW.Object);

            //ASSERT
            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => assistant.UpdateUser(userNameWhiteSpace));
        }

        [TestMethod()]
        public void UpdateUser_ThrowsIsNullOrWhiteSpaceException_WhenWhiteSpaceNameIsProvided()
        {
            //ARRANGE
            var userNameWhiteSpace = new UserTO { Id = 1, Name = "" };
            var assistant = new AssistantRole(MockUofW.Object);

            //ASSERT
            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => assistant.UpdateUser(userNameWhiteSpace));
        }

        [TestMethod]
        public void UpdateUser_ReturnsTrue_WhenAValidUserIsProvidedAndUpdatedInDB()
        {
            //ARRANGE
            MockUserRepository.Setup(x => x.Update(It.IsAny<UserTO>())); //.Returns(user);
            MockUofW.Setup(x => x.UserRepository).Returns(MockUserRepository.Object);
            
            var assistant = new AssistantRole(MockUofW.Object);
            var user = new UserTO { Id = 1, Name = "Enrique" };

            //ASSERT
            Assert.IsTrue(assistant.UpdateUser(user));
        }

        [TestMethod]
        public void UpdateUser_UserRepositoryIsCalledOnce_WhenAValidUserIsProvidedAndUpdatedInDB()
        {
            //ARRANGE
            MockUserRepository.Setup(x => x.Update(It.IsAny<UserTO>()));
            MockUofW.Setup( x => x.UserRepository).Returns(MockUserRepository.Object);
            
            var ass = new AssistantRole(MockUofW.Object);
            var userToUpdate = new UserTO { Id = 1, Name = "Enrique" };

            //ACT
            ass.UpdateUser(userToUpdate);
            MockUserRepository.Verify( x => x.Update(It.IsAny<UserTO>()), Times.Once);
        }
    }
}
