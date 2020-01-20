using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_AddIssueTests
    {
        [TestMethod]
        public void AddIssue_CorrectIssueGiven_ReturnReturnIssueNotNull()
        {
            //Component
            var componentType1 = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name1En", "Name1Fr", "Name1Nl") };
            var componentType2 = new ComponentTypeTO { Archived = false, Name = new MultiLanguageString("Name2En", "Name2Fr", "Name2Nl") };
            //Issue
            var issue1 = new IssueTO { Description = "Plus de café", Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"), ComponentType = componentType1 };
            var issue2 = new IssueTO { Description = "Fuite d'eau", Name = new MultiLanguageString("Issue2EN", "Issue2FR", "Issue2NL"), ComponentType = componentType2 };
            var issue3 = new IssueTO { Description = "Plus de PQ", Name = new MultiLanguageString("Issue3EN", "Issue3FR", "Issue3NL"), ComponentType = componentType2 };
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            mockUnitOfWork.Setup(u => u.IssueRepository.Add(It.IsAny<IssueTO>()))
                          .Returns(issue1);
            var sut = new AssistantRole(mockUnitOfWork.Object);
            var addedissue = sut.AddIssue(issue1);
            //ASSERT
            mockUnitOfWork.Verify(u => u.IssueRepository.Add(It.IsAny<IssueTO>()), Times.Once);
            Assert.IsNotNull(addedissue);
        }

        [TestMethod]
        public void AddIssue_NullIssueSubmitted_ThrowArgumentNullException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => sut.AddIssue(null));
        }
    }
}