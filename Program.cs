using Microsoft.EntityFrameworkCore;
using ProjectManagerCore.Models;
using ProjectManagerCore.Services;
using System;
using System.Linq;
using System.Windows.Forms;
using WorkingTimeTracker;
using Курсовая;

namespace ProjectManagerCore
{
	static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//DbCustomMigrate();
			Application.Run(new LoginForm());
		}

		//private static void DbCustomMigrate()
		//{
		//	using (var db = new CoreDbContext())
		//	{
		//		var rolesCount = db.Roles.Count();
		//		if (rolesCount == 0)
		//		{
		//			var adminRole = new RoleModel()
		//			{
		//				Id = 0,
		//				Name = "Администратор"
		//			};
		//		}

		//		var administrator = db.Employees.Include(u => u.Projects)
		//			.Include(u => u.Projects.Where(p => p.RoleId == (int)EmployeeProjectRole.Administrator))
		//			.FirstOrDefault();

		//		if (administrator != null)
		//			return;

		//		var initialProject = new ProjectModel()
		//		{
		//			Name = "Initial project",
		//			StartDate = new DateTime(),
		//			EndDate = DateTime.Now
		//		};

		//		var initialUser = new EmployeeModel()
		//		{
		//			Surname = "Admin",
		//			Name = "Admin",
		//			MiddleName = "Admin",
		//			PhoneNumber = string.Empty,
		//			Login = "root",
		//			Password = string.Empty
		//		};

		//		db.Projects.Add(initialProject);
		//		db.Employees.Add(initialUser);
		//		db.SaveChanges();

		//		var createdUser = db.Employees.FirstOrDefault(e => e.Login == "root" && e.Password == string.Empty);

		//		var createdProject = db.Projects.FirstOrDefault(p => p.Name == "Initial project");

		//		var userProjectModel = new EmployeeProjectModel()
		//		{
		//			EmployeeId = createdUser.Id,
		//			RoleId = 0,
		//			ProjectId = createdProject.Id,
		//			StartDate = new DateTime(),
		//			EndDate = DateTime.Now
		//		};
		//	}
		//}

	}
}
