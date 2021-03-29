using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
    
    public interface ITimeService
    {
        TimeRecordModel AddTime(string title, DateTime StartDate, int DurationInMinutes);
        List<EmployeeModel> GetAllEmployee();
    }
}
