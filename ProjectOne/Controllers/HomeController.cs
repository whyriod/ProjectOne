using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Controllers
{
    public class HomeController : Controller
    {
        private TaskFormContext taskContext { get; set; }

        public HomeController(TaskFormContext something)
        {
            taskContext = something;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewQuad()
        {
            return View();
        }

        public IActionResult DeleteTask()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditTask()
        {
            ViewBag.Categories = taskContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult EditTask(TaskForm tf)
        {
            if (ModelState.IsValid)
            {
                taskContext.Add(tf);
                taskContext.SaveChanges();

                return View("Conformation", tf);
            }
            else
            {
                ViewBag.Categories = taskContext.Categories.ToList();
                return View();
            }
        }
    }
}
