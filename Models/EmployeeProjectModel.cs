using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Models
{
	public class EmployeeProjectModel
	{
		public int Id { get; set; }
		public int? EmployeeId { get; set; }
		public EmployeeModel Employee { get; set; }
		public int? RoleId { get; set; }
		public RoleModel Role { get; set; }
		public int? ProjectId { get; set; }
		public ProjectModel Project { get; set; }
		public double Rate { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
