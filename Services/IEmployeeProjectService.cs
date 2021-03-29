using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
	interface IEmployeeProjectService
	{
		EmployeeProjectModel AddProjectWithLeader(string name, DateTime startDate, DateTime endDate, int employeeLeaderId);
	}
}
