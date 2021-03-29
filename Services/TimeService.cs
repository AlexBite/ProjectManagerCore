using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{
    class TimeService
    {
        public TimeRecordModel AddTime()
        {
            var time = new TimeRecordModel(string title, DateTime StartDate, int DurationInMinutes)
            {

                //Surname = secname,
                //Name = firstname,
                //MiddleName = thirdname,
                //Login = login,
                //Password = password,
                //PhoneNumber = phone

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
