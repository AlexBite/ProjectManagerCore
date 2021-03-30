using Microsoft.EntityFrameworkCore;
using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{
	internal class ProjectService : IProjectService
	{
		public ProjectModel AddProject(string name, DateTime startDate, DateTime endDate)
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

		public void DeleteProject(int id)
		{
			using (var dbContext = new CoreDbContext())
			{
				var projectToDelete = dbContext.Projects.FirstOrDefault(p => p.Id == id);
				dbContext.Projects.Remove(projectToDelete);
				dbContext.SaveChanges();
			}
		}

		public List<ProjectModel> GetAllProjects()
		{
			List<ProjectModel> projects;
			using (var dbContext = new CoreDbContext())
			{
				projects = dbContext.Projects.Include(c => c.Employees)
					.ToList();
			}

			return projects;
		}

		public ProjectModel GetProject(int projectId)
		{
			ProjectModel project;
			using (var dbContext = new CoreDbContext())
			{
				project = dbContext.Projects.FirstOrDefault(p => p.Id == projectId);
			}

			return project;
		}
	}
}
