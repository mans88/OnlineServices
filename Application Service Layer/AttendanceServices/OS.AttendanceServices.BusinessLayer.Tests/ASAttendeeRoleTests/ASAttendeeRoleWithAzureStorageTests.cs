using OS.AttendanceServices.BusinessLayer.UseCases;
using OS.AttendanceServices.DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using OnlineServices.Common.AttendanceServices.Interfaces;
using OnlineServices.Common.AttendanceServices.TransfertObjects;
using OnlineServices.Common.RegistrationServices;
using OnlineServices.Common.RegistrationServices.Enumerations;
using OnlineServices.Common.RegistrationServices.TransferObject;

using System;
using System.Collections.Generic;

namespace OS.AttendanceServices.BusinessLayer.Tests
{
    [TestClass]
    public class ASAttendeeRoleWithAzureStorageTests
    {
        [TestMethod]
        public void CheckIn_True_CorrectInputs_WithAzureRepositoryK()
        {
            var checkInRepository = new CheckInRepository(new AzureStorageCredentials());

            var userServicesMOCK = new Mock<IRSServiceRole>();
            userServicesMOCK.Setup(marge => marge.GetSessionAttendes(It.IsAny<int>()))
                .Returns(new List<UserTO> {
                    new UserTO { Id = 1 }
                    , new UserTO { Id =2 }
                    , new UserTO { Id =3}
                    , new UserTO { Id =4}
                });
            userServicesMOCK.Setup(marge => marge.GetSession(It.IsAny<int>()))
                .Returns(new SessionTO
                {
                    Id = 999999999,
                    SessionDays = new List<SessionDayTO>
                    {
                        new SessionDayTO
                        {
                             Id = 1, Date = DateTime.Now, PresenceType = SessionPresenceType.OnceADay
                        }
                    }
                });

            var checkInArgs = new CheckInTO
            {
                SessionId = 999999999,
                AttendeeId = 3,
                CheckInTime = DateTime.Now
            };

            var eleve = new ASAttendeeRole(checkInRepository, userServicesMOCK.Object);
            var valueToAssert = eleve.CheckIn(checkInArgs);
            Assert.IsTrue(valueToAssert);
        }
    }
}
