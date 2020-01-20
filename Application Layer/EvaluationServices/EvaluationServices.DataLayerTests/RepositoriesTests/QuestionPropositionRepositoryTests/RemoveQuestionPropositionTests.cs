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
	public class RemoveQuestionPropositionTests
	{
		[TestMethod]
		public void RemoveQuestionProposition_AddNewQuestionPropostionThenRemoveIt_ReturnsTrue()
		{
			var options = new DbContextOptionsBuilder<EvaluationContext>()
			.UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
			.Options;

			using (var memoryContext = new EvaluationContext(options))
			{
				// Arrange
				IQuestionPropositionRepository repository = new QuestionPropositionRepository(memoryContext);

                var questionProposition1 = new QuestionPropositionTO
                {
                    QuestionId = 1,
                    Libelle = new MultiLanguageString("Good", "Bonne", "Goed"),
                    Position = 1
                };

                var questionProposition2 = new QuestionPropositionTO
                {
                    QuestionId = 1,
                    Libelle = new MultiLanguageString("Medium", "Moyenne", "Gemiddelde"),
                    Position = 2
                };

                var questionProposition3 = new QuestionPropositionTO
                {
                    QuestionId = 1,
                    Libelle = new MultiLanguageString("Bad", "Mauvaise", "Slecht"),
                    Position = 3
                };

                var added1 = repository.Add(questionProposition1);
                var added2 = repository.Add(questionProposition2);
                var added3 = repository.Add(questionProposition3);
                memoryContext.SaveChanges();


                // ACT
                // Remove by entity
                var result1 = repository.Remove(added1);
                // Remove by id
                var result2 = repository.Remove(added2.Id);
                memoryContext.SaveChanges();

                // Assert
                Assert.IsTrue(result1);
                Assert.IsTrue(result2);
                Assert.AreEqual(1, repository.GetAll().Count());
            }
		}
	}
}
