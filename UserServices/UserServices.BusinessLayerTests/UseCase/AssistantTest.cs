using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using RegistrationServices.BusinessLayer.UseCase;
using OnlineServices.Common.RegistrationServices.TransferObject;

namespace RegistrationServices.BusinessLayerTests.UseCase
{
    [TestClass]
    public class AssistantTest
    {
        [TestMethod]
        public void AddUser_ThrowException_WhenUserIDisDiferentOfZero() // Exist
        {
            var assistant = new Assistant();
            var userToAdd = new UserTO { Id = 1, Name = "User", IsActivated = true, Company = "Company 01", Role = UserRole.Assistant, Email = "user@gmail.com" };

            Assert.ThrowsException<Exception>(  () => assistant.AddUser(userToAdd)  );
        }


        /*public void AddSupplier_ThrowException_WhenSupplierIDisDiferentOfZero()
        {
            //ARRANGE
            var Assistante = new AssistantRole((new Mock<IMSUnitOfWork>()).Object);
            var SupplierToAdd = new SupplierTO { Id = 10, Name = "ExistantSupplier" };

            //ACT
            Assert.ThrowsException<Exception>(() => Assistante.AddSupplier(SupplierToAdd));
            //TODO TEST IF INSERT IS CALLED Times.None: mockSupplierRepository.Verify(x => x.Insert(It.IsAny<SupplierTO>()), Times.Once);
        }
        */
    }
}
