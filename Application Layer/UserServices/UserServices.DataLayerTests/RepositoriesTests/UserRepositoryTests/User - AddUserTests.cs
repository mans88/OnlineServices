using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.RegistrationServices.Interfaces;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer;
using RegistrationServices.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RegistrationServices.DataLayerTests.RepositoriesTests.UserRepositoryTests
{
    [TestClass]
    public class User_AddUserTests
    {
        [TestMethod]
        public void UserRepositoryInsertInDB_WhenValid()
        {
            var options = new DbContextOptionsBuilder<RegistrationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var RSCxt = new RegistrationContext(options))
            {
                //Arrange
                var userToUse = new UserTO()
                {
                    //Id = 0,
                    Name = "Thomas Lion",
                    Role = UserRole.Assistant,
                    Email = "MaxFuel@Power.com",
                    Company = "Business Formation",
                    IsActivated = true,
                };

                var userRepository = new UserRepository(RSCxt);
                //Act
                userRepository.Add(userToUse);
                RSCxt.SaveChanges();
                //Assert
                Assert.AreEqual(1, userRepository.GetAll().Count());
                //var userToAssert = userRepository.GetById(1);
            }
        }
      
        [TestMethod()]
        public void UserRepositoryNotInsertInDB_WhenInvalid()
        {
            var options = new DbContextOptionsBuilder<RegistrationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var RSCxt = new RegistrationContext(options))
            {
                //Arrange
                IRSUserRepository userRepository = new UserRepository(RSCxt);

                var Teacher = new UserTO()
                {
                    Name = "Max",
                    Email = "Padawan@HighGround.OW",
                    Role = UserRole.Teacher
                };

                var Michou = new UserTO()
                {
                    Id = -420,
                    Name = "Michou Miraisin",
                    Email = "michou@superbg.nada",
                    Role = UserRole.Attendee
                };

                var AddedTeacher = userRepository.Add(Teacher);
                var AddedAttendee = userRepository.Add(Michou);
                RSCxt.SaveChanges();
                //Assert

                Assert.AreEqual(1, userRepository.GetAll().Count());
            }
        }
    }
}

