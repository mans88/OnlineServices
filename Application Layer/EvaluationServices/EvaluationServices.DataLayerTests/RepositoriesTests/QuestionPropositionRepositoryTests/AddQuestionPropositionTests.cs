using EvaluationServices.DataLayer;
using EvaluationServices.DataLayer.Extensions;
using EvaluationServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.EvaluationServices.Interfaces.Repositories;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EvaluationServices.DataLayerTests.RepositoriesTests.QuestionPropositionRepositoryTests
{
	[TestClass]
	public class AddQuestionPropositionTests
	{
		[TestMethod]
		public void AddQuestionProposition_ThrowsException_WhenANonExistingIdIsProvided()
		{
			var options = new DbContextOptionsBuilder<EvaluationContext>()
				.UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
				.Options;


			using (var memoryContext = new EvaluationContext(options))
			{
                // Arrange
                IQuestionPropositionRepository repository = new QuestionPropositionRepository(memoryContext);
                Assert.ThrowsException<ArgumentNullException>(() => repository.Add(null));
			}
		}

        [TestMethod()]
        public void AddQuestionProposition_ShouldInsertInDb_WhenValidQuestionPropositionIsSupplied()
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
                    Libelle = new MultiLanguageString("Good","Bonne","Goed"),
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

                //ACT
                var added1 = repository.Add(QuestionProposition1);
                var added2 = repository.Add(QuestionProposition2);
                var added3 = repository.Add(QuestionProposition1);

                memoryContext.SaveChanges();

                //ASSERT
                Assert.IsNotNull(added1);
                Assert.IsNotNull(added2);
                Assert.IsNotNull(added3);

                Assert.AreEqual(1, added1.Id);
                Assert.AreEqual("Medium", added2.Libelle.English);
            }
        }
    }
}

