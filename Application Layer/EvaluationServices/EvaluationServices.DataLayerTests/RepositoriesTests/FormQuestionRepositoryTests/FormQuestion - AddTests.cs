using EvaluationServices.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.EvaluationServices.Enumerations;
using OnlineServices.Common.EvaluationServices.Interfaces;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EvaluationServices.DataLayerTests.RepositoriesTests.FormQuestionRepositoryTests
{
	[TestClass]
	public class AddFormQuestionTests
	{
		[TestMethod]
		public void AddFormQuestion_ThrowsException_WhenANonExistingFormQuestionIsProvided()
		{
			var options = new DbContextOptionsBuilder<EvaluationContext>()
				.UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
				.Options;

			using (var memoryContext = new EvaluationContext(options))
			{
				// Arrange
				QuestionRepository questionRepository = new QuestionRepository(memoryContext);

				// Assert
				Assert.ThrowsException<ArgumentNullException>(() => questionRepository.Add(null));
			}
		}

		[TestMethod]
		public void AddForm_ShouldInsertInDb_WhenValidFormIsSupplied()
		{
			var options = new DbContextOptionsBuilder<EvaluationContext>()
				.UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
				.Options;

			using (var memoryContext = new EvaluationContext(options))
			{
				// Arrange
				QuestionRepository questionRepository = new QuestionRepository(memoryContext);

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

				QuestionTO question1 = new QuestionTO
				{
					Libelle = new MultiLanguageString("Question1", "Question1", "Question1"),
					Position = 1,
					Type = QuestionType.Open,
					Choices = new List<QuestionPropositionTO>{questionProposition1, questionProposition2, questionProposition3}
				};

				FormQuestionTO form1 = new FormQuestionTO { Name = "Form1", Questions = new List<QuestionTO> {question1} };
				FormQuestionTO form2 = new FormQuestionTO { Name = "Form2", Questions = new List<QuestionTO> { question1 } };
				FormQuestionTO form3 = new FormQuestionTO { Name = "Form3", Questions = new List<QuestionTO> { question1 } };


				// Act
				var Added1 = questionRepository.Add(form1);
				var Added2 = questionRepository.Add(form2);
				var Added3 = questionRepository.Add(form3);

				memoryContext.SaveChanges();

				// Assert
				Assert.AreEqual("Form1", Added1.Name);
				Assert.AreEqual("Form2", Added2.Name);
				Assert.AreEqual("Form3", Added3.Name);
			}
		}
	}
}
