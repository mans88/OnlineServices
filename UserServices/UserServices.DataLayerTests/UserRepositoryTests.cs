using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;
using RegistrationServices.DataLayer;
using OnlineServices.Common.RegistrationServices.TransferObject;

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
                    Sessions = new List<SessionTO> {
                        new SessionTO
                        {
                            Id = 1,
                            TeacherName = null,
                            Local = "TestLocalSession1",
                            Course = new CourseTO{ 
                                Id = 3,
                                Name = "SQL"
                            },
                            Attendees = null
                        }
                    }

                };
                //Act

                //Assert
            }
        }
    }
}
