using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.Exceptions;
using System.Net.Mail;
using RegistrationServices.BusinessLayer;

namespace RegistrationServices.BusinessLayerTests
{
    [TestClass]
    public class UserTest
    {
        User ass = new User { Id = 1, Name = "Assistant", IsActivated = true, Company = "Company 01", Role = UserRole.Assistant, Email = "Assistant@gmail.com" };
        User att = new User { Id = 2, Name = "Attendee", IsActivated = true, Company = "Company 02", Role = UserRole.Attendee, Email = "Attendee@gmail.com" };
        User tea = new User { Id = 3, Name = "Teacher", IsActivated = true, Company = "Company 03", Role = UserRole.Teacher, Email = "Teacher@gmail.com" };
        

        [TestMethod()]
        public void Role_Validation()
        {
            Assert.AreEqual(UserRole.Assistant, ass.Role);
            Assert.AreEqual(UserRole.Attendee, att.Role);
            Assert.AreEqual(UserRole.Teacher, tea.Role);
        }


        [TestMethod()]
        public void IsValid_ThrowsIsNullOrWhiteSpaceException_WhenNullNameIsProvided()
        {
            var us = new Course { Name = null };
            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => us.IsValid());
        }

        [TestMethod]
        public void IsValid_ThrowsIsNullOrWhiteSpaceException_WhenWhiteSpaceNameIsProvided()
        {
            var us = new Course { Name = " " };
            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => us.IsValid());
        }

        [TestMethod]
        public void IsValid_ThrowsIsNullOrWhiteSpqceException_WhenEmptyNameIsProvided()
        {
            var us = new Course { Name = "" };
            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => us.IsValid());
        }


        [TestMethod]
        public void IsValid_Email()
        {
            User noValidEmailUser = new User { Id = 0, Name = "Teacher", IsActivated = true, Company = "Company 03", Role = UserRole.Teacher, Email = "Teacher@gmailcom" };


            Assert.IsTrue(ass.ValidateEmail(ass.Email));
            Assert.IsTrue(att.ValidateEmail(att.Email));
            Assert.IsTrue(tea.ValidateEmail(tea.Email));

            Assert.IsFalse(noValidEmailUser.ValidateEmail(noValidEmailUser.Email));

        }
    }
}
