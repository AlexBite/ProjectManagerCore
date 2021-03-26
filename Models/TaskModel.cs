using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Models
{
	public class TaskModel
	{
		public int Id { get; set; }
		public int ProjectId { get; set; }
		public ProjectModel Project { get; set; }
		public string Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public ICollection<EmployeeTaskModel> Employees { get; set; }
		public ICollection<TimeRecordModel> TimeRecords { get; set; }
	}
}
