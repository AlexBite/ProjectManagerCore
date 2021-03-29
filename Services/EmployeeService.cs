using Microsoft.EntityFrameworkCore;
using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeModel AddWorker(string secname, string firstname, string thirdname, string login, string password, string phone)
        {
            var worker = new EmployeeModel()
            {
                Surname = secname,
                Name = firstname,
                MiddleName = thirdname,
                Login = login,
                Password = password,
                PhoneNumber = phone
            };

            using (var dbContext = new CoreDbContext())
            {
                dbContext.Employees.Add(worker);
                dbContext.SaveChanges();
            }

            return worker;
        }

        public List<EmployeeModel> GetAllEmployee()
        {
            List<EmployeeModel> employees;
            using (var dbContext = new CoreDbContext())
            {
                employees = dbContext.Employees.Include(e => e.Departments)
                    .ToList();
            }
            return employees;
        }

		public EmployeeModel GetEmployee(int employeeId)
		{
            EmployeeModel employeeModel;
            using (var dbContext = new CoreDbContext())
            {
                employeeModel = dbContext.Employees.Where(e => e.Id == employeeId)
                    .FirstOrDefault();
            }

            return employeeModel;
        }
	}
}
