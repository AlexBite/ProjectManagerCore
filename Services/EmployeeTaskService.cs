using Microsoft.EntityFrameworkCore;
using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{
	internal class EmployeeTaskService : IEmployeeTaskService
	{
		private readonly ITaskService _taskService;
		private readonly IEmployeeService _employeeService;

		public EmployeeTaskService()
		{
			_taskService = new TaskService();
			_employeeService = new EmployeeService();
		}
		public EmployeeTaskModel AddTaskEmpoyee(int name, int employeeId)
		{
			var leaderEmployee = _employeeService.GetEmployee(employeeId);
			if (leaderEmployee == null)
				throw new Exception("Пользователь с таким ID не найден");
			var task = _taskService.GetTask(name);//int
			if (task == null)
				throw new Exception("Задача с таким ID не найдена");
			using (var dbContext = new CoreDbContext())
			{
				//var task = _taskService.AddTask(name);
				var employeeTask = new EmployeeTaskModel()
				{
					//EmployeeId = employeeLeaderId,						
					TaskId = task.Id

				};
				dbContext.EmployeeTasks.Add(employeeTask);
				return employeeTask;
			}
		}

		public List<EmployeeTaskModel> GetEmployeeTasksConnectedToProject(int employeeId, int projectId)
		{
			List<EmployeeTaskModel> employeeTasks;
			using (var dbContext = new CoreDbContext())
			{
				employeeTasks = dbContext.EmployeeTasks.Include(et => et.Task)
					.Where(et => et.EmployeeId == employeeId)
					.Where(et => et.Task.ProjectId == projectId)
					.ToList();
			}

			return employeeTasks;
		}
	}
}
