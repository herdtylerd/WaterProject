using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;

namespace WaterProject.Controllers
{
    public class HomeController : Controller
    {
        // Set up the next few lines to connect function
        private WaterProjectContext context { get; set; }

        public HomeController(WaterProjectContext temp) => context = temp;

        public IActionResult Index()
        {
            var blah = context.Projects.ToList();

            return View(blah);
        }
    }
}
