using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Models
{
    class EmployeeJobModel
    {
		public int Id { get; set; }
		public int? JobId { get; set; }		
		public int? EmployeeId { get; set; }
		public EmployeeModel Employee { get; set; }
		public int? PositionId { get; set; }
		public PositionModel Position { get; set; }
		public DateTime StartWorkingDate { get; set; }
		public DateTime EndWorkingDate { get; set; }
	}
}
