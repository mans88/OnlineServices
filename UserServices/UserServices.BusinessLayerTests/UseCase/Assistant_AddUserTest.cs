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
    public class Assistant_AddUserTest
    {
        Mock<IRSUnitOfWork> MockUofW = new Mock<IRSUnitOfWork>();
        Mock<IRSUserRepository> MockUserRepository = new Mock<IRSUserRepository>();
        Mock<IRSSessionRepository> MockSessionRepository = new Mock<IRSSessionRepository>();

        [TestMethod]
        public void AddUser_ThrowException_WhenUserIDisDiferentThanZero()
        {
            var assistant = new Assistant( (new Mock<IRSUnitOfWork>()).Object   );
            var userToAdd = new UserTO { Id = 1, Name = "User", IsActivated = true, Company = "Company1", Role = UserRole.Assistant, Email = "user@gmail.com" };

            //Assert
            Assert.ThrowsException<Exception>(  () => assistant.AddUser(userToAdd)  );
        }

        [TestMethod]
        public void AddUser_ThrowIsNullOrWhiteSpaceException_WhenUserNameIsAnEmptyString()
        {
            var userNameWhiteSpace = new UserTO { Id = 0, Name = "" };
            var userNameNull = new UserTO { Id = 0, Name = null};

            var mockUofW = new Mock<IRSUnitOfWork>();
            var assistant = new Assistant(mockUofW.Object);

            //Assert
            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => assistant.AddUser(userNameWhiteSpace));

            //Assert
            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => assistant.AddUser(userNameNull));
        }

        [TestMethod]
        public void AddUser_ThrowException_WhenLoggedUserIsNull()
        {
            var assistant = new Assistant(MockUofW.Object);

            //Assert
            Assert.ThrowsException<LoggedException>( () => assistant.AddUser(null)  );
        }

        [TestMethod]
        public void AddUser_NewUser_Test()
        {
            var newUser = new UserTO { Id = 0, Name = "Enrique", IsActivated = true, Company = "Company 01", Role = UserRole.Assistant, Email = "user@gmail.com", Sessions = null };

            MockUserRepository.Setup(x => x.Add(It.IsAny<UserTO>())).Returns(newUser);
            var mockUofW = new Mock<IRSUnitOfWork>();
            mockUofW.Setup(x => x.UserRepository).Returns(MockUserRepository.Object);

            var assistant = new Assistant(mockUofW.Object);

            //Assert
            Assert.IsTrue(assistant.AddUser(newUser));
        }

        /*
        [TestMethod]
        public void UpdateUser_Test()
        {
            var newUser = new UserTO { Id = 1, Name = "Enrique", IsActivated = true, Company = "Company 01", Role = UserRole.Assistant, Email = "user@gmail.com", Sessions = null };

            //HACK: UPDATE instead of ADD
            MockUserRepository.Setup(x => x.Update(It.IsAny<UserTO>())).Returns(newUser);
            MockUofW.Setup(x => x.UserRepository).Returns(MockUserRepository.Object);
            var assistant = new Assistant(MockUofW.Object);

            //Assert
            Assert.IsTrue(assistant.UpdateUser(newUser));
        }

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
        */

        /*
                *AddSupplier_ThrowIsNullOrWhiteSpaceException_WhenSupplierNameISEmptyString
                AddSupplier_ThrowException_WhenSupplierIsNull
                AddSupplier_ReturnsTrue_WhenAValidSupplierIsProvidedAndAddToDB
                AddSupplier_SupplierRepositoryIsCalledOnce_WhenAValidSupplierIsProvidedAndAddToDB
                AddSupplier_ReturnsTrueAndSetsDefault_WhenAValidSupplierIsProvidedWithIsDefaultAndAddToDB
        */

        /*public void AddSupplier_ThrowException_WhenSupplierIDisDiferentOfZero()
        {
            //ARRANGE
            var Assistante = new AssistantRole((new Mock<IMSUnitOfWork>()).Object);
            var SupplierToAdd = new SupplierTO { Id = 10, Name = "ExistantSupplier" };

            //ACT
            Assert.ThrowsException<Exception>(() => Assistante.AddSupplier(SupplierToAdd));
            //TODO TEST IF INSERT IS CALLED Times.None: mockSupplierRepository.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Once);
        }

        [TestMethod]
        public void AddUser_NewUser_Test()
        {
            var newUser = new UserTO { Id = 0, Name = "Enrique", IsActivated = true, Company = "Company 01", Role = UserRole.Assistant, Email = "user@gmail.com", Sessions = null };

            var mockUserRepository = new Mock<IUserRepository>();
            var mockSessionRepository = new Mock<ISessionRepository>();

            mockUserRepository.Setup(x => x.Add(It.IsAny<UserTO>())).Returns(newUser);
            var mockUofW = new Mock<IRSUnitOfWork>();
            mockUofW.Setup(x => x.UserRepository).Returns(mockUserRepository.Object);
            //mockUofW.Setup(x => x.SessionRepository).Returns(mockSessionRepository.Object);

            //var mockObject = mockUofW.Object;
            var assistant = new Assistant(mockUofW.Object);

            Assert.IsTrue(assistant.AddUser(newUser));

            //Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => assistant.AddUser(userNameNull));

        }

        */
    }
}
