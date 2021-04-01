using Microsoft.EntityFrameworkCore;
using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{
	internal class TimeRecordService : ITimeRecordService
	{
		public TimeRecordModel AddTime(string description, int taskId, int activityId, DateTime date, DateTime time, int duration)
		{
			var timerec = new TimeRecordModel()
			{
				Title = description,
				TaskId = taskId,
				ActivityId = activityId,
				StartDate = date,
				DurationInMinutes = duration
			};

			using (var dbContext = new CoreDbContext())
			{
				dbContext.TimeRecords.Add(timerec);
				dbContext.SaveChanges();
			}

			return timerec;

		}

		public void DeleteTime(int id)
		{
			using (var dbContext = new CoreDbContext())
			{
				var timeToDelete = dbContext.TimeRecords.FirstOrDefault(p => p.Id == id);
				dbContext.TimeRecords.Remove(timeToDelete);
				dbContext.SaveChanges();
			}
		}

		public List<TimeRecordModel> GetAllTime()
		{
			List<TimeRecordModel> timeRecords;
			using (var dbContext = new CoreDbContext())
			{
				timeRecords = dbContext.TimeRecords.ToList();
			}

			return timeRecords;
		}

		public List<TimeRecordModel> GetEmployeeTimeRecordsConnectedToTask(int employeeId, int taskId)
		{
			List<TimeRecordModel> timeRecords;
			using (var dbContext = new CoreDbContext())
			{
				timeRecords = dbContext.TimeRecords.Where(tr => tr.EmployeeId == employeeId)
					.Where(tr => tr.TaskId == taskId)
					.ToList();
			}

			return timeRecords;
		}
	}
}
