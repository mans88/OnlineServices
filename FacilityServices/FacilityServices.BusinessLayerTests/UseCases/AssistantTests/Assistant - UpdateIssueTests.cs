using FacilityServices.BusinessLayer.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineServices.Common.Exceptions;
using OnlineServices.Common.FacilityServices.Interfaces;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayerTests.UseCases.AssistantTests
{
    [TestClass]
    public class Assistant_UpdateIssueTests
    {
        [TestMethod]
        public void UpdateIssue_ReturnUpdatedIssue()
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
            mockUnitOfWork.Setup(u => u.IssueRepository.Update(It.IsAny<IssueTO>()))
                          .Returns(new IssueTO { Id = 1, Archived = false, Description = "Plus de café", Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"), ComponentType = componentType1 });
            var sut = new AssistantRole(mockUnitOfWork.Object);
            var issue = new IssueTO { Id = 1, Archived = false, Description = "Plus de café", Name = new MultiLanguageString("Issue1EN", "Issue1FR", "Issue1NL"), ComponentType = componentType1 };
            //ACT
            var updatedIssue = sut.UpdateIssue(issue);
            //ASSERT
            mockUnitOfWork.Verify(u => u.IssueRepository.Update(It.IsAny<IssueTO>()), Times.Once);
            Assert.IsNotNull(updatedIssue);
        }

        [TestMethod]
        public void UpdateIssue_NullIssueSubmitted_ThrowArgumentNullException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<ArgumentNullException>(() => sut.UpdateIssue(null));
        }

        [TestMethod]
        public void UpdateIssue_IncorrectIssueID_ThrowLoggedException()
        {
            //ARRANGE
            var mockUnitOfWork = new Mock<IFSUnitOfWork>();
            var sut = new AssistantRole(mockUnitOfWork.Object);
            //ACT

            //ASSERT
            Assert.ThrowsException<LoggedException>(() => sut.UpdateIssue(new IssueTO { Archived = false }));
        }
    }
}