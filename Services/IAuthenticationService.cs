using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WorkingTimeTracker;

namespace ProjectManagerCore.Services
{
	public interface IAuthenticationService
	{
		UserInfo AuthenticateUser(string login, string password);
	}
}
