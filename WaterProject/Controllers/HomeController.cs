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
        // The controller no longer accesses the context file directly
        private IWaterProjectRepository repo;

        public HomeController (IWaterProjectRepository temp)
        {
            repo = temp;
        }


        public IActionResult Index()
        {
            var blah = repo.Projects.ToList();

            return View(blah);
        }
    }
}
