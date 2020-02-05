using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.RegistrationServices.Interfaces;
using OnlineServices.Common.RegistrationServices.TransferObject;
using RegistrationServices.DataLayer;
using RegistrationServices.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RegistrationServices.DataLayerTests.RepositoriesTests.CourseRepositoryTests
{
    [TestClass]
    class Course_AddCourseTests
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
            Assert.ThrowsException<ArgumentNullException>(() => courseRepository.Add(null));

        }


    }
}
