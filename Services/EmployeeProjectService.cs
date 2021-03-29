using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
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

		public EmployeeProjectModel AddProjectWithLeader(string name, DateTime startDate, DateTime endDate, int employeeLeaderId)
		{
			var leaderEmployee = _employeeService.GetEmployee(employeeLeaderId);
			if (leaderEmployee == null)
				throw new Exception("Пользователь с таким ID не найден");

			using (var dbContext = new CoreDbContext())
			{
				var project = _projectService.AddProject(name, startDate, endDate);
				var employeeProject = new EmployeeProjectModel()
				{
					EmployeeId = employeeLeaderId,
					RoleId = (int)UserRole.ProjectLeader,
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
	}
}
