using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineServices.Common.EvaluationServices;
using OnlineServices.Common.EvaluationServices.TransfertObjects;

namespace OnlineServices.WebUx.Mvc6.Areas.Assessments.Controllers
{
    [Area("Assessments")]
    public class AssistantController : Controller
    {
        private readonly IESAssistantRole assistantRole;

        public AssistantController(IESAssistantRole assistantRole)
        {
            this.assistantRole = assistantRole;
        }

        [HttpGet]
        public IActionResult GetAllForms()
        {
            return View(assistantRole.GetAllForms());
        }

        public IActionResult GetFormById(int id)
        {
            return View(assistantRole.GetFormById(id));
        }

        public IActionResult DeleteFormById(int id)
        {
            var result = assistantRole.RemoveFormById(id);
            return RedirectToAction("GetAllForms");
        }
        [HttpGet]
        public IActionResult AddForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddForm(FormTO form)
        {
            assistantRole.AddForm(form);
            return RedirectToAction("GetAllForms");
        }
        [HttpGet]
        public IActionResult AddQuestion(int id)
        {
            int position=1;
            if(assistantRole.GetFormById(id).Questions.Count>0)
            {
                position += assistantRole.GetFormById(id).Questions.Max(q => q.Position);

            }
            var question = new QuestionTO { FormId = id, Position = position };

            return View(question);
        }
        [HttpPost]
        public IActionResult AddQuestion(QuestionTO question)
        {
            assistantRole.AddQuestionByForm(question);
            return RedirectToAction("GetFormById",new { id = question.FormId });
        }
    }
}