using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Models
{
	public class EmployeeDepartmentModel
	{
		public int Id { get; set; }
		public int DepartmentId { get; set; }
		public DepartmentModel Department { get; set; }
		public int EmployeeId { get; set; }
		public EmployeeModel Employee { get; set; }
		public int PositionId { get; set; }
		public PositionModel Position { get; set; }
		public DateTime StartWorkingDate { get; set; }
		public DateTime EndWorkingDate { get; set; }
	}
}
