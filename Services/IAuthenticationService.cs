using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
	public interface IAuthenticationService
	{
		EmployeeModel AuthenticateUser(string login, string password);
	}
}
