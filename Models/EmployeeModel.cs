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
		//@TODO: Поменять на связь 1 к 1
		public ICollection<EmployeeDepartmentModel> Departments { get; set; }
		public ICollection<EmployeeProjectModel> Projects { get; set; }
		public ICollection<EmployeeTaskModel> Tasks { get; set; }
		//должност, дата начала работы, дата окончания работы
	}
}
