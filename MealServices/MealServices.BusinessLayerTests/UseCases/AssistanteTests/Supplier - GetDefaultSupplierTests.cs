using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MealServices.BusinessLayer.UseCases;
using OnlineServices.Common.MealServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using OnlineServices.Common.MealServices.Interfaces;

namespace MealServices.BusinessLayerTests.UseCases.AssistanteTests
{
    [TestClass]
    public class Supplier_GetDefaultSupplierTests
    {
        public static List<SupplierTO> SupplierList()
        {
            return new List<SupplierTO>
            {
                new SupplierTO { Id=1, Name="Suplier1", IsDefault=false},
                new SupplierTO { Id=2, Name="Suplier3", IsDefault=true},
                new SupplierTO { Id=3, Name="Suplier3", IsDefault=false}
            };
        }
        public static List<SupplierTO> SupplierListWith2True()
        {
            return new List<SupplierTO>
            {
                new SupplierTO { Id=1, Name="Suplier1", IsDefault=true},
                new SupplierTO { Id=2, Name="Suplier3", IsDefault=true},
                new SupplierTO { Id=3, Name="Suplier3", IsDefault=false}
            };
        }

        public static List<SupplierTO> SupplierListWith0True()
        {
            return new List<SupplierTO>
            {
                new SupplierTO { Id=1, Name="Suplier1", IsDefault=false},
                new SupplierTO { Id=2, Name="Suplier3", IsDefault=false},
                new SupplierTO { Id=3, Name="Suplier3", IsDefault=false}
            };
        }

        [TestMethod()]
        public void GetDefaultSupplier_ReturnsSupplierInDB_WhenCalled()
        {
            //ARRANGE
            var SupplierId = 2;
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.GetAll()).Returns(SupplierList());
            mockSupplierRepository.Setup(x => x.GetDefaultSupplier()).Returns(new SupplierTO { Id = SupplierId, Name = $"Suplier{SupplierId}", IsDefault = true });

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var Assistante = new MSAssistantRole(mockUoW.Object);

            //ACT
            var DefaultSupplier = Assistante.GetDefaultSupplier();

            //ASSERT
            Assert.AreEqual(SupplierId, DefaultSupplier.Id);
        }

        [TestMethod()]
        public void GetDefaultSupplier_SupplierRepositoryIsCalledOnce_WhenCalled()
        {
            //ARRANGE
            var SupplierId = 2;
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.GetAll()).Returns(SupplierList());
            mockSupplierRepository.Setup(x => x.GetDefaultSupplier()).Returns(new SupplierTO { Id = SupplierId, Name = $"Suplier{SupplierId}", IsDefault = true });

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var Assistante = new MSAssistantRole(mockUoW.Object);

            //ACT
            var DefaultSupplier = Assistante.GetDefaultSupplier();

            //ASSERT
            mockSupplierRepository.Verify(x => x.GetDefaultSupplier(), Times.Once);
        }

        [TestMethod()]
        public void GetDefaultSupplier_ThrowsException_WhenNoDefaultSupplierIsSetup()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.GetAll()).Returns(SupplierListWith0True());
            mockSupplierRepository.Setup(x => x.GetDefaultSupplier()).Returns(SupplierListWith0True().FirstOrDefault(x=>x.IsDefault==true));

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var Assistante = new MSAssistantRole(mockUoW.Object);

            //ACT & ASSERT
            var ExceptionToTest = Assert.ThrowsException<Exception>(() => Assistante.GetDefaultSupplier());
            Assert.AreEqual($"GetDefaultSupplier(). Default Supplier not well configured in DB", ExceptionToTest.Message);

        }

        [TestMethod()]
        public void GetSuppliers_ThrowsException_WhenMoreThanONEDefaultSupplierIsSetup()
        {
            //ARRANGE
            var mockSupplierRepository = new Mock<ISupplierRepository>();
            mockSupplierRepository.Setup(x => x.GetAll()).Returns(SupplierListWith2True());
            mockSupplierRepository.Setup(x => x.GetDefaultSupplier()).Returns(SupplierListWith2True().FirstOrDefault(x=>x.IsDefault==true));

            var mockUoW = new Mock<IMSUnitOfWork>();
            mockUoW.Setup(x => x.SupplierRepository).Returns(mockSupplierRepository.Object);

            var Assistante = new MSAssistantRole(mockUoW.Object);

            //ACT & ASSERT
            var ExceptionToTest = Assert.ThrowsException<Exception>(() => Assistante.GetDefaultSupplier());
            Assert.AreEqual($"GetDefaultSupplier(). Default Supplier not well configured in DB", ExceptionToTest.Message);
        }
    }
}
