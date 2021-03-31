using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
    public interface IEmployeeDepartmentService
    {
        EmployeeDepartmentModel AddEmployeeDepartment(int departmentId, int employeeId, int position, DateTime startDate, DateTime endDate);
        EmployeeDepartmentModel GetEmployeeDepartment(int taskId);
    }
}
