using Microsoft.EntityFrameworkCore;
using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{

	internal class EmployeeDepartmentService : IEmployeeDepartmentService
	{
		private readonly IDepartmentService _departmentService;
		private readonly IPositionService _positionService;
		private readonly IEmployeeService _employeeService;
		public EmployeeDepartmentService()
		{
			_departmentService = new DepartmentService();
			_positionService = new PositionService();
			_employeeService = new EmployeeService();
		}

		public EmployeeDepartmentModel AddEmployeeDepartment(int departmentId, int employeeId, int positionId, DateTime startDate, DateTime endDate)
		{
			var employee = _employeeService.GetEmployee(employeeId);
			if (employee == null)
				throw new Exception("Пользователь с таким ID не найден");

			var department = _departmentService.GetDepartment(departmentId);
			if (department == null)
				throw new Exception("Департамент с таким ID не найден");

			var position = _positionService.GetPosition(positionId);
			if (position == null)
				throw new Exception("Должность с таким ID не найдена");

			EmployeeDepartmentModel employeeDepartment;
			using (var dbContext = new CoreDbContext())
			{
				employeeDepartment = new EmployeeDepartmentModel()
				{
					EmployeeId = employee.Id,
					DepartmentId = department.Id,
					PositionId = position.Id,
					StartWorkingDate = startDate,
					EndWorkingDate = endDate
				};
				dbContext.EmployeeDepartments.Add(employeeDepartment);
				dbContext.SaveChanges();
			}

			return employeeDepartment;
		}

		public EmployeeDepartmentModel GetEmployeeDepartment(int departmentId)
		{
			EmployeeDepartmentModel department;
			using (var dbContext = new CoreDbContext())
			{
				department = dbContext.EmployeeDepartments.Where(e => e.Id == departmentId)
					.FirstOrDefault();
			}

			return department;
		}

		public PositionModel GetEmployeePosition(int employeeId)
		{
			PositionModel position;
			using (var dbContext = new CoreDbContext())
			{
				var employeeDepartment = dbContext.EmployeeDepartments.Include(e => e.Position)
					.FirstOrDefault(ed => ed.EmployeeId == employeeId);

				position = employeeDepartment.Position;
			}

			return position;
		}

		public List<EmployeeModel> GetEmployeesFromDepartment(int departmentId)
		{
			List<EmployeeModel> employees;
			using (var dbContext = new CoreDbContext())
			{
				employees = dbContext.EmployeeDepartments.Include(e => e.Employee)
					.Where(ed => ed.DepartmentId == departmentId)
					.Select(ed => ed.Employee)
					.ToList();
			}

			return employees;
		}
	}
}

