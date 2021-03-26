using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Models
{
	public class TimeRecordModel
	{
		public int Id { get; set; }
		public int EmployeeId { get; set; }
		public EmployeeModel Employee { get; set; }
		public int TaskId { get; set; }
		public TaskModel Task { get; set; }
		public string Title { get; set; }
		public int ActivityId { get; set; }
		public ActivityModel Activity { get; set; }
		public DateTime StartDate { get; set; }
		public int DurationInMinutes { get; set; }
	}
}
