using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_CTORTests
    {
        [TestMethod]
        public void AssistantCTOR_NullUnitOfWork_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new AssistantRole(null));
        }
    }
}
