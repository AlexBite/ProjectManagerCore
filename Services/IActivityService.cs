using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
 
    public interface IActivityService
    {
        ActivityModel AddActivity(string name);
        List<ActivityModel> GetAllActivities();
    }
}
