using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Models
{
	public class ProjectModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		//public int ProjectTypeId { get; set; }
		//public ProjectTypeModel ProjectType { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		//public ICollection<TaskModel> Tasks { get; set; }
		//public ICollection<EmployeeProjectModel> Employees { get; set; }
	}
}
