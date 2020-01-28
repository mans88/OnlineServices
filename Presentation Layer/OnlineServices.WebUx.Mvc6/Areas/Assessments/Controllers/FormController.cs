using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using OnlineServices.WebUx.Mvc6.Areas.Assessments.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineServices.WebUx.Mvc6.Areas.Assessments.Controllers
{
	[Area("Assessments")]
	public class FormController : Controller
	{
		private readonly IESAttendeeRole iESAttendeeRole;
		public FormController(IESAttendeeRole iESAttendeeRole)
		{
			this.iESAttendeeRole = iESAttendeeRole;
		}
		#region Arrange

		public static MultiLanguageString nameForm1 = new MultiLanguageString
		(
			"Daily evaluation form1",
			"Formulaire d'évaluation journalier1",
			"Dagelijks evaluatieformulier1"
		);

		public static FormTO form1 = new FormTO
		{
			Id = 1,
			Name = nameForm1
		};

		public static MultiLanguageString nameForm2 = new MultiLanguageString
		(
			"Daily evaluation form2",
			"Formulaire d'évaluation journalier2",
			"Dagelijks evaluatieformulier2"
		);

		public static FormTO form2 = new FormTO
		{
			Id = 2,
			Name = nameForm2
		};

		#endregion

		// Context
		public static List<FormTO> forms = new List<FormTO> { form1, form2 };

		//public IActionResult GetAll()
		//{
		//	iESAttendeeRole.GetFormById(2,2);
		//	return View(forms);
		//}

		[HttpGet]
		public IActionResult GetById(int id)
		{
			var result = forms.FirstOrDefault(f => f.Id == id);
			return View(result);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var form = forms.FirstOrDefault(f => f.Id == id);
			return View(form);
		}

		[HttpPost]
		public ActionResult Edit(FormTO form)
		{
			if (!ModelState.IsValid)
				return View(form);

			var index = forms.IndexOf(form);
			forms.RemoveAt(index);
			forms.Insert(index, form);

			return RedirectToAction("GetAll");
		}
	}
}