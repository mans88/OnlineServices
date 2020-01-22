using EvaluationServices.DataLayer;
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
	public class GetByIdQuestionPropositionTests
	{
		[TestMethod]
		public void GetQuestionPropositionById_AdddNewQuestionPropositionThenRetrieveIt_IsNotNull()
		{
			var options = new DbContextOptionsBuilder<EvaluationContext>()
				.UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
				.Options;

			using (var memoryContext = new EvaluationContext(options))
			{
				// Arrange
				IQuestionPropositionRepository repository = new QuestionPropositionRepository(memoryContext);

				var questionProposition = new QuestionPropositionTO
				{
					QuestionId = 1,
					Libelle = new MultiLanguageString("Good", "Bonne", "Goed"),
					Position = 1
				};

				var added = repository.Add(questionProposition);
				memoryContext.SaveChanges();

				// Act
				var result = repository.GetById(added.Id);

				// Assert
				Assert.AreEqual("Good", result.Libelle.English);
				Assert.IsNotNull(result);
			};
		}
	}
}

