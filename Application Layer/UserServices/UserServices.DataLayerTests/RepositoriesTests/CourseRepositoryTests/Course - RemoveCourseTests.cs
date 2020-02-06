using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer;
using RegistrationServices.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RegistrationServices.DataLayerTests.RepositoriesTests.CourseRepositoryTests
{
    [TestClass]
    public class Course_RemoveCourseTests
    {
        [TestMethod]
        public void RemoveCourse_Successfull()
        {
                // ARRANGE
                var option = new DbContextOptionsBuilder<RegistrationContext>()
                    .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                    .Options;
                using var memoryCtx = new RegistrationContext(option);
                var courseRepository = new CourseRepository(memoryCtx);

                var course1 = new CourseTO() { Name = "course1" };
                var course2 = new CourseTO() { Name = "course2" };
                var addedCourse = courseRepository.Add(course1);
                courseRepository.Add(course2);
                memoryCtx.SaveChanges();
                // ACT 
                courseRepository.Remove(addedCourse);
                memoryCtx.SaveChanges();
                // ASSERT
                Assert.AreEqual(1, courseRepository.GetAll().Count());
                Assert.IsFalse(courseRepository.GetAll().Any(x => x.Id == 1));
        }

        [TestMethod]
        public void RemoveCourse_ThrowException_WhenInvalidCourseIsProvided()
        {
            var option = new DbContextOptionsBuilder<RegistrationContext>()
                    .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                    .Options;
            using var memoryCtx = new RegistrationContext(option);
            var courseRepository = new CourseRepository(memoryCtx);
            var course1 = new CourseTO() { Name = "course1" };

            // ACT & ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => courseRepository.Remove(course1));
        }
    }
}
