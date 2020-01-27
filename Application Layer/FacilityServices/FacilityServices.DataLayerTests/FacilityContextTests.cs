using FacilityServices.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace FacilityServices.DataLayerTests
{
    [TestClass]
    public class FacilityContextTests : FacilityContext
    {
        [TestMethod]
        public void DefaultCTOR_Successful()
        {
            var context = new FacilityContext();

            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void OnConfiguring_ThrowException_WhenNullOptionBuilderIsSupplied()
        {
            Assert.ThrowsException<ArgumentNullException>(() => OnConfiguring(null));
        }

        [TestMethod]
        public void OnModelCreating_ThrowException_WhenNullModelBuilderIsSupplied()
        {
            Assert.ThrowsException<ArgumentNullException>(() => OnModelCreating(null));
        }
    }
}
