using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
	internal class DepartmentService : IDepartmentService
	{
		public DepartmentModel AddDepartment(string name)
		{
			var department = new DepartmentModel()
			{
				Name = name
			};

			using (var dbContext = new CoreDbContext())
			{
				dbContext.DepartmentModels.Add(department);
				dbContext.SaveChanges();
			}

			return department;
		}
	}
}
