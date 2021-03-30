using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{    
		internal class ActivityService : IActivityService
		{
			public ActivityModel AddActivity(string name)
			{
				var activity = new ActivityModel()
				{
					Description = name
				};

				using (var dbContext = new CoreDbContext())
				{
					dbContext.Activities.Add(activity);
					dbContext.SaveChanges();
				}

				return activity;
			}
		public List<ActivityModel> GetAllActivities()
	{
		List<ActivityModel> departments;
		using (var dbContext = new CoreDbContext())
		{
			departments = dbContext.Activities.ToList();
		}
		return departments;
	}
	}
	
}