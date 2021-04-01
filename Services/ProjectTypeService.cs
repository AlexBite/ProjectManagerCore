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
			var projectType = new ProjectTypeModel()
			{
				Name = name
			};

			using (var dbContext = new CoreDbContext())
			{
				dbContext.ProjectTypes.Add(projectType);
				dbContext.SaveChanges();
			}

			return projectType;
		}        

        public List<ProjectTypeModel> GetAllTypes()
		{
			List<ProjectTypeModel> projectTypes;
			using (var dbContext = new CoreDbContext())
			{
				projectTypes = dbContext.ProjectTypes.ToList();
			}
			return projectTypes;
		}
        
    }
}
