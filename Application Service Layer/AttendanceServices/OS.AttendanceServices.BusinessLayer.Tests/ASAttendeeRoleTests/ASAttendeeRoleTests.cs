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
    public class ASAttendeeRoleTests
    {
        [TestMethod]
        public void CheckIn_Throws_AttendeeNotInFormation()
        {
            var checkInRepositoryMOCK = new Mock<ICheckInRepository>();
            checkInRepositoryMOCK.Setup(homer => homer.Add(It.IsAny<CheckInTO>())).Returns(new CheckInTO { Id = Guid.NewGuid() });

            var userServicesMOCK = new Mock<IRSServiceRole>();
            userServicesMOCK.Setup(marge => marge.GetSessionAttendes(It.IsAny<int>()))
                .Returns(new List<UserTO> {
                    new UserTO { Id = 1 }
                    , new UserTO { Id =2 }
                    , new UserTO { Id =3}
                    , new UserTO { Id =4}
                });

            var eleve = new ASAttendeeRole(checkInRepositoryMOCK.Object, userServicesMOCK.Object);

            var checkInArgs = new CheckInTO
            {
                SessionId = 9999999,
                AttendeeId = 53,
                CheckInTime = DateTime.Now
            };

            Assert.ThrowsException<Exception>(() => eleve.CheckIn(checkInArgs));
        }

        [TestMethod]
        public void CheckIn_Throws_DataTimeNowNotInFormation()
        {
            var checkInRepositoryMOCK = new Mock<ICheckInRepository>();
            checkInRepositoryMOCK.Setup(homer => homer.Add(It.IsAny<CheckInTO>())).Returns(new CheckInTO { Id = Guid.NewGuid() });

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
                    Id = 12,
                    SessionDays = new List<SessionDayTO> {
                        new SessionDayTO { Id = 1, Date = DateTime.Now.AddDays(2), PresenceType = SessionPresenceType.MorningAfternoon }
                    }
                });


            var eleve = new ASAttendeeRole(checkInRepositoryMOCK.Object, userServicesMOCK.Object);

            var checkInArgs = new CheckInTO
            {
                SessionId = 9999999,
                AttendeeId = 3,
                CheckInTime = DateTime.Now
            };

            Assert.ThrowsException<Exception>(() => eleve.CheckIn(checkInArgs));
        }


        [TestMethod]
        public void CheckIn_True_CorrectInputs()
        {
            var checkInRepositoryMOCK = new Mock<ICheckInRepository>();
            checkInRepositoryMOCK.Setup(homer => homer.Add(It.IsAny<CheckInTO>())).Returns(new CheckInTO { Id = Guid.NewGuid() });

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
                    Id = 12,
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
                SessionId = 2,
                AttendeeId = 3,
                CheckInTime = DateTime.Now
            };

            var eleve = new ASAttendeeRole(checkInRepositoryMOCK.Object, userServicesMOCK.Object);
            var valueToAssert = eleve.CheckIn(checkInArgs);
            Assert.IsTrue(valueToAssert);
        }

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
