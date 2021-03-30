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
		public UserInfo AuthenticateUser(string login, string password)
		{
			EmployeeModel employeeModel;
			using (var db = new CoreDbContext())
			{
				employeeModel = db.Employees.FirstOrDefault(user => user.Login == login && user.Password == password);
			};

			if (employeeModel == null)
				return null;

			var userInfo = new UserInfo()
			{
				Name = employeeModel.Name,
			    SecondName = employeeModel.Surname,
			    MiddleName = employeeModel.MiddleName,
			    Login = employeeModel.Login,
			    Password = employeeModel.Password,
				Role = UserRole.Administrator
			};

			return userInfo;
		}
	}
}
