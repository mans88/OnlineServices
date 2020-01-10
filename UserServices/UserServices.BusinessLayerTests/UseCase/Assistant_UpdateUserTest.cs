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
    public class Assistant_UpdateUserTest
    {
        Mock<IRSUnitOfWork> MockUofW = new Mock<IRSUnitOfWork>();
        Mock<IRSUserRepository> MockUserRepository = new Mock<IRSUserRepository>();
        //Mock<ISessionRepository> MockSessionRepository = new Mock<ISessionRepository>();

        [TestMethod]
        public void UpdateUser_ReturnsTrue_WhenAValidUserIsProvidedAndUpdatedInDB()
        {
            var newUser = new UserTO { Id = 1, Name = "Enrique", IsActivated = true, Company = "Company 01", Role = UserRole.Assistant, Email = "user@gmail.com", Sessions = null };

            //HACK: UPDATE instead of ADD
            MockUserRepository.Setup(x => x.Update(It.IsAny<UserTO>())).Returns(newUser);
            MockUofW.Setup(x => x.UserRepository).Returns(MockUserRepository.Object);
            var assistant = new Assistant(MockUofW.Object);

            //Assert
            Assert.IsTrue(assistant.UpdateUser(newUser));
        }


        /*
            UpdateUser_ThrowException_WhenUserIDisDifferentOfZero
            UpdateUser_ReturnsTrue_WhenAValidUserIsProvidedAndUpdatedInDB
            UpdateUser_ThrowException_WhenSupplierIsNull
            UpdateUser_SupplierRepositoryIsCalledOnce_WhenAValidSupplierIsProvidedAndUpdatedInDB
        */

    }
}
