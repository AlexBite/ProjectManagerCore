using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
	public interface IDepartmentService
	{
		DepartmentModel AddDepartment(string name);
		List<DepartmentModel> GetAllDepartment();
	}
}
