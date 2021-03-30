using System;
using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{
	internal class TaskService : ITaskService
    {
		
			public TaskModel AddTask( string name, DateTime startDate, DateTime endDate)
			{
				var task = new TaskModel()
				{
					//ProjectId = Convert.ToInt32(projectId),
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

			//public void DeleteProject(int id)
			//{
			//	using (var dbContext = new CoreDbContext())
			//	{
			//		var projectToDelete = dbContext.Projects.FirstOrDefault(p => p.Id == id);
			//		dbContext.Projects.Remove(projectToDelete);
			//		dbContext.SaveChanges();
			//	}
			//}

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
	}
}
