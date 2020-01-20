using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using RegistrationServices.BusinessLayer.UseCase;
using Moq;
using System.Linq;
using OnlineServices.Common.RegistrationServices.Interfaces;
using OnlineServices.Common.RegistrationServices.TransferObject;

namespace RegistrationServices.BusinessLayerTests.UseCase
{
    [TestClass]
    public class Assistant_GetUsersTest
    {
        Mock<IRSUnitOfWork> MockUofW = new Mock<IRSUnitOfWork>();
        Mock<IRSUserRepository> MockUserRepository = new Mock<IRSUserRepository>();

        public static List<UserTO> UserList()
        {
            return new List<UserTO>
            {
                new UserTO { Id=1, Name="Suplier1"},
                new UserTO { Id=2, Name="Suplier3"},
                new UserTO { Id=3, Name="Suplier3"}
            };
        }

        [TestMethod]
        public void GetUsers_ReturnsAllUsersFromDB()
        {
            //ARRANGE
            MockUserRepository.Setup( x=>x.GetAll()).Returns(UserList);
            MockUofW.Setup(x => x.UserRepository).Returns(MockUserRepository.Object);

            var ass = new AssistantRole(MockUofW.Object);

            //ACT
            var users = ass.GetUsers();
            
            //ASSERT
            Assert.AreEqual(UserList().Count, users.Count );
            Assert.AreEqual(3, users.Count );
        }

        [TestMethod]
        public void GetUsers_UserRepositoryIsCalledOnce()
        {
            //ARRANGE
            MockUserRepository.Setup( x => x.GetAll()).Returns(UserList);
            MockUofW.Setup( x => x.UserRepository ).Returns(MockUserRepository.Object);

            var ass = new AssistantRole(MockUofW.Object);

            //ACT
            var usersAll = ass.GetUsers();

            //ASSERT
            MockUserRepository.Verify(x=>x.GetAll(), Times.Once);

        }
        //===============================================================================================================
        /// <summary>
        /// Get UserById Tests
        /// </summary>

        [TestMethod]
        public void GetUser_NullReferenceException_WhenUserIDisZero()
        {
            //ARRANGE
            int userId = 0;
            var Assistante = new AssistantRole((new Mock<IRSUnitOfWork>()).Object);

            //ASSERT
            Assert.ThrowsException<NullReferenceException>(() => Assistante.GetUserById(userId));
        }

        [TestMethod]
        public void GetUser_ReturnsUserByIDFromDB()
        {
            //ARRANGE
            int userId = 1;
            MockUserRepository.Setup(x => x.GetById(userId)).Returns(UserList().FirstOrDefault(x=>x.Id == userId));
            MockUofW.Setup(x => x.UserRepository).Returns(MockUserRepository.Object);

            var ass = new AssistantRole(MockUofW.Object);

            //ACT
            var userById = ass.GetUserById(userId);

            //ASSERT
            Assert.AreEqual(userId ,userById.Id);
        }

        [TestMethod]
        public void GetUser_ReturnsNull_WhenUserDoesNotExist()
        {
            //ARRANGE
            int userId = 10000;
            MockUserRepository.Setup(x => x.GetById(userId)).Returns(UserList().FirstOrDefault(x => x.Id == userId));
            MockUofW.Setup(x => x.UserRepository).Returns(MockUserRepository.Object);

            var ass = new AssistantRole(MockUofW.Object);

            //ACT
            var userById = ass.GetUserById(userId);

            //ASSERT
            Assert.IsNull(userById);
        }


        
    }
}
