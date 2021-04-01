using Microsoft.EntityFrameworkCore;
using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{
	internal class UtilizationReportService : IUtilizationReportService
	{
		private readonly ITimeRecordService _timeRecordService;
		private readonly IEmployeeTaskService _employeeTaskService;
		private readonly IEmployeeProjectService _employeeProjectService;
		private readonly IEmployeeService _employeeService;

		public UtilizationReportService()
		{
			_timeRecordService = new TimeRecordService();
			_employeeTaskService = new EmployeeTaskService();
			_employeeProjectService = new EmployeeProjectService();
			_employeeService = new EmployeeService();
		}

		public List<UtilizationReport> GetUtilizationReport()
		{
			var utilizationReports = new List<UtilizationReport>();
			var employees = _employeeService.GetAllEmployee();
			foreach (var emp in employees)
			{
				var utilReport = GetEmployeeUtilizationReport(emp);
				utilizationReports.Add(utilReport);
			}

			return utilizationReports;
		}

		private UtilizationReport GetEmployeeUtilizationReport(EmployeeModel employee)
		{
			var employeeId = employee.Id;
			var internalProjects = _employeeProjectService.GetEmployeeProjectsWithType(employeeId, ProjectType.Internal);
			var internalTasks = ProcessProjects(employeeId, internalProjects);
			var internalTimeRecords = ProcessTask(employeeId, internalTasks);
			var internalTimeSumm = ProcessTimeRecords(internalTimeRecords);

			var externalProjects = _employeeProjectService.GetEmployeeProjectsWithType(employeeId, ProjectType.External);
			var extenalTasks = ProcessProjects(employeeId, internalProjects);
			var extenalTimeRecords = ProcessTask(employeeId, internalTasks);
			var extenalTimeSumm = ProcessTimeRecords(internalTimeRecords);

			double utilValue;
			if (extenalTimeSumm != 0)
			{
				utilValue = internalTimeSumm / extenalTimeSumm;
			}
			else
			{
				utilValue = 0;
			}

			var utilReport = new UtilizationReport()
			{
				EmployeeName = employee.Name,
				EmployeeSurname = employee.Surname,
				EmployeeMiddleName = employee.MiddleName,
				UtilizationValue = utilValue
			};

			return utilReport;
		}

		private List<EmployeeTaskModel> ProcessProjects(int employeeId, List<ProjectModel> projectModels)
		{
			var employeeProjectTasks = new List<EmployeeTaskModel>();
			foreach (var project in projectModels)
			{
				var tasks = _employeeTaskService.GetEmployeeTasksConnectedToProject(employeeId, project.Id);
				employeeProjectTasks.AddRange(tasks);
			}

			return employeeProjectTasks;
		}

		private List<TimeRecordModel> ProcessTask(int employeeId, List<EmployeeTaskModel> employeeTasks)
		{
			var timeRecords = new List<TimeRecordModel>();
			foreach (var task in employeeTasks)
			{
				var records = _timeRecordService.GetEmployeeTimeRecordsConnectedToTask(employeeId, task.Id);
				timeRecords.AddRange(records);
			}

			return timeRecords;
		}

		private int ProcessTimeRecords(List<TimeRecordModel> timeRecords)
		{
			int summaryTime = 0;
			foreach (var timeRecord in timeRecords)
			{
				summaryTime += timeRecord.DurationInMinutes;
			}

			return summaryTime;
		}
	}
}
