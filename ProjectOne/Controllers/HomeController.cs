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
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quadrants()
        {
            return View();
        }

        public IActionResult addTask()
        {
            return View();
        }

        public IActionResult viewTask()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
