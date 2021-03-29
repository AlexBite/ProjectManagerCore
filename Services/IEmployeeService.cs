using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
	public interface IEmployeeService
	{
		EmployeeModel GetEmployee(int employeeId);
		EmployeeModel AddWorker(string secname, string firstname, string thirdname, string login, string password, string phone);
		List<EmployeeModel> GetAllEmployee();
	}
}
