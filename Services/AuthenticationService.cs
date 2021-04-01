using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkingTimeTracker;

namespace ProjectManagerCore.Services
{
	internal class AuthenticationService : IAuthenticationService
	{
		private readonly IEmployeeDepartmentService _employeeDepartmentService;
		public AuthenticationService()
		{
			_employeeDepartmentService = new EmployeeDepartmentService();
		}

		public UserInfo AuthenticateUser(string login, string password)
		{
			EmployeeModel employee;
			using (var db = new CoreDbContext())
			{
				employee = db.Employees.FirstOrDefault(user => user.Login == login && user.Password == password);
			};

			if (employee == null)
				return null;

			var position = _employeeDepartmentService.GetEmployeePosition(employee.Id);
			if (position == null)
				return null;

			var userInfo = new UserInfo()
			{
				Name = employee.Name,
				SecondName = employee.Surname,
				MiddleName = employee.MiddleName,
				Login = employee.Login,
				Password = employee.Password,
				Position = position
			};

			return userInfo;
		}
	}
}
