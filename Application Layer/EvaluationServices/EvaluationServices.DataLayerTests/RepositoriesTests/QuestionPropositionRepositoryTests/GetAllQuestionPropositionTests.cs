using EvaluationServices.DataLayer;
using EvaluationServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.EvaluationServices.Interfaces.Repositories;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EvaluationServices.DataLayerTests.RepositoriesTests.QuestionPropositionRepositoryTests
{
    [TestClass]
    public class GetAllQuestionPropositionTests
    {
        [TestMethod]
        public void GetAll_AddThreeQuestionProposition_ReturnsCorrectNumberOfQuestionProposition()
        {
            var options = new DbContextOptionsBuilder<EvaluationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryContext = new EvaluationContext(options))
            {
                // Arrange
                IQuestionPropositionRepository repository = new QuestionPropositionRepository(memoryContext);

                var QuestionProposition1 = new QuestionPropositionTO
                {
                    QuestionId = 1,
                    Libelle = new MultiLanguageString("Good", "Bonne", "Goed"),
                    Position = 1
                };

                var QuestionProposition2 = new QuestionPropositionTO
                {
                    QuestionId = 1,
                    Libelle = new MultiLanguageString("Medium", "Moyenne", "Gemiddelde"),
                    Position = 2
                };

                var QuestionProposition3 = new QuestionPropositionTO
                {
                    QuestionId = 1,
                    Libelle = new MultiLanguageString("Bad", "Mauvaise", "Slecht"),
                    Position = 3
                };

                var added1 = repository.Add(QuestionProposition1);
                var added2 = repository.Add(QuestionProposition2);
                var added3 = repository.Add(QuestionProposition1);

                memoryContext.SaveChanges();

                // ACT
                var result = repository.GetAll();

                // Assert
                Assert.AreEqual(3, result.Count());
            }
        }
    }
}
