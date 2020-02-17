using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bonjour.Models;

namespace Bonjour.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NewOne()
        {
            string content = "<form method='post' id='greetForm' action='/Home/Display'>" +
            "<input type='text' name='name' />" +
            "<input type = 'submit' value='Greet me!' />" +
                "<select id='lang' name='lang' form='greetForm'>" +
                    "<option value='english'>English</option>" +
                    "<option value='french'>French</option>" +
                    "<option value='japanese'>Japanese</option>" +
                    "<option value='german'>German</option>" +
                    "<option value='spanish'>Spanish</option>" +    
                "</select>" +
            "</form>";

            return Content(content, "text/html");
        }
        public IActionResult Display(string name = "World", string lang = "english")
        {
            string greeting = "english";
            switch (lang) { 
                case "english": 
                    greeting = "Hello,"; 
                    break; 
  
                case "french": 
                    greeting = "Bonjour,";
                    break;  
                case "japanese": 
                    greeting = "Konichiwa,";
                    break;
                case "german": 
                    greeting = "Hallo,";
                    break; 
                case "spanish": 
                    greeting = "Hola,";
                    break;
            } 
            return Content(string.Format("<h1>" + greeting + " {0}!</h1>", name), "text/html");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
