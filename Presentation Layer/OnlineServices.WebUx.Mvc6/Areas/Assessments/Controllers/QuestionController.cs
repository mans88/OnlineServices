using Microsoft.AspNetCore.Mvc;
using OnlineServices.Common.EvaluationServices.Enumerations;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System.Collections.Generic;
using System.Linq;

namespace OnlineServices.WebUx.Mvc6.Areas.Assessments.Controllers
{
	[Area("Assessments")]
	public class QuestionController : Controller
	{

		#region Arrange

		public static MultiLanguageString libelleQuestion1 = new MultiLanguageString
		(
			"What is your general impression after this first day of training ?",
			"Quelle est votre impression générale après cette première journée de formation ?",
			"Wat is je algemene indruk na deze eerste dag van training ?"
		);

		public static QuestionTO question1 = new QuestionTO
		{
			Id = 1,
			Form = FormController.form1,
			Position = 1,
			Type = QuestionType.SingleChoice,
			Libelle = libelleQuestion1
		};

		public static MultiLanguageString libelleQuestion2 = new MultiLanguageString
		(
			"Is the pace right for you ?",
			"Est-ce que le rythme vous convient ?",
			"Is het tempo geschikt voor u ?"
		);

		public static QuestionTO question2 = new QuestionTO
		{
			Id = 2,
			Form = FormController.form1,
			Position = 2,
			Type = QuestionType.SingleChoice,
			Libelle = libelleQuestion2
		};

		public static MultiLanguageString libelleQuestion3 = new MultiLanguageString
		(
			"Do you have questions related to the subject studied today ?",
			"Avez-vous des questions relatives à la matière étudiée aujourd’hui ?",
			"Heb je vragen over het onderwerp dat vandaag is bestudeerd ?"
		);

		public static QuestionTO question3 = new QuestionTO
		{
			Id = 3,
			Form = FormController.form1,
			Position = 3,
			Type = QuestionType.Open,
			Libelle = libelleQuestion3,
		};

		public static MultiLanguageString libelleQuestion4 = new MultiLanguageString
		(
				"Do you have specific questions / particular topics that you would like deepen during this training ?",
				"Avez-vous des questions spécifiques/sujets particuliers que vous aimeriez approfondir durant cette formation ?",
				"Heeft u specifieke vragen / specifieke onderwerpen die u graag zou willen verdiepen tijdens deze training ?"
		);

		public static QuestionTO question4 = new QuestionTO
		{
			Id = 4,
			Form = FormController.form1,
			Position = 4,
			Type = QuestionType.Open,
			Libelle = libelleQuestion4,
		};

		public static MultiLanguageString libelleQuestion5 = new MultiLanguageString
		(
			"What objectives do you pursue by following this training ?",
			"Quels objectifs poursuivez-vous en suivant cette formation ?",
			"Welke doelstellingen streeft u na door deze training te volgen?"
		);
		

		public static QuestionTO question5 = new QuestionTO
		{
			Id = 5,
			Form = FormController.form1,
			Position = 5,
			Type = QuestionType.Open,
			Libelle = libelleQuestion5
		};
				
		public static MultiLanguageString libelleQuestion6 = new MultiLanguageString
		(
				"2 - What objectives do you pursue by following this training ?",
				"2 - Quels objectifs poursuivez-vous en suivant cette formation ?",
				"2 -Welke doelstellingen streeft u na door deze training te volgen?"
		);

		public static QuestionTO question6 = new QuestionTO
		{
			Id = 6,
			Form = FormController.form2,
			Position = 2,
			Type = QuestionType.Open,
			Libelle = libelleQuestion6
		};

		public static MultiLanguageString libelleQuestion7 = new MultiLanguageString
		(
			"2 - Do you have specific questions / particular topics that you would like deepen during this training ?",
			"2 - Avez-vous des questions spécifiques/sujets particuliers que vous aimeriez approfondir durant cette formation ?",
			"2 - Heeft u specifieke vragen / specifieke onderwerpen die u graag zou willen verdiepen tijdens deze training ?"
		);

		public static QuestionTO question7 = new QuestionTO
		{
			Id = 7,
			Form = FormController.form2,
			Position = 1,
			Type = QuestionType.Open,
			Libelle = libelleQuestion7,
		};

		#endregion

		// Context
		public static List<QuestionTO> questions = new List<QuestionTO> { question1, question2, question3, question4, question5, question6, question7 };

		[HttpGet]
		public IActionResult GetByFormId(int id)
		{
			var result = questions
				.Where(q => q.Form.Id == id)
				.OrderBy(q => q.Position)
				.ToList();
			
			return View(result);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var result = questions.FirstOrDefault(f => f.Id == id);
			return View(result);
		}
	}
}