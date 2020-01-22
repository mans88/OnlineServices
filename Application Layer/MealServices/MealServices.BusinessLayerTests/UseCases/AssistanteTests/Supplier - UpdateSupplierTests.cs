using MealServices.BusinessLayer.UseCases;
using OnlineServices.Common.MealServices.Interfaces;
using OnlineServices.Common.MealServices.TransfertObjects;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace MealServices.BusinessLayerTests.UseCases.AssistanteTests
{
    [TestClass]
    public class Supplier_UpdateSupplierTests
    {
        [TestMethod()]
        public void UpdateSupplier_ThrowException_WhenSupplierIDisDifferentOfZero()
        {
            //ARRANGE
            var Assistante = new MSAssistantRole((new Mock<IMSUnitOfWork>()).Object);
            var SupplierToUpdate = new SupplierTO { Id = 0, Name = "InexistantSupplier" };

            //ACT
            Assert.ThrowsException<Exception>(() => Assistante.UpdateSupplier(SupplierToUpdate));
        }

        [TestMethod()]
        public void UpdateSupplier_ThrowException_WhenSupplierIsNull()
        {
            //ARRANGE
            var Assistante = new MSAssistantRole((new Mock<IMSUnitOfWork>()).Object);

            //ACT
            Assert.ThrowsException<ArgumentNullException>(() => Assistante.UpdateSupplier(null));
        }

        [TestMethod()]
        public void UpdateSupplier_ReturnsTrue_WhenAValidSupplierIsProvidedAndUpdatedInDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.Update(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var Assistante = new MSAssistantRole(mockUoW.Object);
            var SupplierToUpdate = new SupplierTO { Id = 10, Name = "ExistantSupplier" };

            //ACT
            var ReturnValueToAssert = Assistante.UpdateSupplier(SupplierToUpdate);

            Assert.IsTrue(ReturnValueToAssert);
        }

        [TestMethod()]
        public void UpdateSupplier_SupplierRepositoryIsCalledOnce_WhenAValidSupplierIsProvidedAndUpdatedInDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.Update(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var Assistante = new MSAssistantRole(mockUoW.Object);
            var SupplierToUpdate = new SupplierTO { Id = 10, Name = "ExistantSupplier" };

            //ACT
            Assistante.UpdateSupplier(SupplierToUpdate);

            mockSupplierRepository.Verify(x => x.Update(It.IsAny<SupplierTO>()), Times.Once);
        }
    }
}
