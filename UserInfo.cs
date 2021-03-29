using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WorkingTimeTracker
{
	[Serializable]
	public class UserInfo
	{
		public int Id { get; set; }
		public string Fio { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public UserRole Role { get; set; }

		[Serializable]
		public enum UserRole
		{
			Empty = 0,
			Leader = 1,
			Employee = 2,
			Director = 3,
			DirPro=4
		}
	}
}
