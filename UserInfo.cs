using ProjectManagerCore.Services;
using System;

namespace WorkingTimeTracker
{
	public class UserInfo
	{
		public string Name { get; set; }
		public string SecondName { get; set; }
		public string MiddleName { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public UserRole Role { get; set; }

		public string GetFullNameString()
		{
			return $"{SecondName} {Name} {MiddleName}";
		}
	}
}
