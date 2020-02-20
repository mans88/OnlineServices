using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.RegistrationServices.Interfaces;
using RegistrationServices.DataLayer;
using RegistrationServices.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RegistrationServices.DataLayerTests.RepositoriesTests.UserRepositoryTests
{
    [TestClass]
    class User_GetByRoleTests
    {
        [TestMethod]
        public void GetByRole_CorrespondingResult()
        {
            var options = new DbContextOptionsBuilder<RegistrationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var RSCxt = new RegistrationContext(options);
            IRSUserRepository userRepository = new UserRepository(RSCxt);


        }
    }
}
