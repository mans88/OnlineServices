using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace OnlineServices.WebUx.Mvc5.Controllers.EvaluationServices
{
	public class FormController : Controller
	{
		
		// GET: Form
		public ActionResult Index()
		{
			return View();
		}

		// Afficher le formulaire
		[HttpGet]
		public ActionResult Edit()
		{
			return View();
		}

		// Return form valid form

	}
}