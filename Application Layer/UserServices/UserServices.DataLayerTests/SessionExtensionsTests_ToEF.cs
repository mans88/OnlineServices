using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer.Entities;
using RegistrationServices.DataLayer.Extensions;
using System;
using System.Collections.Generic;

namespace RegistrationServices.DataLayerTests
{
    [TestClass]
    public partial class SessionExtensionsTests
    {
        [TestMethod()]
        public void Should_Have_Same_Id_As_TO()
        {
            #region TOInitialization

            UserTO student = new UserTO()
            {
                Id = 1,
                Name = "Jacky Fringant",
                Email = "jacky@supermail.com",
                IsActivated = true,
                Role = UserRole.Attendee,
            };

            UserTO teacher = new UserTO()
            {
                Id = 2,
                Name = "Johnny Begood",
                Email = "johnny@yolomail.com",
                IsActivated = true,
                Role = UserRole.Teacher
            };

            CourseTO sql = new CourseTO()
            {
                Id = 1,
                Name = "SQL"
            };

            SessionTO sessionTO = new SessionTO()
            {
                Id = 1,
                Teacher = teacher,
                Course = sql,
                Dates = new List<DateTime>()
                {
                    new DateTime(2020, 01, 20),
                    new DateTime(2020, 01, 21),
                    new DateTime(2020, 01, 22),
                },

                Attendees = new List<UserTO>()
                {
                    student,
                }
            };

            #endregion TOInitialization

            #region EFInitialization

            UserEF studentEF = new UserEF()
            {
                Id = 1,
                Name = "Jacky Fringant",
                Email = "jacky@supermail.com",
                IsActivated = true,
                Role = UserRole.Attendee,
            };

            UserEF teacherEF = new UserEF()
            {
                Id = 2,
                Name = "Johnny Begood",
                Email = "johnny@yolomail.com",
                IsActivated = true,
                Role = UserRole.Teacher
            };

            CourseEF sqlEF = new CourseEF()
            {
                Id = 1,
                Name = "SQL"
            };

            SessionEF sessionEF = new SessionEF()
            {
                Id = 1,
                Teacher = teacherEF,
                Course = sqlEF,
                Dates = new List<DateTime>()
                {
                    new DateTime(2020, 01, 20),
                    new DateTime(2020, 01, 21),
                    new DateTime(2020, 01, 22),
                },
            };

            List<UserSessionEF> userSessions = new List<UserSessionEF>()
            {
                new UserSessionEF
                {
                    SessionId = sessionEF.Id,
                    UserId = studentEF.Id
                },

                new UserSessionEF
                {
                    SessionId = sessionEF.Id,
                    UserId = teacherEF.Id
                }
            };

            sessionEF.UserSessions = userSessions;

            #endregion EFInitialization

            SessionEF sessionConverted = sessionTO.ToEF();

            Assert.AreEqual(sessionEF.Id, sessionConverted.Id);
        }

        [TestMethod()]
        public void Should_Have_Same_Course_As_TO()
        {
            #region TOInitialization

            UserTO student = new UserTO()
            {
                Id = 1,
                Name = "Jacky Fringant",
                Email = "jacky@supermail.com",
                IsActivated = true,
                Role = UserRole.Attendee,
            };

            UserTO teacher = new UserTO()
            {
                Id = 2,
                Name = "Johnny Begood",
                Email = "johnny@yolomail.com",
                IsActivated = true,
                Role = UserRole.Teacher
            };

            CourseTO sql = new CourseTO()
            {
                Id = 1,
                Name = "SQL"
            };

            SessionTO sessionTO = new SessionTO()
            {
                Id = 1,
                Teacher = teacher,
                Course = sql,
                Dates = new List<DateTime>()
                {
                    new DateTime(2020, 01, 20),
                    new DateTime(2020, 01, 21),
                    new DateTime(2020, 01, 22),
                },

                Attendees = new List<UserTO>()
                {
                    student,
                }
            };

            #endregion TOInitialization

            #region EFInitialization

            UserEF studentEF = new UserEF()
            {
                Id = 1,
                Name = "Jacky Fringant",
                Email = "jacky@supermail.com",
                IsActivated = true,
                Role = UserRole.Attendee,
            };

            UserEF teacherEF = new UserEF()
            {
                Id = 2,
                Name = "Johnny Begood",
                Email = "johnny@yolomail.com",
                IsActivated = true,
                Role = UserRole.Teacher
            };

            CourseEF sqlEF = new CourseEF()
            {
                Id = 1,
                Name = "SQL"
            };

            SessionEF sessionEF = new SessionEF()
            {
                Id = 1,
                Teacher = teacherEF,
                Course = sqlEF,
                Dates = new List<DateTime>()
                {
                    new DateTime(2020, 01, 20),
                    new DateTime(2020, 01, 21),
                    new DateTime(2020, 01, 22),
                },
            };

            List<UserSessionEF> userSessions = new List<UserSessionEF>()
            {
                new UserSessionEF
                {
                    SessionId = sessionEF.Id,
                    UserId = studentEF.Id
                },

                new UserSessionEF
                {
                    SessionId = sessionEF.Id,
                    UserId = teacherEF.Id
                }
            };

            sessionEF.UserSessions = userSessions;

            #endregion EFInitialization

            SessionEF sessionConverted = sessionTO.ToEF();

            Assert.AreEqual(sessionEF.Course.Id, sessionConverted.Course.Id);
            Assert.AreEqual(sessionEF.Course.Name, sessionConverted.Course.Name);
        }

        [TestMethod()]
        public void Should_Have_Same_Teacher_As_TO()
        {
            #region TOInitialization

            UserTO student = new UserTO()
            {
                Id = 1,
                Name = "Jacky Fringant",
                Email = "jacky@supermail.com",
                IsActivated = true,
                Role = UserRole.Attendee,
            };

            UserTO teacher = new UserTO()
            {
                Id = 2,
                Name = "Johnny Begood",
                Email = "johnny@yolomail.com",
                IsActivated = true,
                Role = UserRole.Teacher
            };

            CourseTO sql = new CourseTO()
            {
                Id = 1,
                Name = "SQL"
            };

            SessionTO sessionTO = new SessionTO()
            {
                Id = 1,
                Teacher = teacher,
                Course = sql,
                Dates = new List<DateTime>()
                {
                    new DateTime(2020, 01, 20),
                    new DateTime(2020, 01, 21),
                    new DateTime(2020, 01, 22),
                },

                Attendees = new List<UserTO>()
                {
                    student,
                }
            };

            #endregion TOInitialization

            #region EFInitialization

            UserEF studentEF = new UserEF()
            {
                Id = 1,
                Name = "Jacky Fringant",
                Email = "jacky@supermail.com",
                IsActivated = true,
                Role = UserRole.Attendee,
            };

            UserEF teacherEF = new UserEF()
            {
                Id = 2,
                Name = "Johnny Begood",
                Email = "johnny@yolomail.com",
                IsActivated = true,
                Role = UserRole.Teacher
            };

            CourseEF sqlEF = new CourseEF()
            {
                Id = 1,
                Name = "SQL"
            };

            SessionEF sessionEF = new SessionEF()
            {
                Id = 1,
                Teacher = teacherEF,
                Course = sqlEF,
                Dates = new List<DateTime>()
                {
                    new DateTime(2020, 01, 20),
                    new DateTime(2020, 01, 21),
                    new DateTime(2020, 01, 22),
                },
            };

            List<UserSessionEF> userSessions = new List<UserSessionEF>()
            {
                new UserSessionEF
                {
                    SessionId = sessionEF.Id,
                    UserId = studentEF.Id
                },

                new UserSessionEF
                {
                    SessionId = sessionEF.Id,
                    UserId = teacherEF.Id
                }
            };

            sessionEF.UserSessions = userSessions;

            #endregion EFInitialization

            SessionEF sessionConverted = sessionTO.ToEF();

            Assert.AreEqual(sessionEF.Teacher.Id, sessionConverted.Teacher.Id);
        }

        [TestMethod()]
        public void Should_Have_Two_UserSessions()
        {
            #region TOInitialization

            UserTO student = new UserTO()
            {
                Id = 1,
                Name = "Jacky Fringant",
                Email = "jacky@supermail.com",
                IsActivated = true,
                Role = UserRole.Attendee,
            };

            UserTO teacher = new UserTO()
            {
                Id = 2,
                Name = "Johnny Begood",
                Email = "johnny@yolomail.com",
                IsActivated = true,
                Role = UserRole.Teacher
            };

            CourseTO sql = new CourseTO()
            {
                Id = 1,
                Name = "SQL"
            };

            SessionTO sessionTO = new SessionTO()
            {
                Id = 1,
                Teacher = teacher,
                Course = sql,
                Dates = new List<DateTime>()
                {
                    new DateTime(2020, 01, 20),
                    new DateTime(2020, 01, 21),
                    new DateTime(2020, 01, 22),
                },

                Attendees = new List<UserTO>()
                {
                    student,
                }
            };

            #endregion TOInitialization

            #region EFInitialization

            UserEF studentEF = new UserEF()
            {
                Id = 1,
                Name = "Jacky Fringant",
                Email = "jacky@supermail.com",
                IsActivated = true,
                Role = UserRole.Attendee,
            };

            UserEF teacherEF = new UserEF()
            {
                Id = 2,
                Name = "Johnny Begood",
                Email = "johnny@yolomail.com",
                IsActivated = true,
                Role = UserRole.Teacher
            };

            CourseEF sqlEF = new CourseEF()
            {
                Id = 1,
                Name = "SQL"
            };

            SessionEF sessionEF = new SessionEF()
            {
                Id = 1,
                Teacher = teacherEF,
                Course = sqlEF,
                Dates = new List<DateTime>()
                {
                    new DateTime(2020, 01, 20),
                    new DateTime(2020, 01, 21),
                    new DateTime(2020, 01, 22),
                },
            };

            List<UserSessionEF> userSessions = new List<UserSessionEF>()
            {
                new UserSessionEF
                {
                    SessionId = sessionEF.Id,
                    UserId = studentEF.Id
                },

                new UserSessionEF
                {
                    SessionId = sessionEF.Id,
                    UserId = teacherEF.Id
                }
            };

            sessionEF.UserSessions = userSessions;

            #endregion EFInitialization

            SessionEF sessionConverted = sessionTO.ToEF();

            Assert.AreEqual(sessionEF.UserSessions.Count, sessionConverted.UserSessions.Count);
        }
    }
}