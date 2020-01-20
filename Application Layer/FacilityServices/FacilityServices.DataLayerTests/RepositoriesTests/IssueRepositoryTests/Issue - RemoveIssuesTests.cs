using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FacilityServices.DataLayerTests.RepositoriesTests.IssueRepositoryTests
{
    [TestClass]
    public class RemoveIssuesTests
    {
        [TestMethod()]
        public void RemoveIssueByTransfertObject_ThrowException_WhenDeletingANonExistantIssue()
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
                memoryCtx.SaveChanges();

                Assert.ThrowsException<Exception>(() => issueRepository.Remove(IssueToUseInTest3));
            }
        }
        [TestMethod()]
        public void RemoveIssueByTransfertObject_Successfull()
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

                var f1 = issueRepository.Add(IssueToUseInTest);
                var f2 = issueRepository.Add(IssueToUseInTest2);
                memoryCtx.SaveChanges();
                issueRepository.Remove(f2);
                memoryCtx.SaveChanges();

                var retrievedIssues = issueRepository.GetAll();

                Assert.AreEqual(1, retrievedIssues.Count());
                Assert.IsFalse(retrievedIssues.Any(x => x.Id == 2));
            }

        }
        [TestMethod()]
        public void RemoveIssueById_ThrowException_WhenDeletingANonExistantIssue()
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
                memoryCtx.SaveChanges();

                Assert.ThrowsException<Exception>(() => issueRepository.Remove(3));
            }
        }
        [TestMethod()]
        public void RemoveIssueById_Successfull()
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
                memoryCtx.SaveChanges();
                issueRepository.Remove(1);
                memoryCtx.SaveChanges();

                var retrievedIssues = issueRepository.GetAll();

                Assert.AreEqual(1, retrievedIssues.Count());
                Assert.IsFalse(retrievedIssues.Any(x => x.Id == 1));
            }
        }
    }
}
