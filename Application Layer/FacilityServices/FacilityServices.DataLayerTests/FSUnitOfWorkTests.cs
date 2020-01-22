using FacilityServices.DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FacilityServices.DataLayerTests
{
    [TestClass]
    public class FSUnitOfWorkTests
    {
        [TestMethod]
        public void CTOR_NoException_WhenContextIsProvided()
        {
            var context = new FacilityContext();
            var unitOfWork = new FSUnitOfWork(context);

            Assert.IsNotNull(unitOfWork);
            Assert.IsNotNull(unitOfWork.CommentRepository);
            Assert.IsNotNull(unitOfWork.ComponentTypeRepository);
            Assert.IsNotNull(unitOfWork.FloorRepository);
            Assert.IsNotNull(unitOfWork.IncidentRepository);
            Assert.IsNotNull(unitOfWork.IssueRepository);
            Assert.IsNotNull(unitOfWork.RoomRepository);

            context.Dispose();
            unitOfWork.Dispose();
        }

        [TestMethod]
        public void CTOR_ThrowException_WhenNullIsSupplied()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new FSUnitOfWork(null));
        }

        [TestMethod]
        public void Dispose_ThrowException_WhenCallingMethodOnDisposedObject()
        {
            var context = new FacilityContext();
            var unitOfWork = new FSUnitOfWork(context);
            unitOfWork.Dispose();

            Assert.ThrowsException<ObjectDisposedException>(() => unitOfWork.Save());
        }
    }
}
