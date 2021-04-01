using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace ProjectManagerCore.Services
{
	public interface IEmployeeTaskService
	{
		EmployeeTaskModel AddTaskEmpoyee(int taskId, int employeeId);
		List<EmployeeTaskModel> GetEmployeeTasksConnectedToProject(int employeeId, int projectId);
	}

}
