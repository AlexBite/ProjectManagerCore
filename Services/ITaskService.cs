using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
    public interface ITaskService
    {
        TaskModel AddTask( int projectId, string name, DateTime startDate, DateTime endDate);
        List<TaskModel> GetAllTasks();        
        
        TaskModel GetTask(int taskId);
        
        void DeleteTask(int Prid);
    }
}
