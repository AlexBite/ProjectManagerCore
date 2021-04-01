using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
	public interface ITimeRecordService
	{
		TimeRecordModel AddTime(string description, int taskId, int activityId, DateTime date, DateTime time, int duration);
		List<TimeRecordModel> GetAllTime();
		void DeleteTime(int id);
	}
}
