using ProjectManagerCore.Models;
using System;
using System.Windows.Forms;
using WorkingTimeTracker;

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
			InitializeDataBases();
			Application.Run(new MainForm());
		}

		private static void InitializeDataBases()
		{
			//using (var db = new CoreDbContext())
			//{
			//	var someTask = new TaskModel()
			//	{
			//		Description = "Some Task",
			//		ProjectId = 1
			//	};
			//	db.Tasks.Add(someTask);
			//	db.SaveChanges();
			//}
		}
	}
}
