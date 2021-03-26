using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Models
{
	public class EmployeeModel
	{
		public int Id { get; set; }
		public string Surname { get; set; }
		public string Name { get; set; }
		public string MiddleName { get; set; }
		public string PhoneNumber { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public ICollection<EmployeeDepartmentModel> Departments { get; set; }
		public ICollection<EmployeeProjectModel> Projects { get; set; }
		public ICollection<EmployeeTaskModel> Tasks { get; set; }
	}
}
