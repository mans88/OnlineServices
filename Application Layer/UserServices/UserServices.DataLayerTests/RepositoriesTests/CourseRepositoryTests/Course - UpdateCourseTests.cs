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
    public class Course_UpdateCourseTests
    {
        [TestMethod]
        public void UpdateCourseByTO_Successfull()
        {
            // ARRANGE
            var options = new DbContextOptionsBuilder<RegistrationContext>()
                   .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                   .Options;

            using var context = new RegistrationContext(options);
            var courseRepository = new CourseRepository(context);

            var course1 = new CourseTO() { Name = "SQL Server" };
            var course2 = new CourseTO() { Name = "Azure IoT" };

            // ACT
            var addedCourse1 = courseRepository.Add(course1);
            var addedCourse2 = courseRepository.Add(course2);
            context.SaveChanges();
            addedCourse1.Name = "En fait je me suis trompée";
            courseRepository.Update(addedCourse1);

            // ASSERT
            Assert.AreEqual(2, courseRepository.GetAll().Count());
            Assert.AreEqual("En fait je me suis trompée", addedCourse1.Name);
        }
        [TestMethod]
        public void UpdateCourseByTO_ThrowException_WhenInvalidCourseProvided()
        {
            // ARRANGE
            var options = new DbContextOptionsBuilder<RegistrationContext>()
                   .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                   .Options;

            using var context = new RegistrationContext(options);
            var courseRepository = new CourseRepository(context);

            var course1 = new CourseTO() { Name = "SQL Server" };
            var course2 = new CourseTO() { Name = "Azure IoT" };
            var course3 = new CourseTO() { Id = 3, Name = "Azure AI" };

            // ACT
            var addedCourse1 = courseRepository.Add(course1);
            var addedCourse2 = courseRepository.Add(course2);
            context.SaveChanges();
            addedCourse1.Name = "En fait je me suis trompée";

            // ASSERT
            Assert.ThrowsException<KeyNotFoundException>(() => courseRepository.Update(course3));
        }
    }
}
