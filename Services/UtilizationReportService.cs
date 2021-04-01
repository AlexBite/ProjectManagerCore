using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{
	internal class UtilizationReportService : IUtilizationReportService
	{
		public UtilizationReportService()
		{

		}

		public List<UtilizationReport> GetUtilizationReport(int employeeId)
		{
			List<UtilizationReport> utilizationReports = new List<UtilizationReport>();
			using (var dbContext = new CoreDbContext())
			{
				var department = dbContext.EmployeeDepartments.Include(ed => ed.Department)
					.FirstOrDefault(ed => ed.EmployeeId == employeeId);

				var employees = dbContext.EmployeeDepartments.Include(ed => ed.Employee)
					.Where(ed => ed.DepartmentId == department.Id)
					.Select(ed => ed.Employee)
					.ToList();

				foreach (var employee in employees)
				{
					
				}
			}
			
		}
	}
}
