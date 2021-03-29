using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
    
    public interface ITimeService
    {
        TimeRecordModel AddTime(string name, string leadEmployeeId, DateTime startDate, int DurationInMinutes);
        List<ProjectModel> GetAllProjects();
    }
}
