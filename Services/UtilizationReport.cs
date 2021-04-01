using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
	public class UtilizationReport
	{
		public string EmployeeSurname;
		public string EmployeeName;
		public string EmployeeMiddleName;
		// сумма часов на внутренних делить на сумму часов на внешних
		public double UtilizationValue;
	}
}
