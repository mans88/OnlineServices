using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer;
using RegistrationServices.DataLayer.Repositories;
using System;
using System.Linq;
using System.Reflection;

namespace RegistrationServices.DataLayerTests.RepositoriesTests.CourseRepositoryTests
{
    [TestClass]
    public class Course_GetCoursesTests
    {
        [TestMethod]
        public void GetCourseById_ThrowsException_WhenInvalidIdIsProvided()
        {
            var options = new DbContextOptionsBuilder<RegistrationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using (var memoryCtx = new RegistrationContext(options))
            {
                var courseRepository = new CourseRepository(memoryCtx);
                Assert.ThrowsException<NullReferenceException>(() => courseRepository.GetById(84));
            }
        }
        [TestMethod]
        public void GetCourseById_Successfull()
        {
            // ARRANGE
            var option = new DbContextOptionsBuilder<RegistrationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var memoryCtx = new RegistrationContext(option);
            var courseRepository = new CourseRepository(memoryCtx);

            var course1 = new CourseTO() {Name = "course1" };
            var course2 = new CourseTO() { Name = "course2" };
            courseRepository.Add(course1);
            courseRepository.Add(course2);
            memoryCtx.SaveChanges();
            // ACT 
            courseRepository.GetById(1);
            // ASSERT
            Assert.AreEqual("course1", course1.Name);
        }
        [TestMethod]
        public void GetAllCourses_Successfull()
        {
            //ARRANGE
            var option = new DbContextOptionsBuilder<RegistrationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using var memoryCtx = new RegistrationContext(option);
            var courseRepository = new CourseRepository(memoryCtx);

            var course1 = new CourseTO() { Name = "course1" };
            var course2 = new CourseTO() { Name = "course2" };
            var course3 = new CourseTO() { Name = "course3" };
            var course4 = new CourseTO() { Name = "course4" };
            courseRepository.Add(course1);
            courseRepository.Add(course2);
            courseRepository.Add(course3);
            courseRepository.Add(course4);
            memoryCtx.SaveChanges();
            // ACT
            // ASSERT
            Assert.AreEqual(4, courseRepository.GetAll().Count());
        }
    }
}
