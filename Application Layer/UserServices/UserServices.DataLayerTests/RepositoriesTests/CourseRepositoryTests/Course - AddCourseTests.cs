using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.RegistrationServices.Interfaces;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer;
using RegistrationServices.DataLayer.Repositories;
using System;
using System.Linq;
using System.Reflection;


namespace RegistrationServices.DataLayerTests.RepositoriesTests.CourseRepositoryTests
{
    [TestClass]
    public class Course_AddCourseTests
    {
        [TestMethod]
        public void AddCourses_ThrowsException_WhenANonExistingIdIsProvided()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<RegistrationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new RegistrationContext(options);
            IRSCourseRepository courseRepository = new CourseRepository(context);

            //ACT & ASSERT
            Assert.ThrowsException<NullReferenceException>(() => courseRepository.Add(null));
        }
        [TestMethod]

        public void AddCourse_Successful()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<RegistrationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new RegistrationContext(options);
            IRSCourseRepository courseRepository = new CourseRepository(context);

            var course1 = new CourseTO() { Name = "SQL Server"};
            var course2 = new CourseTO() { Name = "Azure IoT" };

            // ACT
            courseRepository.Add(course1);
            courseRepository.Add(course2);
            context.SaveChanges();
            //ASSERT
            Assert.AreEqual(2, courseRepository.GetAll().Count());
        }

        [TestMethod]
        public void AddCourse_ReturnCourse_WhenExistingCourseIsProvided()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<RegistrationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var context = new RegistrationContext(options);
            IRSCourseRepository courseRepository = new CourseRepository(context);

            //var course1 = new CourseTO() { Id = 0, Name = "SQL Server" };
            var course2 = new CourseTO() { Id = 1, Name = "Azure IoT" };

            // ACT
            //courseRepository.Add(course1);
            courseRepository.Add(course2);
            //context.SaveChanges();
            //var addedStuff = courseRepository.Add(course1);
            context.SaveChanges();

            // ASSERT
            //Assert.AreEqual("SQL Server", addedStuff.Name);
            Assert.AreEqual(0, courseRepository.GetAll().Count());
        }
    }

}
