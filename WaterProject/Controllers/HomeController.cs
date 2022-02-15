using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models;
using WaterProject.Models.ViewModels;

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

        // Pagination
        public IActionResult Index(int pageNum = 1) // If nothing comes in, set to 1
        {
            int pageSize = 5;

            var x = new ProjectsViewModel
            {
                Projects = repo.Projects
                .OrderBy(p => p.ProjectName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumProjects = repo.Projects.Count(),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            var blah = repo.Projects
                .OrderBy(p => p.ProjectName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize);

            return View(blah);
        }
    }
}
