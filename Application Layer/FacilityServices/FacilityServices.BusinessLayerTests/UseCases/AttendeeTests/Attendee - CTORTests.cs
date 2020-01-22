using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FacilityServices.BusinessLayerTests.UseCases.AttendeeTests
{
    [TestClass]
    public class Attendee_CTORTests
    {
        [TestMethod]
        public void AttendeeCTOR_NullUnitOfWork_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new AttendeeRole(null));
        }
    }
}
