using Microsoft.EntityFrameworkCore;
using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
		public DepartmentModel GetDepartment(int taskId)
		{
			DepartmentModel depModel;
			using (var dbContext = new CoreDbContext())
			{
				depModel = dbContext.DepartmentModels.Where(e => e.Id == taskId)
					.FirstOrDefault();
			}

			return depModel;
		}
		public List<DepartmentModel> GetAllDepartment()
		{
			List<DepartmentModel> departments;
			using (var dbContext = new CoreDbContext())
			{
				departments = dbContext.DepartmentModels.ToList();
			}
			return departments;
		}
	}
}
