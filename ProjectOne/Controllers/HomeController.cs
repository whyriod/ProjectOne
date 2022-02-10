using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private TaskFormContext _taskContext { get; set; }

        public HomeController(TaskFormContext something)
        {
            _taskContext = something;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ViewQuad()
        {
            var tasks = _taskContext.Tasks
                .Include(x => x.Category)
                .Where(x => x.Completed == false)
                .OrderBy(x => x.TaskName)
                .ToList();
            return View(tasks);
        }

        public IActionResult DeleteTask()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditTask()
        {
            ViewBag.Categories = _taskContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult EditTask(TaskForm tf)
        {
            if (ModelState.IsValid)
            {
                _taskContext.Add(tf);
                _taskContext.SaveChanges();

                return View("Conformation", tf);
            }
            else
            {
                ViewBag.Categories = _taskContext.Categories.ToList();
                return View();
            }
        }
    }
}
