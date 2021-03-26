using Microsoft.EntityFrameworkCore;
using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
			Application.Run(new Form1());
		}

		private static void InitializeDataBases()
		{
			using (var db = new CoreDbContext())
			{
				var someActivity = new ActivityModel()
				{
					Description = "Some Activity"
				};
				db.Activities.Add(someActivity);
				db.SaveChanges();
			}
		}
	}
}
