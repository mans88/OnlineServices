using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;
using RegistrationServices.DataLayer;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer.Repositories;
using System.Linq;

namespace RegistrationServices.DataLayerTests
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod()]
        public void UserRepositoryInsertInDB_WhenValid()
        {
            var options = new DbContextOptionsBuilder<RegistrationServicesContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var RSCxt = new RegistrationServicesContext(options))
            {
                //Arrange
                var userToUse = new UserTO()
                {
                    Id = 0,
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
                var userToAssert = userRepository.GetById(1);
            }
        }
    }
}