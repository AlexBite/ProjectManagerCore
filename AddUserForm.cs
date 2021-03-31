using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ProjectManagerCore.Services;

namespace WorkingTimeTracker
{
	public partial class AddUserForm : Form
	{
		private readonly IEmployeeService _employeeService;
		public AddUserForm()
		{
			InitializeComponent();
			_employeeService = new EmployeeService();
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			bool notAllInfoInputed = (SurnameTb.Text == string.Empty || NameTb.Text == string.Empty || MiddleNameTb.Text == string.Empty|| LoginTb.Text == string.Empty|| PasswordTb.Text == string.Empty|| PhoneBox.Text == string.Empty);

			if (notAllInfoInputed)
			{
				MessageBox.Show("Необходимо заполнить все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var surname = SurnameTb.Text;
			var name = NameTb.Text;
			var middleName = MiddleNameTb.Text;
			var login = LoginTb.Text;
			var password = PasswordTb.Text;
			var phoneNumber = PhoneBox.Text;

			_employeeService.AddWorker(surname, name, middleName, login, password, phoneNumber);
			this.Close();
		}
	}
}


