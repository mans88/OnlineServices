using FacilityServices.DataLayer;
using FacilityServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Linq;
using System.Reflection;

namespace FacilityServices.DataLayerTests.RepositoriesTests.IssueRepositoryTests
{
    [TestClass]
    public class GetIssuesByComponentTypesTests
    {
        [TestMethod]
        //[Ignore]
        public void GetIssuesByComponentTypes_ReturnCoorectNumberOfCorrespondingIssues()
        {
            //ARRANGE
            var options = new DbContextOptionsBuilder<FacilityContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using var context = new FacilityContext(options);
            
            var issueRepository = new IssueRepository(context);
            var componentTypeRepository = new ComponentTypeRepository(context);

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
            context.SaveChanges();

            IssueTO issue1 = new IssueTO 
            { 
                Name = new MultiLanguageString("Issue1", "Issue1", "Issue1"), 
                ComponentType = addedComponentType1, 
                Description = "prout", 
            };
            IssueTO issue2 = new IssueTO 
            { 
                Name = new MultiLanguageString("Issue2", "Issue2", "Issue2"), 
                ComponentType = addedComponentType1,
                Description = "proutprout",
            };
            IssueTO issue3 = new IssueTO 
            { 
                Name = new MultiLanguageString("Issue3", "Issue3", "Issue3"), 
                ComponentType = addedComponentType2,
                Description = "proutproutprout",
            };

            var firstIssueAdded = issueRepository.Add(issue1);
            var secondIssueAdded = issueRepository.Add(issue2);
            var thirdIssueAdded = issueRepository.Add(issue3);
            context.SaveChanges();

            var retrievedIssues = issueRepository.GetIssuesByComponentType(addedComponentType1);

            Assert.IsNotNull(retrievedIssues);
            Assert.AreEqual(2, retrievedIssues.Count());
        }
    }
}