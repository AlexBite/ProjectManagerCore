using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
    public interface ITaskService
    {
        TaskModel AddTask(string name, DateTime startDate, DateTime endDate);
        List<TaskModel> GetAllTasks();
        //void DeleteProject(int id);
    }
}
