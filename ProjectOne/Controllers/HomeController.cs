﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            var delete_app = taskContext.Tasks.Single(i => i.TaskId == id);

            return View();
        }

        [HttpPost]
        public IActionResult Delete(TaskForm tf)
        {
            taskContext.Tasks.Remove(tf);
            taskContext.SaveChanges();

            return RedirectToAction("ViewQuad");
        }
    }
}
}
