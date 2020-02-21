using EvaluationServices.DataLayer;
using EvaluationServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.EvaluationServices.Enumerations;
using OnlineServices.Common.EvaluationServices.Interfaces.Repositories;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Reflection;

namespace EvaluationServices.DataLayerTests.RepositoriesTests.QuestionRepositoryTest
{
	[TestClass]
	public class GetByIdQuestionRepositoryTest
	{
		[TestMethod]
		public void AdddNewQuestionThenRetrieveItIsNotNull()
		{
			var options = new DbContextOptionsBuilder<EvaluationContext>()
			.UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
			.Options;

			using (var memoryContext = new EvaluationContext(options))
			{
				// Arrange
				IFormRepository formRepository = new FormRepository(memoryContext);
				IQuestionRepository questionRepository = new QuestionRepository(memoryContext);
				IQuestionPropositionRepository questionPropositionRepository = new QuestionPropositionRepository(memoryContext);

				#region Form

				var Form1 = new FormTO
				{
					Name = new MultiLanguageString
					(
						"Daily evaluation form",
						"Formulaire d'évaluation journalier",
						"Dagelijks evaluatieformulier"
					),
				};
				var formAdded1 = formRepository.Add(Form1);
				memoryContext.SaveChanges();

				#endregion

				#region Questions

				var Question1 = new QuestionTO
				{
					FormId = formAdded1.Id,
					Position = 1,
					Libelle = new MultiLanguageString
					(
						"What is your general impression after this first day of training ?",
						"Quelle est votre impression générale après cette première journée de formation ?",
						"Wat is je algemene indruk na deze eerste dag van training ?"
					),
					Type = QuestionType.SingleChoice,
				};

				var Question2 = new QuestionTO
				{
					FormId = formAdded1.Id,
					Position = 2,
					Libelle = new MultiLanguageString
					(
						"Is the pace right for you ?",
						"Est-ce que le rythme vous convient ?",
						"Is het tempo geschikt voor u ?"
					),
					Type = QuestionType.SingleChoice,
				};

				var Question3 = new QuestionTO
				{
					FormId = formAdded1.Id,
					Position = 3,
					Libelle = new MultiLanguageString
					(
						"Do you have questions related to the subject studied today ?",
						"Avez-vous des questions relatives à la matière étudiée aujourd’hui ?",
						"Heb je vragen over het onderwerp dat vandaag is bestudeerd ?"
					),
					Type = QuestionType.Open
				};

				var Question4 = new QuestionTO
				{
					FormId = formAdded1.Id,
					Position = 4,
					Libelle = new MultiLanguageString
					(
						"Do you have specific questions / particular topics that you would like deepen during this training ?",
						"Avez-vous des questions spécifiques/sujets particuliers que vous aimeriez approfondir durant cette formation ?",
						"Heeft u specifieke vragen / specifieke onderwerpen die u graag zou willen verdiepen tijdens deze training ?"
					),
					Type = QuestionType.Open
				};

				var Question5 = new QuestionTO
				{
					FormId = formAdded1.Id,
					Position = 5,
					Libelle = new MultiLanguageString
					(
						"What objectives do you pursue by following this training ?",
						"Quels objectifs poursuivez-vous en suivant cette formation ?",
						"Welke doelstellingen streeft u na door deze training te volgen?"
					),
					Type = QuestionType.Open
				};

				var questionAdded1 = questionRepository.Add(Question1);
				var questionAdded2 = questionRepository.Add(Question2);
				var questionAdded3 = questionRepository.Add(Question3);
				var questionAdded4 = questionRepository.Add(Question4);
				var questionAdded5 = questionRepository.Add(Question5);
				memoryContext.SaveChanges();

				#endregion

				#region QuestionProposition
				var QuestionProposition1 = new QuestionPropositionTO
				{
					                    QuestionId = questionAdded1.Id,
					Libelle = new MultiLanguageString("good", "bonne", "goed"),
					Position = 1
				};

				var QuestionProposition2 = new QuestionPropositionTO
				{
					                    QuestionId = questionAdded1.Id,
					Libelle = new MultiLanguageString("medium", "moyenne", "gemiddelde"),
					Position = 2
				};

				var QuestionProposition3 = new QuestionPropositionTO
				{
					                    QuestionId = questionAdded1.Id,
					Libelle = new MultiLanguageString("bad", "mauvaise", "slecht"),
					Position = 3
				};

				var QuestionProposition4 = new QuestionPropositionTO
				{
					                    QuestionId = questionAdded2.Id,
					Libelle = new MultiLanguageString("yes", "oui", "ja"),
					Position = 1
				};

				var QuestionProposition5 = new QuestionPropositionTO
				{
					                    QuestionId = questionAdded2.Id,
					Libelle = new MultiLanguageString("too fast", "trop rapide", "te snel"),
					Position = 2
				};

				var QuestionProposition6 = new QuestionPropositionTO
				{
					                    QuestionId = questionAdded2.Id,
					Libelle = new MultiLanguageString("too slow", "trop lent", "te langzaam"),
					Position = 3
				};

				var questionPropositionAdded1 = questionPropositionRepository.Add(QuestionProposition1);
				var questionPropositionAdded2 = questionPropositionRepository.Add(QuestionProposition2);
				var questionPropositionAdded3 = questionPropositionRepository.Add(QuestionProposition3);
				var questionPropositionAdded4 = questionPropositionRepository.Add(QuestionProposition4);
				var questionPropositionAdded5 = questionPropositionRepository.Add(QuestionProposition5);
				var questionPropositionAdded6 = questionPropositionRepository.Add(QuestionProposition6);
				memoryContext.SaveChanges();
				#endregion

				// Act
				var result1 = questionRepository.GetById(questionAdded1.Id);
				var result2 = questionRepository.GetById(questionAdded2.Id);
				var result3 = questionRepository.GetById(questionAdded3.Id);
				
				// Assert
				Assert.IsNotNull(result1);
				Assert.IsNotNull(result2);
				Assert.IsNotNull(result3);

				Assert.AreEqual("Quelle est votre impression générale après cette première journée de formation ?", result1.Libelle.French);
				Assert.AreEqual(2, result2.Position);
				Assert.AreEqual(QuestionType.Open, result3.Type);
			}
		}
	}
}
