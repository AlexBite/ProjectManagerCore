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
		private readonly IEmployeeService _employeeService;
		private readonly ITaskService _taskService;
		public ProjectService()
		{
			//projectService = new ProjectService();
			_employeeService = new EmployeeService();
			_taskService = new TaskService();
		}
		public ProjectModel AddProject(string name, DateTime startDate, DateTime endDate, int typeId)
		{
			var project = new ProjectModel()
			{
				Name = name,
				StartDate = startDate,
				EndDate = endDate,
				ProjectTypeId = typeId
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
				//_taskService.DeleteTask(id);
				var tasksToDelete = dbContext.Tasks.FirstOrDefault(p => p.ProjectId == id);
				dbContext.Tasks.Remove(tasksToDelete);
				dbContext.SaveChanges();
			}
		}
		public void EditProject(string name, int id, int ide, DateTime startDate, DateTime endDate)
		{
			
			using (var dbContext = new CoreDbContext())
			{var leaderEmployee = _employeeService.GetEmployee(ide);
			if (leaderEmployee == null)
				throw new Exception("Пользователь с таким ID не найден");
				var projectToDelete = dbContext.Projects.FirstOrDefault(p => p.Id == id);
				dbContext.Projects.Remove(projectToDelete);
				var project = new ProjectModel()
				{
					Id = id,
					Name = name,
					StartDate = startDate,
					EndDate = endDate
				};
				dbContext.Projects.Add(project);
				dbContext.SaveChanges();
			}
				
			

		}
		public void EditProjectName(string name, int id, int ide, DateTime startDate, DateTime endDate)
		{

			using (var dbContext = new CoreDbContext())
			{
				var leaderEmployee = _employeeService.GetEmployee(ide);
				if (leaderEmployee == null)
					throw new Exception("Пользователь с таким ID не найден");
				var projectToDelete = dbContext.Projects.FirstOrDefault(p => p.Id == id);
				dbContext.Projects.Remove(projectToDelete);
				var project = new ProjectModel()
				{
					Id = id,
					Name = name,
					StartDate = startDate,
					EndDate = endDate 
					
				};
				dbContext.Projects.Add(project);
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
