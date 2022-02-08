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
        private TaskFormContext _taskContext { get; set; }

        public HomeController(TaskFormContext something)
        {
            _taskContext = something;
        }
        public HomeController()
        {
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

        public IActionResult EditTask()
        {
            return View();
        }
    }
}
