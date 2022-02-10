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
        private TaskFormContext taskContext { get; set; }

        public HomeController(TaskFormContext something)
        {
            taskContext = something;
        }
        

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult ViewQuad()
        {
            var tasks = taskContext.Tasks
                .Include(x => x.Category)
                .Where(x => x.Completed == false)
                .OrderBy(x => x.TaskName)
                .ToList();
            return View("ViewQuad",tasks);
        }

        public IActionResult DeleteTask()
        {
            return View("DeleteTask");
        }


        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = taskContext.Categories.ToList();
            return View("EditTask");
        }

        [HttpPost]
        public IActionResult AddTask(TaskForm tf)
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
                return View("EditTask");
            }
        }

        [HttpGet]
        public IActionResult EditTask(int id)
        {
            taskContext.Tasks.Single(x => x.TaskId == id);
            return View("EditTask");
        }

        [HttpPost]
        public IActionResult EditTask(TaskForm tf)
        {
            if (ModelState.IsValid)
            {
                taskContext.Update(tf);
                taskContext.SaveChanges();

                return View("Conformation", tf);
            }
            else
            {
                return RedirectToAction("EditTask", new {id = tf.TaskId});
            }

        }
    }
}
