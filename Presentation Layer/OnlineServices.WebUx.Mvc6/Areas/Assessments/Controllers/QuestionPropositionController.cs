using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;

namespace OnlineServices.WebUx.Mvc6.Areas.Assessments.Controllers
{
    [Area("Assessments")]
    public class QuestionPropositionController : Controller
    {
		#region Arrange
		public static MultiLanguageString questionLibelle1 = new MultiLanguageString("good", "bonne", "goed");

		public static QuestionPropositionTO questionProposition1 = new QuestionPropositionTO
		{
			Id = 1,
			Question = QuestionController.question1,
			Libelle = questionLibelle1,
			Position = 1
		};

		public static MultiLanguageString questionLibelle2 = new MultiLanguageString("medium", "moyenne", "gemiddelde");

		public static QuestionPropositionTO questionProposition2 = new QuestionPropositionTO
		{
			Id = 2,
			Question = QuestionController.question1,
			Libelle = questionLibelle2,
			Position = 2
		};

		public static MultiLanguageString questionLibelle3 = new MultiLanguageString("bad", "mauvaise", "slecht");

		public static QuestionPropositionTO questionProposition3 = new QuestionPropositionTO
		{
			Id = 3,
			Question = QuestionController.question1,
			Libelle = questionLibelle3,
			Position = 3
		};

		public static MultiLanguageString questionLibelle4 = new MultiLanguageString("yes", "oui", "ja");

		public static QuestionPropositionTO questionProposition4 = new QuestionPropositionTO
		{
			Id = 4,
			Question = QuestionController.question2,
			Libelle = questionLibelle4,
			Position = 1
		};

		public static MultiLanguageString questionLibelle5 = new MultiLanguageString("too fast", "trop rapide", "te snel");


		public static QuestionPropositionTO questionProposition5 = new QuestionPropositionTO
		{
			Id = 5,
			Question = QuestionController.question2,
			Libelle = questionLibelle5,
			Position = 2
		};

		public static MultiLanguageString questionLibelle6 = new MultiLanguageString("too slow", "trop lent", "te langzaam");


		public static QuestionPropositionTO questionProposition6 = new QuestionPropositionTO
		{
			Id = 6,
			Question = QuestionController.question2,
			Libelle = questionLibelle6,
			Position = 3
		};

		#endregion

		// Context
		public static List<QuestionPropositionTO> questionPropositions = new List<QuestionPropositionTO>
		{
			questionProposition1,
			questionProposition2,
			questionProposition3,
			questionProposition4,
			questionProposition5,
			questionProposition6
		};
		public IActionResult GetByQuestionId(int id)
        {
			var result = questionPropositions
				.Where(qp => qp.Question.Id == id)
				.OrderBy(qp => qp.Position)
				.ToList();

            return View(result);
        }

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var result = questionPropositions
				.FirstOrDefault(qp => qp.Id == id);

			return View(result);
		}
    }
}