using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.Exceptions;
using RegistrationServices.BusinessLayer;


namespace RegistrationServices.BusinessLayerTests
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod()]
        public void IsValid_ThrowsIsNullOrWhiteSpaceException_WhenNullNameIsProvided()
        {
            var cou = new Course { Name = null };

            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => cou.IsValid());
        }

        [TestMethod]
        public void IsValid_ThrowsIsNullOrWhiteSpaceException_WhenWhiteSpaceNameIsProvided()
        {
            var cou = new Course { Name = " " };

            Assert.ThrowsException<IsNullOrWhiteSpaceException>( () => cou.IsValid()  );
        }
       
        [TestMethod]
        public void IsValid_ThrowsIsNullOrWhiteSpqceException_WhenEmptyNameIsProvided()
        {
            var cou = new Course { Name = "" };

            Assert.ThrowsException<IsNullOrWhiteSpaceException>( () => cou.IsValid()  );
        }
    }
}
