using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Models
{
	public class EmployeeTaskModel
	{
		public int Id { get; set; }
		public int? EmployeeId { get; set; }
		public EmployeeModel Employee { get; set; }
		public int TaskId { get; set; }
		public TaskModel Task { get; set; }
	}
}
