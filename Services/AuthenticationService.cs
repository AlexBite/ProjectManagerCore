using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{
	internal class AuthenticationService : IAuthenticationService
	{
		public EmployeeModel AuthenticateUser(string login, string password)
		{
			EmployeeModel authenticatedUser;
			using (var db = new CoreDbContext())
			{
				authenticatedUser = db.Employees.FirstOrDefault(user => user.Login == login && user.Password == password);
			};

			return authenticatedUser;
		}
	}
}
