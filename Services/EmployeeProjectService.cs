using Microsoft.EntityFrameworkCore;
using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{
	internal class EmployeeProjectService : IEmployeeProjectService
	{
		private readonly IProjectService _projectService;
		private readonly IEmployeeService _employeeService;

		public EmployeeProjectService()
		{
			_projectService = new ProjectService();
			_employeeService = new EmployeeService();
		}

		public EmployeeProjectModel AddProjectWithLeader(string name, DateTime startDate, DateTime endDate, int employeeLeaderId, int typeId)
		{
			var leaderEmployee = _employeeService.GetEmployee(employeeLeaderId);
			if (leaderEmployee == null)
				throw new Exception("Пользователь с таким ID не найден");

			using (var dbContext = new CoreDbContext())
			{
				var project = _projectService.AddProject(name, startDate, endDate, typeId);
				var employeeProject = new EmployeeProjectModel()
				{
					EmployeeId = employeeLeaderId,
					RoleId = (int)EmployeeProjectRole.ProjectLeader,
					ProjectId = project.Id,
					//@TODO: Добавить ставку
					Rate = 1,
					StartDate = startDate,
					EndDate = endDate
				};
				dbContext.EmployeeProjects.Add(employeeProject);
				return employeeProject;
			}
		}
		public EmployeeProjectModel AttachDeveloperToProject(int employeeId, int projectId, double rate)
		{
			var employee = _employeeService.GetEmployee(employeeId);
			if (employee == null)
				throw new Exception("Пользователь с таким ID не найден");

			var project = _projectService.GetProject(projectId);
			if (project == null)
				throw new Exception("Проект с таким ID не найден");


			EmployeeProjectModel employeeProject;
			using (var dbContext = new CoreDbContext())
			{
				employeeProject = new EmployeeProjectModel()
				{
					EmployeeId = employee.Id,
					RoleId = (int) EmployeeProjectRole.Developer,
					ProjectId = project.Id,
					Rate = rate,
					//StartDate = startDate,
					//EndDate = endDate
				};
				dbContext.EmployeeProjects.Add(employeeProject);
				dbContext.SaveChanges();
			}

			return employeeProject;
		}

		public List<EmployeeProjectModel> GetAllEmployeesProjects()
		{
			List<EmployeeProjectModel> employeeProjects;
			using (var dbContext = new CoreDbContext())
			{
				employeeProjects = dbContext.EmployeeProjects.ToList();
			}

			return employeeProjects;
		}

		public List<ProjectModel> GetAvailableProjects(int employeeId)
		{
			List<ProjectModel> availableProjects;
			using (var dbContext = new CoreDbContext())
			{
				availableProjects = dbContext.EmployeeProjects.Include(ep => ep.Project)
					.Where(ep => ep.EmployeeId == employeeId)
					.Select(ep => ep.Project)
					.ToList();
			}

			return availableProjects;
		}

		public List<ProjectModel> GetEmployeeProjectsWithType(int employeeId, ProjectType projectType)
		{
			List<ProjectModel> projects;
			using (var dbContext = new CoreDbContext())
			{
				projects = dbContext.EmployeeProjects.Include(ep => ep.Project)
					.Where(ep => ep.EmployeeId == employeeId)
					.Where(ep => ep.Project.ProjectTypeId == (int) projectType)
					.Select(ep => ep.Project)
					.ToList();
			}

			return projects;
		}
	}
}
