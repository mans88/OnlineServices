using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using RegistrationServices.DataLayer.Repositories;
using OnlineServices.Common.RegistrationServices.Enumerations;
using System.Linq;
using OnlineServices.Common.RegistrationServices.Interfaces;

namespace RegistrationServices.DataLayerTests
{
    [TestClass]
    public class SessionRepositoryTests
    {
        [TestMethod]
        public void Should_Insert_Session_when_valid()
        {
            var options = new DbContextOptionsBuilder<RegistrationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new RegistrationContext(options);
            IRSUserRepository userRepository = new UserRepository(context);
            //IRSSessionRepository sessionRepository = new SessionRepository(context);

            //using (var ctx = new RegistrationServicesContext(options))
            //{
            //    var session = new SessionTO()
            //    {
            //        Id = 32,
            //        Teacher = new UserTO()
            //        {
            //            Id = 6541,
            //            Name = "Christian",
            //            Email = "gyssels@fartmail.com",
            //            Role = UserRole.Teacher
            //        },
            //        Course = new CourseTO() { Id = 4, Name = "MVC" },

            //        SessionDays = new List<SessionDayTO>()
            //        {
            //            new SessionDayTO()
            //            {
            //                Id = 6, Date = new DateTime(2020,01,22),
            //                PresenceType = SessionPresenceType.MorningAfternoon,
            //            }
            //        },

            //        Attendees = new List<UserTO>()
            //        {
            //            new UserTO()
            //            {
            //                Id = 8986,
            //                Name = "Thierry Margoulin",
            //                Email = "bgdu79@yolo.com",
            //                Role = UserRole.Attendee
            //            }
            //        },
            //    };

            //    var sessionRepo = new SessionRepository(ctx);

            //    //Assert.AreEqual(0, sessionRepo.GetAll().Count());

            //    sessionRepo.Add(session);
            //    ctx.SaveChanges();

            //    Assert.AreEqual(1, sessionRepo.GetAll().Count());
        }
    }
}