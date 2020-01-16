using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.BusinessLayerTests.UseCases.AttendeeTests
{
    [TestClass]
    public class Attendee_GetIssuesTests
    {
        [TestMethod]
        public void GetIssues_AddThreeIssues_ThenRetrieveThem_ReturnCorrectNumberOfIssues()
        {
            var componentType1 = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name1En", "Name1Fr", "Name1Nl") };
            var componentType2 = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name2En", "Name2Fr", "Name2Nl") };
            //Issue
            var issues = new List<IssueTO>
            {
             new IssueTO {Id = 1, Archived = false, Description = "Plus de café", Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"), ComponentType = componentType1 },
             new IssueTO {Id = 2, Archived = false, Description = "Fuite d'eau", Name = new MultiLanguageString("Issue2EN", "Issue2FR", "Issue2NL"), ComponentType = componentType2 },
             new IssueTO {Id = 3, Archived = false, Description = "Plus de PQ", Name = new MultiLanguageString("Issue3EN", "Issue3FR", "Issue3NL"), ComponentType = componentType2 },
            };
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();

            mockUnitOfWork.Setup(u => u.IssueRepository.GetAll()).Returns(issues);
            var sut = new AttendeeRole(mockUnitOfWork.Object);
            //ACT
            var listOfIssues = sut.GetIssues();
            //ASSERT
            mockUnitOfWork.Verify(u => u.IssueRepository.GetAll(), Times.Once);
            Assert.AreEqual(3, listOfIssues.Count());
        }
    }
}