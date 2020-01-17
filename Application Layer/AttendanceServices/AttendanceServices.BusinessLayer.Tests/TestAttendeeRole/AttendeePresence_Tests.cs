using AttendanceServices.BusinessLayer.UseCases;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using OnlineServices.Common.AttendanceServices.TransfertObjects;
using OnlineServices.Common.RegistrationServices;
using OnlineServices.Common.RegistrationServices.Enumerations;
using OnlineServices.Common.RegistrationServices.TransferObject;

using System;
using System.Collections.Generic;

namespace AttendanceServices.BusinessLayer.Tests
{
    [TestClass]
    public class AttendeeBL_Tests
    {
        [TestMethod]
        public void SetPresence_Throws_AttendeeNotInFormation()
        {
            var presenceRepositoryMOCK = new Mock<IPresenceRepository>();
            presenceRepositoryMOCK.Setup(homer => homer.Add(It.IsAny<AttendeePresenceTO>())).Returns(new AttendeePresenceTO { Id = 1 });

            var userServicesMOCK = new Mock<IRSServiceRole>();
            userServicesMOCK.Setup(marge => marge.GetSessionAttendes(It.IsAny<int>()))
                .Returns(new List<UserTO> {
                    new UserTO { Id = 1 }
                    , new UserTO { Id =2 }
                    , new UserTO { Id =3}
                    , new UserTO { Id =4}
                });

            var eleve = new ASAttendeeRole(presenceRepositoryMOCK.Object, userServicesMOCK.Object);

            Assert.ThrowsException<Exception>(() => eleve.SetPresence(9999999, 53));
        }

        [TestMethod]
        public void SetPresence_Throws_DataTimeNowNotInFormation()
        {
            var presenceRepositoryMOCK = new Mock<IPresenceRepository>();
            presenceRepositoryMOCK.Setup(homer => homer.Add(It.IsAny<AttendeePresenceTO>())).Returns(new AttendeePresenceTO { Id = 1 });

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
                        new SessionDayTO { Id = 1, DaySession = DateTime.Now.AddDays(2), PresenceType = SessionPresenceType.MorningAfternoon }
                    }
                });


            var eleve = new ASAttendeeRole(presenceRepositoryMOCK.Object, userServicesMOCK.Object);

            Assert.ThrowsException<Exception>(() => eleve.SetPresence(9999999, 3));
        }


        [TestMethod]
        public void SetPresence_True_CorrectInputs()
        {
            var presenceRepositoryMOCK = new Mock<IPresenceRepository>();
            presenceRepositoryMOCK.Setup(homer => homer.Add(It.IsAny<AttendeePresenceTO>())).Returns(new AttendeePresenceTO { Id = 1 });

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
                             Id = 1, DaySession = DateTime.Now, PresenceType = SessionPresenceType.OnceADay
                        }
                    }
                });

            var eleve = new ASAttendeeRole(presenceRepositoryMOCK.Object, userServicesMOCK.Object);
            var valueToAssert = eleve.SetPresence(2, 3);
            Assert.IsTrue(valueToAssert);
        }
    }
}
