using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.FacilityServices.Exceptions;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Linq;
using System.Reflection;

namespace FacilityServices.DataLayerTests.RepositoriesTests.IssueRepositoryTests
{
    [TestClass]
    public class GetIssuesTests
    {
        [TestMethod()]
        public void GetIssueById_ThrowsException_WhenInvalidIdIsProvided()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using (var memoryCtx = new FacilityContext(options))
            {
                var issueRepository = new IssueRepository(memoryCtx);

                Assert.ThrowsException<NullIssueException>(() => issueRepository.GetById(84));
            }
        }
        [TestMethod()]
        public void GetIssueById_Successfull()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using (var memoryCtx = new FacilityContext(options))
            {
                var componentTypeRepository = new ComponentTypeRepository(memoryCtx);

                var componentType = new ComponentTypeTO
                {
                    Archived = false,
                    Name = new MultiLanguageString("Name1En", "Name1Fr", "Name1Nl"),
                };
               
                var addedComponentType1 = componentTypeRepository.Add(componentType);
                memoryCtx.SaveChanges();

                var IssueToUseInTest = new IssueTO
                {
                    Description = "prout",
                    Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"),
                    ComponentType = addedComponentType1,
                };

                var issueRepository = new IssueRepository(memoryCtx);

                issueRepository.Add(IssueToUseInTest);
                memoryCtx.SaveChanges();

                var IssueToAssert = issueRepository.GetById(1);
                Assert.AreEqual(1, IssueToAssert.Id);
                Assert.AreEqual("prout", IssueToAssert.Description);
            }
        }

        [TestMethod()]
        public void GetAllIssues_Successfull()
        {
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;
            using (var memoryCtx = new FacilityContext(options))
            {
                var componentTypeRepository = new ComponentTypeRepository(memoryCtx);

                var componentType = new ComponentTypeTO
                {
                    Archived = false,
                    Name = new MultiLanguageString("Name1En", "Name1Fr", "Name1Nl"),
                };
                var componentType2 = new ComponentTypeTO
                {
                    Archived = false,
                    Name = new MultiLanguageString("Name2En", "Name2Fr", "Name2Nl"),
                };
                var addedComponentType1 = componentTypeRepository.Add(componentType);
                var addedComponentType2 = componentTypeRepository.Add(componentType2);
                memoryCtx.SaveChanges();

                var IssueToUseInTest = new IssueTO
                {
                    Description = "prout",
                    Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"),
                    ComponentType = addedComponentType1,


                };
                var IssueToUseInTest2 = new IssueTO
                {
                    Description = "proutprout",
                    Name = new MultiLanguageString("Issue2EN", "Issue2FR", "Issue2NL"),
                    ComponentType = addedComponentType1,
                };
                var IssueToUseInTest3 = new IssueTO
                {
                    Description = "proutproutprout",
                    Name = new MultiLanguageString("Issue3EN", "Issue3FR", "Issue3NL"),
                    ComponentType = addedComponentType2,
                };
                var issueRepository = new IssueRepository(memoryCtx);

                issueRepository.Add(IssueToUseInTest);
                issueRepository.Add(IssueToUseInTest2);
                issueRepository.Add(IssueToUseInTest3);
                memoryCtx.SaveChanges();

                Assert.AreEqual(3, issueRepository.GetAll().Count());
            }
        }
    }
}
