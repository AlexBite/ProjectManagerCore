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
		public DepartmentModel AddDepartment(string departmentName)
		{
			var department = new DepartmentModel()
			{
				Name = departmentName
			};

			using (var dbContext = new CoreDbContext())
			{
				dbContext.DepartmentModels.Add(department);
				dbContext.SaveChanges();
			}

			return department;
		}

		public DepartmentModel GetDepartment(int departmentId)
		{
			DepartmentModel department;
			using (var dbContext = new CoreDbContext())
			{
				department = dbContext.DepartmentModels.Where(e => e.Id == departmentId)
					.FirstOrDefault();
			}

			return department;
		}

		public List<DepartmentModel> GetAllDepartments()
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
