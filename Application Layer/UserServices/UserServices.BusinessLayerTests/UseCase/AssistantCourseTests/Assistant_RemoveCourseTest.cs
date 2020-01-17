using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.RegistrationServices.TransferObject;
using OnlineServices.Common.RegistrationServices.Interfaces;
using RegistrationServices.BusinessLayer.UseCase;
using System;
using System.Collections.Generic;
using System.Text;
namespace RegistrationServices.BusinessLayerTests.UseCase
{
    [TestClass]
    public class Assistant_RemoveCourseTest //Assistant_UpdateCourseTest
    {
        Mock<IRSUnitOfWork> MockUofW = new Mock<IRSUnitOfWork>();
        Mock<IRSCourseRepository> MockCourseRepository = new Mock<IRSCourseRepository>();

        [TestMethod]
        public void RemoveCourse_ThrowException_WhenCourseIsNull()
        {
            //ARRANGE
            var assistant = new AssistantRole(MockUofW.Object);

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => assistant.RemoveCourse(null));
        }

        [TestMethod]
        public void RemoveCourse_ThrowException_WhenCourseIdIsZero()
        {
            //ARRANGE
            var courseIdZero = new CourseTO { Id = 0, Name = "User Name" };
            var assistant = new AssistantRole(MockUofW.Object);

            //ASSERT
            Assert.ThrowsException<Exception>(() => assistant.RemoveCourse(courseIdZero));
        }

        [TestMethod]
        public void RemoveCourse_ReturnsTrue_WhenCourseIsProvidedAndRemovedFromDB_Test()
        {
            //ARRANGE
            MockCourseRepository.Setup(x => x.Remove(It.IsAny<CourseTO>()));
            MockUofW.Setup(x => x.CourseRepository).Returns(MockCourseRepository.Object);

            var assistant = new AssistantRole(MockUofW.Object);
            var courseToRemove = new CourseTO { Id = 1, Name = "Course Name" };

            //ASSERT
            Assert.IsTrue(assistant.RemoveCourse(courseToRemove));
        }

        [TestMethod]
        public void RemoveCourse_CourseRepositoryIsCalledOnce_WhenAValidCourseIsProvidedAndRemovedFromDB()
        {
            //ARRANGE
            MockCourseRepository.Setup(x => x.Remove(It.IsAny<CourseTO>()));
            MockUofW.Setup(x => x.CourseRepository).Returns(MockCourseRepository.Object);

            var ass = new AssistantRole(MockUofW.Object);
            var courseToRemoveOnce = new CourseTO { Id = 1, Name = "User Name" };

            //ACT
            ass.RemoveCourse(courseToRemoveOnce);
            MockCourseRepository.Verify(x => x.Remove(It.IsAny<CourseTO>()), Times.Once);
        }

    }
}
