using ProjectManagerCore.Models;
using ProjectManagerCore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
	public partial class AddUsersPro : Form
	{
		private readonly IEmployeeService _employeeService;
		private readonly IProjectService _projectService;
		private readonly IEmployeeProjectService _employeeprojectService;

		public AddUsersPro()
		{
			_projectService = new ProjectService();
			_employeeprojectService = new EmployeeProjectService();
			_employeeService = new EmployeeService();
			InitializeComponent();
			SetProjectsDgv();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			bool notAllInfoInputed = (employeeCb.Text == string.Empty || projectCb.Text == string.Empty || rateTb.Text == string.Empty );

			if (notAllInfoInputed)
			{
				MessageBox.Show("Необходимо заполнить все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			AddEmployeeToProject();
			//LoadData();
			SetProjectsDgv();
		}

		private void LoadData()
		{
			string connectString = "Data Source=.\\SQLLite;Initial Catalog=core;" +
				"Integrated Security=true;";

			SqlConnection myConnection = new SqlConnection(connectString);

			myConnection.Open();

			string query = "SELECT * FROM EmployeeProjects ORDER BY Id";

			SqlCommand command = new SqlCommand(query, myConnection);

			SqlDataReader reader = command.ExecuteReader();

			List<string[]> data = new List<string[]>();

			while (reader.Read())
			{
				data.Add(new string[5]);

				data[data.Count - 1][0] = reader[0].ToString();//название
				data[data.Count - 1][1] = reader[1].ToString();//фамилия
				data[data.Count - 1][2] = reader[2].ToString();//имя
				data[data.Count - 1][2] = reader[3].ToString();//отчество
				data[data.Count - 1][2] = reader[4].ToString();//ставка
			}

			reader.Close();

			myConnection.Close();

			foreach (string[] s in data)
				employeeProjectDgv.Rows.Add(s);
		}
			private void AddEmployeeToProject()
		{
			var employee = this.employeeCb.SelectedItem as EmployeeModel;
			var project = this.projectCb.SelectedItem as ProjectModel;
			var rate = Convert.ToDouble(this.rateTb.Text);
			_employeeprojectService.AttachDeveloperToProject(project.Id, employee.Id, rate);
		}
		private void comboBox1_Click(object sender, EventArgs e)//кб проекта
		{
			var comboBox = sender as ComboBox;
			var allProjects = _projectService.GetAllProjects();
			comboBox.ValueMember = nameof(ProjectModel.Id);
			comboBox.DisplayMember = nameof(ProjectModel.Name);
			comboBox.DataSource = allProjects;
		}

		private void comboBox2_Click(object sender, EventArgs e)//кб пользователя
		{
			var comboBox = sender as ComboBox;
			var allEmployees = _employeeService.GetAllEmployee();
			comboBox.ValueMember = nameof(EmployeeModel.Id);
			comboBox.DisplayMember = nameof(EmployeeModel.Name);
			comboBox.DataSource = allEmployees;
		}
		private void SetProjectsDgv()
		{
			var bindingSource = new BindingSource();
			var allProjects = _employeeprojectService.GetAllEmployeesProjects();
			bindingSource.DataSource = allProjects;
			{
				employeeProjectDgv.Rows.Clear();
				employeeProjectDgv.Columns.Clear();

				employeeProjectDgv.AutoGenerateColumns = false;
				employeeProjectDgv.AutoSize = true;
				
				employeeProjectDgv.ScrollBars = ScrollBars.Both;
				employeeProjectDgv.Controls[0].Enabled = true;
				employeeProjectDgv.Controls[1].Enabled = true;

				employeeProjectDgv.DataSource = bindingSource;
				{
					var projectNameColumn = new DataGridViewTextBoxColumn();
					projectNameColumn.DataPropertyName = nameof(EmployeeProjectModel.ProjectId);
					projectNameColumn.Name = "Название проекта";
					employeeProjectDgv.Columns.Add(projectNameColumn);

					var employeeSurname = new DataGridViewTextBoxColumn();
					employeeSurname.DataPropertyName = nameof(EmployeeProjectModel.EmployeeId);
					employeeSurname.Name = "Сотрудник";
					employeeProjectDgv.Columns.Add(employeeSurname);


					var rateColumn = new DataGridViewTextBoxColumn();
					rateColumn.DataPropertyName = nameof(EmployeeProjectModel.Rate);
					rateColumn.Name = "Ставка";
					employeeProjectDgv.Columns.Add(rateColumn);
				}

				var allTasks = _employeeService.GetAllEmployee();

				//var bindingSource1 = new BindingSource();
				//bindingSource1.DataSource = allTasks;
				//employeeProjectDgv.DataSource = bindingSource1;
				//{

				//	var employeeSurname = _employeeprojectService.GetAllEmployeesProjects();
				//	var employeeSurnameColumn = new DataGridViewTextBoxColumn();
				//	employeeSurnameColumn.DataPropertyName = nameof(EmployeeModel.Surname);
				//	employeeSurnameColumn.Name = "Фамилия";
				//	employeeProjectDgv.Columns.Add(employeeSurnameColumn);

				//	var employeeNameColumn = new DataGridViewTextBoxColumn();
				//	employeeNameColumn.DataPropertyName = nameof(EmployeeModel.Name);
				//	employeeNameColumn.Name = "Имя";
				//	employeeProjectDgv.Columns.Add(employeeNameColumn);

				//	var middleNameColumn = new DataGridViewTextBoxColumn();
				//	middleNameColumn.DataPropertyName = nameof(EmployeeModel.MiddleName);
				//	middleNameColumn.Name = "Отчество";
				//	employeeProjectDgv.Columns.Add(middleNameColumn);
				//}
			}
			
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
