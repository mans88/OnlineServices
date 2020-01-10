using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MealServices.BusinessLayer.UseCases;
using OnlineServices.Common.MealServices.TransfertObjects;
using System;
using OnlineServices.Common.MealServices.Interfaces;

namespace MealServices.BusinessLayerTests.UseCases.AssistanteTests
{
    [TestClass]
    public class Supplier_SetDefaultSupplierTests
    {
        [TestMethod()]
        public void SetDefaultSupplier_ThrowException_WhenSupplierIDisDifferentOfZero()
        {
            //ARRANGE
            var Assistante = new AssistantRole((new Mock<IMSUnitOfWork>()).Object);
            var SupplierToUpdate = new SupplierTO { Id = 0, Name = "InexistantSupplier" };

            //ACT
            Assert.ThrowsException<Exception>(() => Assistante.SetDefaultSupplier(SupplierToUpdate));
        }

        [TestMethod()]
        public void SetDefaultSupplier_ThrowException_WhenSupplierIsNull()
        {
            //ARRANGE
            var Assistante = new AssistantRole((new Mock<IMSUnitOfWork>()).Object);

            //ACT
            Assert.ThrowsException<ArgumentNullException>(() => Assistante.SetDefaultSupplier(null));
        }

        [TestMethod()]
        public void SetDefaultSupplier_ReturnsTrue_WhenAValidSupplierWithIsDefaultTrueIsProvidedAndUpdatedInDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.SetDefaultSupplier(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var Assistante = new AssistantRole(mockUoW.Object);
            var SupplierToUpdate = new SupplierTO { Id = 10, Name = "ExistantSupplier", IsDefault = true };

            //ACT
            var ReturnValueToAssert = Assistante.SetDefaultSupplier(SupplierToUpdate);

            Assert.IsTrue(ReturnValueToAssert);
        }

        [TestMethod()]
        public void SetDefaultSupplier_ReturnsFalse_WhenAValidSupplierWithIsDefaultFalseIsProvidedAndUpdatedInDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.SetDefaultSupplier(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var Assistante = new AssistantRole(mockUoW.Object);
            var SupplierToUpdate = new SupplierTO { Id = 10, Name = "ExistantSupplier", IsDefault = false };

            //ACT
            Assert.ThrowsException<Exception>(() => Assistante.SetDefaultSupplier(SupplierToUpdate));
        }

        [TestMethod()]
        public void UpdateSupplier_SupplierRepositoryIsCalledOnce_WhenAValidSupplierWithIsDefaultTrueIsProvidedAndUpdatedInDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.SetDefaultSupplier(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var Assistante = new AssistantRole(mockUoW.Object);
            var SupplierToUpdate = new SupplierTO { Id = 10, Name = "ExistantSupplier", IsDefault = true };

            //ACT
            Assistante.SetDefaultSupplier(SupplierToUpdate);

            mockSupplierRepository.Verify(x => x.SetDefaultSupplier(It.IsAny<SupplierTO>()), Times.Once);
        }
        [TestMethod()]
        public void SetDefaultSupplier_SupplierRepositoryIsCalledNone_WhenAValidSupplierWithIsDefaultFalseIsProvidedAndUpdatedInDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.SetDefaultSupplier(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var Assistante = new AssistantRole(mockUoW.Object);
            var SupplierToUpdate = new SupplierTO { Id = 10, Name = "ExistantSupplier", IsDefault = false };

            //ACT
            //Assert.ThrowsException<Exception>(()=>
            try { Assistante.SetDefaultSupplier(SupplierToUpdate); } catch { }

            mockSupplierRepository.Verify(x => x.SetDefaultSupplier(It.IsAny<SupplierTO>()), Times.Never);
        }

        [TestMethod()]
        public void SetDefaultSupplier_ThrowsException_WhenAInvalidSupplierWithIsDefaultTrueIsProvidedAndUpdatedInDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.SetDefaultSupplier(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var Assistante = new AssistantRole(mockUoW.Object);
            var SupplierToUpdate = new SupplierTO { Id = 10, Name = "", IsDefault = true };

            //ACT
            //Assert.ThrowsException<Exception>(()=>
            try { Assistante.SetDefaultSupplier(SupplierToUpdate); } catch { }

            mockSupplierRepository.Verify(x => x.SetDefaultSupplier(It.IsAny<SupplierTO>()), Times.Never);
        }
    }
}
