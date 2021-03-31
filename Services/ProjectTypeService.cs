using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{
	internal class ProjectTypeService : IProjectTypeService
	{
		public ProjectTypeModel AddType(string name)
		{
			var activity = new ProjectTypeModel()
			{
				Name = name
			};

			using (var dbContext = new CoreDbContext())
			{
				dbContext.ProjectTypes.Add(activity);
				dbContext.SaveChanges();
			}

			return activity;
		}        

        public List<ProjectTypeModel> GetAllTypes()
		{
			List<ProjectTypeModel> departments;
			using (var dbContext = new CoreDbContext())
			{
				departments = dbContext.ProjectTypes.ToList();
			}
			return departments;
		}
        
    }
}
