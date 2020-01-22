using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineServices.WebUx.Mvc6.Areas.Registration.Controllers
{
    [Area("Registration")]
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Validate(string username, string password)
        {
            //url to text: MVC6 https://localhost:44332/Account/Validate?username=User01&password=12345678

            string user = "User01";
            string pass = "12345678";

            //Hack: Model - 
            try
            {
                if (user == username && pass == password)
                {
                    string messageJSON = $"Login Successfull! user: {username}  - pass: {password} ";
                    ViewData["User"] = username;
                    return View();
                }
                else
                {
                    ViewBag.Message = "Invalid User and/or Password! ";
                    return View("Login");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}