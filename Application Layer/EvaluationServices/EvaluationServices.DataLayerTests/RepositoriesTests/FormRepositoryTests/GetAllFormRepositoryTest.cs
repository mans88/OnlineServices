using EvaluationServices.DataLayer;
using EvaluationServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.EvaluationServices.Enumerations;
using OnlineServices.Common.EvaluationServices.Interfaces.Repositories;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Linq;
using System.Reflection;


namespace EvaluationServices.DataLayerTests.RepositoriesTests.FormRepositoryTests
{
	[TestClass]
	public class GetAllFormRepositoryTest
	{
		[TestMethod]
		public void AddFormReturnsCorrectNumberOfForm()
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

				var Form2 = new FormTO
				{
					Name = new MultiLanguageString
					(
						"Daily evaluation form2",
						"Formulaire d'évaluation journalier2",
						"Dagelijks evaluatieformulier2"
					),
				};

				var Form3 = new FormTO
				{
					Name = new MultiLanguageString
					(
						"Daily evaluation form3",
						"Formulaire d'évaluation journalier3",
						"Dagelijks evaluatieformulier3"
					),
				};
				var formAdded1 = formRepository.Add(Form1);
				var formAdded2 = formRepository.Add(Form2);
				var formAdded3 = formRepository.Add(Form3);
				memoryContext.SaveChanges();

				#endregion

				#region Questions

				var Question1 = new QuestionTO
				{
					Form = formAdded1,
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
					Form = formAdded1,
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
					Form = formAdded1,
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
					Form = formAdded1,
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
					Form = formAdded1,
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
					Question = questionAdded1,
					Libelle = new MultiLanguageString("good", "bonne", "goed"),
					Position = 1
				};

				var QuestionProposition2 = new QuestionPropositionTO
				{
					Question = questionAdded1,
					Libelle = new MultiLanguageString("medium", "moyenne", "gemiddelde"),
					Position = 2
				};

				var QuestionProposition3 = new QuestionPropositionTO
				{
					Question = questionAdded1,
					Libelle = new MultiLanguageString("bad", "mauvaise", "slecht"),
					Position = 3
				};

				var QuestionProposition4 = new QuestionPropositionTO
				{
					Question = questionAdded2,
					Libelle = new MultiLanguageString("yes", "oui", "ja"),
					Position = 1
				};

				var QuestionProposition5 = new QuestionPropositionTO
				{
					Question = questionAdded2,
					Libelle = new MultiLanguageString("too fast", "trop rapide", "te snel"),
					Position = 2
				};

				var QuestionProposition6 = new QuestionPropositionTO
				{
					Question = questionAdded2,
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
				var forms = formRepository.GetAll();
				var questions = questionRepository.GetAll();
				var questionPropositions = questionPropositionRepository.GetAll();
				var count = forms.Count();

				// Assert
				Assert.AreEqual(3, count);

				foreach (var form in forms)
				{
					Console.WriteLine(form.Id);
					Console.WriteLine(form.Name.French);
					Console.WriteLine();

					foreach (var question in questions.Where(q => q.Form.Id == form.Id).ToList())
					{
						Console.WriteLine($"\tId : {question.Id} - Position : {question.Position} - Type : {question.Type} - {question.Libelle.French}");
						Console.WriteLine();

						foreach (var questionProposition in questionPropositions.Where(qp => qp.Question.Id == question.Id))
						{
							Console.WriteLine($"\tId : {questionProposition.Id} - Position : {questionProposition.Position} - {questionProposition.Libelle.French}");
							Console.WriteLine();
						}
					}
				}
			}
		}
	}
}

