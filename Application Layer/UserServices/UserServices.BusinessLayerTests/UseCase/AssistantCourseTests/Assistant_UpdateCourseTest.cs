using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.RegistrationServices.TransferObject;
using OnlineServices.Common.RegistrationServices.Interfaces;
using RegistrationServices.BusinessLayer.UseCase;
using System;
using System.Collections.Generic;
using System.Text;
namespace RegistrationServices.BusinessLayerTests.UseCase
{
    [TestClass]
    public class Assistant_UpdateCourseTest
    {
        Mock<IRSUnitOfWork> MockUofW = new Mock<IRSUnitOfWork>();
        Mock<IRSCourseRepository> MockCourseRepository = new Mock<IRSCourseRepository>();

        [TestMethod]
        public void UpdateCourse_ThrowException_WhenCourseIsNull()
        {
            //ARRANGE
            var ass = new AssistantRole( (new Mock<IRSUnitOfWork>()).Object );

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>( () => ass.UpdateCourse(null) );
        }

        [TestMethod]
        public void UpdateCourse_ThrowException_WhenCourseIdIsZero()
        {
            //ARRANGE
            var ass = new AssistantRole( (new Mock<IRSUnitOfWork>()).Object );
            var course = new CourseTO { Id = 0 };

            //ASSERT
            Assert.ThrowsException<Exception>( () => ass.RemoveCourse(course)  );
        }

        [TestMethod]
        public void UpdateCourse_ThrowsIsNullOrWhiteSpaceException_WhenCourseNameIsNullIsProvided()
        {
            //ARRANGE
            var ass = new AssistantRole(MockUofW.Object);
            var courseNameNull = new CourseTO { Id = 1 , Name = null};

            //ASSERT
            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => ass.UpdateCourse(courseNameNull));
        }

        [TestMethod]
        public void UpdateCourse_ThrowsIsNullOrWhiteSpaceException_WhenWhiteSpaceNameIsProvided()
        {
            //ARRANGE
            var ass = new AssistantRole(MockUofW.Object);
            var courseNameWhiteSpace = new CourseTO { Id = 1, Name = " " };

            //ASSERT
            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => ass.UpdateCourse(courseNameWhiteSpace));
        }

        [TestMethod]
        public void UpdateCourse_ReturnsTrue_WhenAValidCourseIsProvidedAndUpdatedInDB()
        {
            MockCourseRepository.Setup( x => x.Update(It.IsAny<CourseTO>()) );
            MockUofW.Setup(x => x.CourseRepository).Returns(MockCourseRepository.Object);

            var ass = new AssistantRole(MockUofW.Object);
            var course = new CourseTO { Id = 1, Name = "Name" };

            Assert.IsTrue(ass.UpdateCourse(course));
        }

        [TestMethod]
        public void UpdateCourse_CourseRepositoryIsCalledOnce_WhenAValidCourseIsProvidedAndUpdatedInDB()
        {
            //ARRANGE
            MockCourseRepository.Setup( x => x.Update(It.IsAny<CourseTO>()) );
            MockUofW.Setup(x => x.CourseRepository).Returns(MockCourseRepository.Object);

            var ass = new AssistantRole(MockUofW.Object);
            var course = new CourseTO { Id = 1, Name = "Name" };

            //ACT
            ass.UpdateCourse(course);

            //VERIFY
            MockCourseRepository.Verify( x => x.Update(It.IsAny<CourseTO>()), Times.Once );
        }

    }
}
