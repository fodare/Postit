using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Postit.Models;

namespace Postit.Controllers
{
    public class ViewController : Controller
    {
        private readonly ILogger<ViewController> _logger;

        public ViewController(ILogger<ViewController> logger)
        {
            _logger = logger;
        }

        // Get home view
        public IActionResult Index()
        {
            int randomnumber = 12;
            return View();
        }

        // Get the privacy view
        public IActionResult Privacy()
        {
            return View();
        }
        // Get the about page
        public IActionResult Welcome(string name = "user", int Id = 1)
        {
            ViewData["message"] = $"Hello {name}. You've searched content  with id: {Id}!";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}