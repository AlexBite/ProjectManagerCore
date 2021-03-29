using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{
    class TimeService
    {
        public TimeModel AddTime(string secname, string firstname, string thirdname, string login, string password, string phone)
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
                employees = dbContext.Employees.ToList();
            }
            return employees;
        }
    }
}
