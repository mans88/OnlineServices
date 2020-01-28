using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineServices.Common.RegistrationServices.TransferObject;

using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace OnlineServices.WebUx.Mvc6.Areas.Registration.Controllers
{
    [Area("Registration")]
    public class CourseController : Controller
    {
        List<CourseTO> courseList = new List<CourseTO>() {
            new CourseTO { Id = 1, Name = "Course 01" }, new CourseTO { Id = 2, Name = "Course 02" },
            new CourseTO { Id = 3, Name = "Course 03" }, new CourseTO { Id = 4, Name = "Course 04" }
        };

        public List<CourseTO> ListData()
        {
            var data = (string)TempData["data"];
            if (data != "0")
                courseList.RemoveAt(1);

            return courseList;
        }
        
        public CourseTO GetCourse(int id)
        {
            CourseTO course = ListData().FirstOrDefault(x=>x.Id == id);

            //var std = ListData().Where(s => s.Id == id).FirstOrDefault();
            return course;
        }

        public void UpdateList(CourseTO course)
        {
            ListData().Where(w => w.Id == course.Id).ToList().ForEach(s => s.Name = course.Name);
        }

        // GET: Course
        public IActionResult Index()
        {
            //return Content($"<script language='javascript' type='text/javascript'>alert('Thanks for Feedback {55}!');</script>");
            return View(ListData());

        }

        // GET: Course/Details/5
        public IActionResult Details(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            CourseTO course = GetCourse(id);
            if(course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            //if (ModelState.IsValid)
            //{
            //    //dinnerRepository.Add(course);
            //    //dinnerRepository.Save();
            //    //courseList.Add();

            //    //return RedirectToAction("Details");
            //}
            //else
            
            return View();
        }

        // POST: Course/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(CourseTO course) //SAVE
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //CourseTO course = new CourseTO { Id = 8, Name = "new Course" };
                    ListData().Add(course);
                    return View(course);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            CourseTO course = GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Course/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(CourseTO course)  //UPDATE
        {
            //return RedirectToAction("Index");
            /*
            if (course.Id == 0) 
                return NotFound();

            var id = course.Id;
            var name = course.Name;
            */



            //if (id != course.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    
                    UpdateList(course);
                    if (TempData.ContainsKey("data"))
                    {
                        ViewBag.Name = TempData["data"] as string;
                    }
                    
                    //foreach (var item in courseList)
                    //{
                    //    names += item.Name;
                    //}
                    //return Content($"<script language='javascript' type='text/javascript'>alert('Thanks for Feedback {names}!');</script>");
                }
                catch (Exception) //DbUpdateConcurrencyException
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Course/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Course/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}