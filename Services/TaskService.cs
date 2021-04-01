using System;
using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagerCore.Services
{
	internal class TaskService : ITaskService
    {
		
			public TaskModel AddTask( int projectId, string name,  DateTime startDate, DateTime endDate)
			{
				var task = new TaskModel()
				{
					ProjectId = projectId,
					Description = name,
					StartDate = startDate,
					EndDate = endDate
				};

				using (var dbContext = new CoreDbContext())
				{
					dbContext.Tasks.Add(task);
					dbContext.SaveChanges();
				}

				return task;
			}

        public void DeleteTask(int Prid)
        {
            using (var dbContext = new CoreDbContext())
            {
                var taskToDelete = dbContext.Tasks.FirstOrDefault(p => p.ProjectId == Prid);
                //dbContext.Tasks.Remove(taskToDelete);
                dbContext.SaveChanges();
            }
        }

        public List<TaskModel> GetAllTasks()
			{
				List<TaskModel> tasks;
				using (var dbContext = new CoreDbContext())
				{
					tasks = dbContext.Tasks.ToList();
				}
				return tasks;
			}

		
		public TaskModel GetTask(int taskId)
		{
			TaskModel taskModel;
			using (var dbContext = new CoreDbContext())
			{
				taskModel = dbContext.Tasks.Where(e => e.Id == taskId)
					.FirstOrDefault();
			}

			return taskModel;
		}
		public void GetTaskName(int taskId)
		{
			
			string taskModel;
			using (var dbContext = new CoreDbContext())
			{
				taskModel = dbContext.Tasks.Where(e => e.Id == taskId)
					.ToString();
			}

			//return taskModel;
		}

	}
}
