using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineServices.Common.RegistrationServices;
using Moq;
using OnlineServices.Common.RegistrationServices.TransferObject;
using OnlineServices.Common.RegistrationServices.Enumerations;

namespace OS.WebAPI.Services.Mocks
{
    public static class RegistrationServicesMockHelper
    {
        public static IRSServiceRole RSServiceRoleObject()
        {
            var userServicesMOCK = new Mock<IRSServiceRole>();

            userServicesMOCK.Setup(marge => marge.GetSessionAttendes(It.IsAny<int>()))
                        .Returns(new List<UserTO> {
                            new UserTO { Id = 1}
                            , new UserTO { Id =2}
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

            return userServicesMOCK.Object;
        }

        public static IRSAttendeeRole RSAttendeeRoleObject()
        {
            var userServicesMOCK = new Mock<IRSAttendeeRole>();

            userServicesMOCK.Setup(marge => marge.GetIdByMail(It.IsAny<string>()))
                        .Returns(1);

            userServicesMOCK.Setup(marge => marge.GetTodaySession(It.IsAny<int>()))
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

            return userServicesMOCK.Object;
        }
    }
}
