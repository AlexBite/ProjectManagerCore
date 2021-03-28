using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{
	internal class ProjectService : IProjectService
	{
		public ProjectModel AddProject(string name, string leadEmployeeId, DateTime startDate, DateTime endDate)
		{
			var project = new ProjectModel()
			{
				Name = name,
				StartDate = startDate,
				EndDate = endDate
			};

			using (var dbContext = new CoreDbContext())
			{
				dbContext.Projects.Add(project);
				dbContext.SaveChanges();
			}

			return project;
		}

		public List<ProjectModel> GetAllProjects()
		{
			List<ProjectModel> projects;
			using (var dbContext = new CoreDbContext())
			{
				projects = dbContext.Projects.ToList();
			}
			return projects;
		}
	}
}
