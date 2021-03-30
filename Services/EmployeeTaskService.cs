using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
    
    
		internal class EmployeeTaskService : IEmployeeTaskService
		{
			private readonly ITaskService _taskService;
			private readonly IEmployeeService _employeeService;
			//private readonly IProjectService _projectService;

		public EmployeeTaskService()
			{
				_taskService = new TaskService();
				_employeeService = new EmployeeService();
			//_projectService = new ProjectService();
			}

		//public EmployeeTaskModel AddTaskWithLeader(string name, DateTime startDate, DateTime endDate)
		//{
		//	var leaderEmployee = _employeeService.GetEmployee(employeeId);
		//	if (leaderEmployee == null)
		//		throw new Exception("Пользователь с таким ID не найден");

		//	using (var dbContext = new CoreDbContext())
		//	{
		//		var task = _taskService.AddTask(name, startDate, endDate );
		//		var employeeTask = new EmployeeTaskModel()
		//		{
		//			//EmployeeId = employeeLeaderId,						
		//			TaskId = task.Id,
		//			// Добавить ставку
		//			//Rate = 1,
		//			StartDate = task.StartDate,
		//			EndDate = task.EndDate
		//		};
		//		dbContext.EmployeeTasks.Add(employeeTask);
		//		return employeeTask;
		//	}
		//}
		//public EmployeeTaskModel AddTaskEmpoyee(string projectId, string name, DateTime startDate, DateTime endDate, int employeeId)
		//{
		//	var leaderEmployee = _employeeService.GetEmployee(employeeId);
		//	if (leaderEmployee == null)
		//		throw new Exception("Пользователь с таким ID не найден");
		//	using (var dbContext = new CoreDbContext())
		//	{
		//		var task = _taskService.AddTask( name, startDate, endDate);
		//		var employeeTask = new EmployeeTaskModel()
		//		{
		//			//EmployeeId = employeeLeaderId,						
		//			TaskId = task.Id,
		//			// Добавить ставку
		//			//Rate = 1,
		//		};
		//		dbContext.EmployeeTasks.Add(employeeTask);
		//		return employeeTask;
		//	}
		//}
		public EmployeeTaskModel AddTaskEmpoyee( int name,  int employeeId)
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
	}
	}
