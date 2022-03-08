using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public class EFWaterProjectRepository : IWaterProjectRepository
    {
        private WaterProjectContext context { get; set; }

        public EFWaterProjectRepository (WaterProjectContext temp)
        {
            context = temp;
        }

        public IQueryable<Project> Projects => context.Projects;

        public void SaveProject(Project p)
        {
            context.SaveChanges();
        }

        public void CreateProject(Project p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public void DeleteProject(Project p)
        {
            context.Remove(p);
            context.SaveChanges();
        }
    }
}
