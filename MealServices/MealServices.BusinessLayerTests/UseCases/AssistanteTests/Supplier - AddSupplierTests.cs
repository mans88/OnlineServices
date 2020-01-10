using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MealServices.BusinessLayer.UseCases;
using System;
using OnlineServices.Common.MealServices.TransfertObjects;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.MealServices.Interfaces;

namespace MealServices.BusinessLayerTests.UseCases.AssistanteTests
{
    [TestClass]
    public class Supplier_AddSupplierTests
    {
        [TestMethod()]
        public void AddSupplier_ThrowException_WhenSupplierIDisDiferentOfZero()
        {
            //ARRANGE
            var Assistante = new AssistantRole((new Mock<IMSUnitOfWork>()).Object);
            var SupplierToAdd = new SupplierTO { Id = 10, Name = "ExistantSupplier" };

            //ACT
            Assert.ThrowsException<Exception>( () => Assistante.AddSupplier(SupplierToAdd));
            //TODO TEST IF INSERT IS CALLED Times.None: mockSupplierRepository.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Once);

        }

        [TestMethod()]
        public void AddSupplier_ThrowIsNullOrWhiteSpaceException_WhenSupplierNameISEmptyString()
        {
            //ARRANGE
            var Assistante = new AssistantRole((new Mock<IMSUnitOfWork>()).Object);
            var SupplierToAdd = new SupplierTO { Id = 0, Name = "" };

            //ACT
            Assert.ThrowsException<IsNullOrWhiteSpaceException>(() => Assistante.AddSupplier(SupplierToAdd));
            //TODO TEST IF INSERT IS CALLED Times.None: mockSupplierRepository.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Once);

        }


        [TestMethod()]
        public void AddSupplier_ThrowException_WhenSupplierIsNull()
        {
            //ARRANGE
            var Assistante = new AssistantRole((new Mock<IMSUnitOfWork>()).Object);

            //ACT
            Assert.ThrowsException<ArgumentNullException>(() => Assistante.AddSupplier(null));
            //TODO TEST IF INSERT IS CALLED Times.None: mockSupplierRepository.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Once);

        }

        [TestMethod()]
        public void AddSupplier_ReturnsTrue_WhenAValidSupplierIsProvidedAndAddToDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.Add(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var Assistante = new AssistantRole(mockUoW.Object);
            var SupplierToAdd = new SupplierTO { Id = 0, Name = "InexistantSupplier" };

            //ACT
            var ReturnValueToAssert = Assistante.AddSupplier(SupplierToAdd);

            Assert.IsTrue(ReturnValueToAssert);
        }

        [TestMethod()]
        public void AddSupplier_SupplierRepositoryIsCalledOnce_WhenAValidSupplierIsProvidedAndAddToDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.Add(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var Assistante = new AssistantRole(mockUoW.Object);
            var SupplierToAdd = new SupplierTO { Id = 0, Name = "InexistantSupplier" };

            //ACT
            Assistante.AddSupplier(SupplierToAdd);

            mockSupplierRepository.Verify(x => x.Add(It.IsAny<SupplierTO>()), Times.Once);
        }

        [TestMethod()]
        public void AddSupplier_ReturnsTrueAndSetsDefault_WhenAValidSupplierIsProvidedWithIsDefaultAndAddToDB()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.Add(It.IsAny<SupplierTO>()));
            mockSupplierRepository.Setup(x => x.SetDefaultSupplier(It.IsAny<SupplierTO>()));

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var Assistante = new AssistantRole(mockUoW.Object);
            var SupplierToAdd = new SupplierTO { Id = 0, Name = "InexistantSupplier", IsDefault=true };

            //ACT
            var ReturnValueToAssert = Assistante.AddSupplier(SupplierToAdd);

            Assert.IsTrue(ReturnValueToAssert);
            mockSupplierRepository.Verify(x => x.Add(It.IsAny<SupplierTO>()), Times.Once);
            mockSupplierRepository.Verify(x => x.SetDefaultSupplier(It.IsAny<SupplierTO>()), Times.Once);
        }
    }
}
