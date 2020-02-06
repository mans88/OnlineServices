using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.FacilityServices.Exceptions;
using RegistrationServices.DataLayer;
using RegistrationServices.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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
    }
}
