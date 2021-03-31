using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{

    internal class DepartmentPositionService : IDepartmentPositionService

    {
		private readonly IDepartmentService _departmentService;
		private readonly IPositionService _positionService;
		private readonly IEmployeeService _employeeService;
		public DepartmentPositionService()
		{
			_departmentService = new DepartmentService();
			_positionService = new PositionService();
			_employeeService = new EmployeeService();
		}

		public EmployeeDepartmentModel EmployeeDepartment(int departmentId, int employeeId, int positionId, DateTime startDate, DateTime endDate)
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

        public EmployeeDepartmentModel GetEmployeeDepartment(int taskId)
        {
			EmployeeDepartmentModel depModel;
			using (var dbContext = new CoreDbContext())
			{
				depModel = dbContext.EmployeeDepartments.Where(e => e.Id == taskId)
					.FirstOrDefault();
			}

			return depModel;
		}
    }
}

