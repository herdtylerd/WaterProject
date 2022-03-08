using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public interface IWaterProjectRepository // Change class to interface
    {
        IQueryable<Project> Projects { get; }

        public void SaveProject(Project p);
        public void CreateProject(Project p);
        public void DeleteProject(Project p);
    }
}
