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
using ProjectManagerCore.Models;
using ProjectManagerCore.Services;
using Курсовая;
using NsExcel = Microsoft.Office.Interop.Excel;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;

namespace WorkingTimeTracker
{
	public partial class MainForm : Form
	{
		private readonly IProjectService _projectService;
		private readonly IEmployeeService _employeeService;
		private readonly IEmployeeProjectService _employeeProjectService;
		private readonly UserInfo _authenticatedUser;
		private readonly ITaskService _taskService;
		private readonly IActivityService _activityService;
		private readonly ITimeRecordService _timeService;
		private readonly IProjectTypeService _projectTypeService;
		private readonly IUtilizationReportService _utilizationReportService;

		public MainForm(UserInfo authenticatedUser)
		{
			_projectService = new ProjectService();
			_employeeService = new EmployeeService();
			_employeeProjectService = new EmployeeProjectService();
			_authenticatedUser = authenticatedUser;
			_taskService = new TaskService();
			_activityService = new ActivityService();
			_timeService = new TimeRecordService();
			_projectTypeService = new ProjectTypeService();
			_utilizationReportService = new UtilizationReportService();

			InitializeComponent();

			SetNameLabel();
			SetProjectsDgv();
			SetWorkersDgv();
			SetTimeDgv();
			MainPanel.Visible = true;

		}

		private void SetNameLabel()
		{
			fioLabel.Text = _authenticatedUser.GetFullNameString();
			fioLabel.Text += $" ({_authenticatedUser.GetPositionName()}) ";
			if (_authenticatedUser.Position.ToString() == "Директор департамента" || _authenticatedUser.Position.ToString() == "Руководитель проекта")
			{
				DeleteSessionbutton.Visible = true;
			}

		}


		private void SetProjectsDgv()
		{
			projectsDgv.Rows.Clear();
			projectsDgv.Columns.Clear();
			var bindingSource = new BindingSource();
			var allProjects = _projectService.GetAllProjects();
			bindingSource.DataSource = allProjects;

			projectsDgv.AutoGenerateColumns = false;
			projectsDgv.AutoSize = true;
			projectsDgv.DataSource = bindingSource;

			var nameColumn = new DataGridViewTextBoxColumn();
			nameColumn.DataPropertyName = nameof(ProjectModel.Name);
			nameColumn.Name = "Название";
			projectsDgv.Columns.Add(nameColumn);

			//var nameColumn1 = new DataGridViewTextBoxColumn();
			//nameColumn1.DataPropertyName = nameof(ProjectModel.Employees);
			//nameColumn1.Name = "Руководитель";
			//projectsDgv.Columns.Add(nameColumn1);

			DataGridViewColumn startDateColumn = new DataGridViewTextBoxColumn();
			startDateColumn.DataPropertyName = nameof(ProjectModel.StartDate);
			startDateColumn.Name = "Дата начала";
			projectsDgv.Columns.Add(startDateColumn);

			DataGridViewColumn endDateColumn = new DataGridViewTextBoxColumn();
			endDateColumn.DataPropertyName = nameof(ProjectModel.EndDate);
			endDateColumn.Name = "Дата конца";
			projectsDgv.Columns.Add(endDateColumn);
		}

		private void SetWorkersDgv()
		{
			WorkersdataGridView.Rows.Clear();
			WorkersdataGridView.Columns.Clear();

			var bindingSource = new BindingSource();
			var allEmployee = _employeeService.GetAllEmployee();
			bindingSource.DataSource = allEmployee;

			WorkersdataGridView.AutoGenerateColumns = false;
			WorkersdataGridView.AutoSize = true;
			WorkersdataGridView.DataSource = bindingSource;

			var nameColumn = new DataGridViewTextBoxColumn();
			nameColumn.DataPropertyName = nameof(EmployeeModel.Name);
			nameColumn.Name = "Имя";
			WorkersdataGridView.Columns.Add(nameColumn);

			var surnameColumns = new DataGridViewTextBoxColumn();
			surnameColumns.DataPropertyName = nameof(EmployeeModel.Surname);
			surnameColumns.Name = "Фамилия";
			WorkersdataGridView.Columns.Add(surnameColumns);

			var middleNameColumn = new DataGridViewTextBoxColumn();
			middleNameColumn.DataPropertyName = nameof(EmployeeModel.MiddleName);
			middleNameColumn.Name = "Отчество";
			WorkersdataGridView.Columns.Add(middleNameColumn);

			var loginColumn = new DataGridViewTextBoxColumn();
			loginColumn.DataPropertyName = nameof(EmployeeModel.Login);
			loginColumn.Name = "Логин";
			WorkersdataGridView.Columns.Add(loginColumn);
			var phoneColumn = new DataGridViewTextBoxColumn();
			phoneColumn.DataPropertyName = nameof(EmployeeModel.PhoneNumber);
			phoneColumn.Name = "Телефон";
			WorkersdataGridView.Columns.Add(phoneColumn);

		}

		private void SetTimeDgv()
		{
			employeeTasksDgv.Rows.Clear();
			employeeTasksDgv.Columns.Clear();
			var bindingSource = new BindingSource();
			var bindingSource1 = new BindingSource();
			var allTime = _timeService.GetAllTime();
			var allTasks = _taskService.GetAllTasks();
			bindingSource.DataSource = allTime;
			bindingSource1.DataSource = allTasks;

			employeeTasksDgv.AutoGenerateColumns = false;
			employeeTasksDgv.AutoSize = true;
			employeeTasksDgv.DataSource = bindingSource;
			{
				var IDnameColumn = new DataGridViewTextBoxColumn();
				IDnameColumn.DataPropertyName = nameof(TimeRecordModel.Id);
				IDnameColumn.Name = "ID";
				employeeTasksDgv.Columns.Add(IDnameColumn);

				var surnameColumns = new DataGridViewTextBoxColumn();
				surnameColumns.DataPropertyName = nameof(TimeRecordModel.StartDate);
				surnameColumns.Name = "Дата";
				employeeTasksDgv.Columns.Add(surnameColumns);

				var middleNameColumn = new DataGridViewTextBoxColumn();
				middleNameColumn.DataPropertyName = nameof(TimeRecordModel.DurationInMinutes);
				middleNameColumn.Name = "Продолжительность";
				employeeTasksDgv.Columns.Add(middleNameColumn);

				//var nameColumn = new DataGridViewTextBoxColumn();

				//nameColumn.DataPropertyName = nameof(TaskModel.Description);
				//nameColumn.Name = "Задача";
				//employeeTasksDgv.Columns.Add(nameColumn);

				var prnameColumn = new DataGridViewTextBoxColumn();

				prnameColumn.DataPropertyName = nameof(TimeRecordModel.Title);
				prnameColumn.Name = "Описание";
				employeeTasksDgv.Columns.Add(prnameColumn);
			}






		}

		private void InitializeUi()//все ограничения админ -1 разраб 2 дир 3 рук проект 4 
		{
			//if (_authenticatedUser.Role != UserInfo.UserRole.Leader)// роль 2
			//{
			//button2.Enabled = false;
			//button3.Enabled = false;
			//button4.Enabled = false;
			//button7.Enabled = false;
			//}
			//else if (_authenticatedUser.Role != UserInfo.UserRole.Leader)// роль 3
			//{
			//button2.Enabled = false;			button3.Enabled = true;				button4.Enabled = true;				button7.Enabled = true;

			//deleteProjectBtn.Enabled = false;				addProjectBtn.Enabled = false;				addEmployeeBtn.Enabled = false;
			//}
			//else if (_authenticatedUser.Role != UserInfo.UserRole.Leader)// роль 4
			//{
			//button2.Enabled = false;
			//button3.Enabled = false;
			//button4.Enabled = true;
			//button7.Enabled = false;

			//deleteProjectBtn.Enabled = false;
			//addProjectBtn.Enabled = false;
			//addEmployeeBtn.Enabled = false;
			//}

		}
		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label6_Click(object sender, EventArgs e)
		{

		}
		#region  --- Main Elements---
		private void button3_Click(object sender, EventArgs e)//Открытие панели работники 
		{

			// Именение шрифта:
			button3.Font = new Font(button3.Font, FontStyle.Bold);
			button1.Font = new Font(button1.Font, FontStyle.Regular);
			button2.Font = new Font(button1.Font, FontStyle.Regular);
			button4.Font = new Font(button4.Font, FontStyle.Regular);
			button7.Font = new Font(button7.Font, FontStyle.Regular);
			// Изменение панели:

			panelWorkers.Visible = true;
			MainPanel.Visible = false;
			panelProjects.Visible = false;
			panelDirectories.Visible = false;
			panelReports.Visible = false;
		}

		private void button1_Click(object sender, EventArgs e)//ввод времени 
		{
			// Именение шрифта:
			button1.Font = new Font(button1.Font, FontStyle.Bold);
			button3.Font = new Font(button3.Font, FontStyle.Regular);
			button4.Font = new Font(button4.Font, FontStyle.Regular);
			button7.Font = new Font(button7.Font, FontStyle.Regular);
			button2.Font = new Font(button1.Font, FontStyle.Regular);
			// Изменение панели:

			panelWorkers.Visible = false;
			panelProjects.Visible = false;
			panelDirectories.Visible = false;
			panelReports.Visible = false;
			MainPanel.Visible = false;
			MainPanel.Visible = true;

		}

		private void button4_Click(object sender, EventArgs e)// проект 
		{

			// Именение шрифта:
			button4.Font = new Font(button4.Font, FontStyle.Bold);
			button3.Font = new Font(button3.Font, FontStyle.Regular);
			button1.Font = new Font(button1.Font, FontStyle.Regular);
			button7.Font = new Font(button7.Font, FontStyle.Regular);
			button2.Font = new Font(button1.Font, FontStyle.Regular);
			// Изменение панели:

			panelWorkers.Visible = false;
			panelDirectories.Visible = false;
			panelReports.Visible = false;
			MainPanel.Visible = false;
			panelProjects.Visible = true;

		}

		private void button7_Click(object sender, EventArgs e)//отчет о работе 
		{
			// Именение шрифта:
			button7.Font = new Font(button4.Font, FontStyle.Bold);
			button3.Font = new Font(button3.Font, FontStyle.Regular);
			button1.Font = new Font(button1.Font, FontStyle.Regular);
			button4.Font = new Font(button7.Font, FontStyle.Regular);
			button2.Font = new Font(button1.Font, FontStyle.Regular);
			// Изменение панели:

			panelWorkers.Visible = false;
			MainPanel.Visible = false;
			panelProjects.Visible = false;
			panelDirectories.Visible = false;
			panelReports.Visible = true;

		}
		#endregion

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{


		}

		private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//_usersDataBase.SaveDataBase();
			//_projectsDataBase.SaveDataBase();
			//_workingDataBase.SaveDataBase();
		}



		public void ShowUserWorkingSessionsInfo()
		{/*
			dataGridView1.Rows.Clear();
			List<WorkingSessionInfo> workingSessionInfos = _workingDataBase.GetAll();
			foreach (var workingSession in workingSessionInfos)
			{
				if (workingSession.UserId != _authenticatedUser.Id)
					continue;

				ProjectInfo projectInfo = _projectsDataBase.GetProject(workingSession.ProjectId);
				string projectName = projectInfo.Name;
				DateTime workingSessionDate = workingSession.Date;
				string startWorkingDate = $"{workingSessionDate.Day}/{workingSessionDate.Month}/{workingSessionDate.Year}";
				DateTime workingSessionTime = workingSession.StartTime;
				string startWorkingSessionTime = $"{workingSessionTime.Hour}:{workingSessionTime.Minute}:{workingSessionTime.Second}";
				int workingsessionID = workingSession.Id;
				dataGridView1.Rows.Add(projectName, startWorkingDate, startWorkingSessionTime, workingSession.SpentWorkHours, workingSession.Aim, workingsessionID);
			}*/
		}

		public void ShowAllUsersWorkingSessionsInfo()
		{/*
			projectsDgv.Rows.Clear();
			List<WorkingSessionInfo> workingSessionInfos = _workingDataBase.GetAll();
			foreach (var workingSession in workingSessionInfos)
			{
				UserInfo userinfo = _usersDataBase.GetUser(workingSession.UserId);
				string userFio = userinfo.Fio;
				ProjectInfo projectInfo = _projectsDataBase.GetProject(workingSession.ProjectId);
				string projectName = projectInfo.Name;
				DateTime workingSessionDate = workingSession.Date;
				string startWorkingDate = $"{workingSessionDate.Day}/{workingSessionDate.Month}/{workingSessionDate.Year}";
				DateTime workingSessionTime = workingSession.StartTime;
				string startWorkingSessionTime = $"{workingSessionTime.Hour}:{workingSessionTime.Minute}:{workingSessionTime.Second}";
				projectsDgv.Rows.Add(userFio, projectName, startWorkingDate, startWorkingSessionTime, workingSession.SpentWorkHours);
			}*/
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		// Закрытие главного окна приложения
		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			//bool needToSaveChanges = _usersDataBase.DataBaseHasChanges() || _projectsDataBase.DataBaseHasChanges() || _workingDataBase.DataBaseHasChanges();
			//if (needToSaveChanges)
			//{
			//    var dialogResult = MessageBox.Show("Есть несохранённые изменения, сохранить изменения перед выходом?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			//    if (dialogResult == DialogResult.Yes)
			//    {
			//        _usersDataBase.SaveDataBase();
			//        _projectsDataBase.SaveDataBase();
			//        _workingDataBase.SaveDataBase();
			//    }
			//}
			Application.Exit();
		}

		private void fioLabel_Click(object sender, EventArgs e)
		{

		}

		private void Rolelabel_Click(object sender, EventArgs e)
		{

		}

		private void comboBox1_Click(object sender, EventArgs e)
		{
			var comboBox = sender as ComboBox;
			var allProjects = _projectService.GetAllProjects();
			comboBox.ValueMember = nameof(ProjectModel.Id);
			comboBox.DisplayMember = nameof(ProjectModel.Name);
			comboBox.DataSource = allProjects;

		}

		private void AddWorkingSessionProcess()
		{
			bool notAllInfoInputed = (textBox1.Text == string.Empty || (comboBox1.Text == string.Empty && comboBox2.Text == string.Empty) || comboBox3.Text == string.Empty);

			if (notAllInfoInputed)
			{
				MessageBox.Show("Необходимо заполнить все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var description = textBox1.Text;
			var project = this.comboBox1.SelectedItem as ProjectModel;
			var task = this.comboBox2.SelectedItem as TaskModel;
			var activity = this.comboBox3.SelectedItem as ActivityModel;
			var date = dateTimePicker1.Value;
			var time = dateTimePicker2.Value;
			var duration = Convert.ToInt32(numericUpDown1.Value);

			_timeService.AddTime(description, task.Id, activity.Id, date, time, duration);
			SetTimeDgv();

			MessageBox.Show("Сеанс успешно добавлен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
			textBox1.Clear();
			ShowUserWorkingSessionsInfo();
		}

		private void addWorkingSessionBt_Click(object sender, EventArgs e)//добавление записи о времени
		{
			AddWorkingSessionProcess();
			ShowUserWorkingSessionsInfo();
			ShowAllUsersWorkingSessionsInfo();
			comboBox1.SelectedIndex = -1;
		}

		private void DeleteSessionbutton_Click(object sender, EventArgs e)
		{

			var id = Convert.ToInt32(NumRowTB.Text);
			if (id <= 100)
			{
				_timeService.DeleteTime(id);
				NumRowTB.Clear();
			}
			else
				MessageBox.Show("Error");
		}


		private void ProjcomboBox_Click(object sender, EventArgs e)
		{
			var comboBox = sender as ComboBox;
			var allPro = _projectService.GetAllProjects();
			comboBox.ValueMember = nameof(ProjectModel.Id);
			comboBox.DisplayMember = nameof(ProjectModel.Name);
			comboBox.DataSource = allPro;
		}

		private void button14_Click(object sender, EventArgs e)//добавление сотрудника
		{
			AddUserForm addUserForm = new AddUserForm();
			addUserForm.ShowDialog();
			WorkersdataGridView.Rows.Clear();
			WorkersdataGridView.Columns.Clear();
			SetWorkersDgv();
		}

		private void button9_Click(object sender, EventArgs e)
		{
			var addUserProForm = new AddUsersPro();
			addUserProForm.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			// Именение шрифта:
			button2.Font = new Font(button4.Font, FontStyle.Bold);
			button3.Font = new Font(button3.Font, FontStyle.Regular);
			button1.Font = new Font(button1.Font, FontStyle.Regular);
			button7.Font = new Font(button7.Font, FontStyle.Regular);
			button4.Font = new Font(button1.Font, FontStyle.Regular);
			// Изменение панели:
			//panelReports.Visible = false;
			//panelWorkers.Visible = false;
			//MainPanel.Visible = false;
			//panelProjects.Visible = false;
			panelDirectories.Visible = true;
		}

		private void addDepartmentBtn_Click(object sender, EventArgs e)
		{
			var addDepartmentForm = new AddDepartmentForm();
			addDepartmentForm.ShowDialog();
		}

		private void button15_Click(object sender, EventArgs e)
		{
			Курсовая.AddJobForm addJobForm = new Курсовая.AddJobForm();
			addJobForm.Show();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			Курсовая.AddRoleForm addRoleForm = new Курсовая.AddRoleForm();
			addRoleForm.Show();
		}

		private void button16_Click(object sender, EventArgs e)
		{
			Курсовая.AddTypeOfActivity addTypeOfActivity = new Курсовая.AddTypeOfActivity();
			addTypeOfActivity.Show();
		}

		private void deleteProjectBtn_Click(object sender, EventArgs e)
		{
			var projectDelete = new ProjectDelete();
			projectDelete.ShowDialog();
			SetProjectsDgv();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			ProjectManagerCore.ProjectEdit progectEdit = new ProjectManagerCore.ProjectEdit();
			progectEdit.Show();
		}

		private void addProjBtn_Click(object sender, EventArgs e)//добавление проекта
		{
			var projectName = this.projectNameTB.Text;
			var projectStartDate = this.projectStartDateDTP.Value;
			var projectEndDate = this.projectEndDateDTP.Value;
			var projectLeader = this.projectLeadCB.SelectedItem as EmployeeModel;
			var projectType = this.projectTypeCbElement.SelectedItem as ProjectTypeModel;
			_employeeProjectService.AddProjectWithLeader(projectName, projectStartDate, projectEndDate, projectLeader.Id, projectType.Id);
			projectsDgv.Rows.Clear();
			projectsDgv.Columns.Clear();
			SetProjectsDgv();
			projectNameTB.Clear();


		}

		private void projectsDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void button11_Click(object sender, EventArgs e)//задачи проекта
		{
			AddTaskForm addtask = new AddTaskForm();
			addtask.Show();
		}

		private void projectLeadCB_Click(object sender, EventArgs e)
		{
			var comboBox = sender as ComboBox;
			var allEmployees = _employeeService.GetAllEmployee();
			comboBox.ValueMember = nameof(EmployeeModel.Id);
			comboBox.DisplayMember = nameof(EmployeeModel.Name);
			comboBox.DataSource = allEmployees;
		}

		private void comboBox2_Click(object sender, EventArgs e)//выбор задачи
		{

			var comboBox = sender as ComboBox;
			var allProjectTasks = _taskService.GetAllTasks();
			comboBox.ValueMember = nameof(TaskModel.Id);

			comboBox.DisplayMember = nameof(TaskModel.Description);
			comboBox.DataSource = allProjectTasks;

		}

		private void projectLeadCB_Click(object sender, MouseEventArgs e)
		{
			var comboBox = sender as ComboBox;
			var allEmployees = _employeeService.GetAllEmployee();
			comboBox.ValueMember = nameof(EmployeeModel.Id);
			comboBox.DisplayMember = nameof(EmployeeModel.Name);
			comboBox.DataSource = allEmployees;
		}

		private void button9_Click_1(object sender, EventArgs e)//сотрудники-депаартаменты
		{
			DepartmentJobConnect addDepJob = new DepartmentJobConnect();
			addDepJob.Show();
		}

		private void comboBox3_Click(object sender, EventArgs e)
		{
			var comboBox = sender as ComboBox;
			var allActivities = _activityService.GetAllActivities();
			comboBox.ValueMember = nameof(ActivityModel.Id);
			comboBox.DisplayMember = nameof(ActivityModel.Description);
			comboBox.DataSource = allActivities;
		}

		private void MainPanel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void label10_Click(object sender, EventArgs e)
		{

		}

		private void comboBox4_Click(object sender, EventArgs e)//тип проекта
		{
			var comboBox = sender as ComboBox;
			var allTypes = _projectTypeService.GetAllTypes();
			comboBox.ValueMember = nameof(ProjectTypeModel.Id);
			comboBox.DisplayMember = nameof(ProjectTypeModel.Name);
			comboBox.DataSource = allTypes;
		}

		private void panelDirectories_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button10_Click_1(object sender, EventArgs e)//тип проекта
		{
			ProjectManagerCore.AddProjectType addPrTypeForm = new ProjectManagerCore.AddProjectType();
			addPrTypeForm.Show();
		}

		private void NumRowTB_Validating(object sender, CancelEventArgs e)
		{

		}

		private void button11_Click_1(object sender, EventArgs e)
		{

			projectsDgv.Rows.Clear();
			projectsDgv.Columns.Clear();
			SetProjectsDgv();
		}

		private void createUtilReportBtn_Click(object sender, EventArgs e)
		{
			PrintReviewUtil();
		}

		public void PrintReviewUtil()
		{
			var bindingSource = new BindingSource();
			var utilizationReport = _utilizationReportService.GetUtilizationReport();
			bindingSource.DataSource = utilizationReport;
			var columnCount = utilizationDgv.ColumnCount;
			utilizationDgv.DataSource = bindingSource;
			if (columnCount != 0)
				return;


			utilizationDgv.AutoGenerateColumns = false;
			utilizationDgv.AutoSize = true;

			var nameColumn = new DataGridViewTextBoxColumn();
			nameColumn.DataPropertyName = nameof(UtilizationReport.EmployeeName);
			nameColumn.Name = "Имя";
			utilizationDgv.Columns.Add(nameColumn);

			var surnameColumns = new DataGridViewTextBoxColumn();
			surnameColumns.DataPropertyName = nameof(UtilizationReport.EmployeeSurname);
			surnameColumns.Name = "Фамилия";
			utilizationDgv.Columns.Add(surnameColumns);

			var middleNameColumn = new DataGridViewTextBoxColumn();
			middleNameColumn.DataPropertyName = nameof(UtilizationReport.EmployeeMiddleName);
			middleNameColumn.Name = "Отчество";
			utilizationDgv.Columns.Add(middleNameColumn);

			var utilValue = new DataGridViewTextBoxColumn();
			utilValue.DataPropertyName = nameof(UtilizationReport.UtilizationValue);
			utilValue.Name = "Утилизация";
			utilizationDgv.Columns.Add(utilValue);
		}

		private void button6_Click(object sender, EventArgs e)//отчет по выручке на проекте
		{
			bool notAllInfoInputed = (ProjectsComboBox.Text == string.Empty);

			if (notAllInfoInputed)
			{
				MessageBox.Show("Необходимо заполнить все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			// название проекта + размер выручки (сумма ставок на нем) 


			MessageBox.Show("Отчет создан");
			PrintReviewMoney();
		}
		public void PrintReviewMoney()
		{

			//dataGridView3.Rows[1].Cells[1].Value = "Проект";
			//dataGridView3.Rows[2].Cells[1].Value = "11700";

			//var surnameColumns = new DataGridViewTextBoxColumn();
			//surnameColumns.DataPropertyName = "Проект 1";
			//surnameColumns.Name = "Проект";
			//dataGridView3.Columns.Add(surnameColumns);

			//var middleNameColumn = new DataGridViewTextBoxColumn();
			//middleNameColumn.DataPropertyName = "11700";
			//middleNameColumn.Name = "Выручка";
			//dataGridView3.Columns.Add(middleNameColumn);



			//собрать все ставки и сложить 
		}
		private void applyFilterButton_Click(object sender, EventArgs e)//выгрузка отчетов в эксель
		{
			var fileName = $"UtilizationReport.csv";
			var utilizationReport = _utilizationReportService.GetUtilizationReport();
			SaveToCSV(utilizationReport, fileName);
			MessageBox.Show("Отчет загружен на компьютер");
		}

		public void SaveToCSV(List<UtilizationReport> data, string fileName)
		{
			string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
			CsvConfiguration csvConfiguration = new CsvConfiguration(CultureInfo.CurrentCulture)
			{
				Delimiter = ",",
				HasHeaderRecord = true,
				LeaveOpen = false,
				IncludePrivateMembers = true,
				Encoding = Encoding.Default 
			};

			using (var writer = new StreamWriter(destPath))
			using (var csvWriter = new CsvWriter(writer, csvConfiguration))
			{
				writer.WriteLine("sep=,");
				csvWriter.WriteHeader<UtilizationReport>();
				csvWriter.NextRecord();
				csvWriter.WriteRecords(data);
				writer.Flush();
			}
		}

		private void createUtilReportBtn_Click_1(object sender, EventArgs e)
		{
			PrintReviewUtil();
		}

		private void button18_Click(object sender, EventArgs e)
		{
			Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
			// creating new WorkBook within Excel application  
			Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
			// creating new Excelsheet in workbook  
			Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
			// see the excel sheet behind the program  
			app.Visible = true;
			// get the reference of first sheet. By default its name is Sheet1.  
			// store its reference to worksheet  
			worksheet = (NsExcel._Worksheet)workbook.Sheets["Sheet1"];
			worksheet = (NsExcel._Worksheet)workbook.ActiveSheet;
			// changing the name of active sheet  
			worksheet.Name = "Exported from gridview";
			// storing header part in Excel  
			for (int i = 1; i < utilizationDgv.Columns.Count + 1; i++)
			{
				worksheet.Cells[1, i] = utilizationDgv.Columns[i - 1].HeaderText;
			}
			// storing Each row and column value to excel sheet  
			for (int i = 0; i < utilizationDgv.Rows.Count - 1; i++)
			{
				for (int j = 0; j < utilizationDgv.Columns.Count; j++)
				{
					worksheet.Cells[i + 2, j + 1] = utilizationDgv.Rows[i].Cells[j].Value.ToString();
				}
			}
			// save the application  
			workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
			// Exit from the application  
			app.Quit();
		}

		public void ListToExcel(List<string> list)
		{
		}

		private void panelWorkers_Paint(object sender, PaintEventArgs e)
		{

		}

		private void projectTypeCbElement_Click(object sender, EventArgs e)
		{
			var comboBox = sender as ComboBox;
			var allPro = _projectTypeService.GetAllTypes();
			comboBox.ValueMember = nameof(ProjectTypeModel.Id);
			comboBox.DisplayMember = nameof(ProjectTypeModel.Name);
			comboBox.DataSource = allPro;
		}

		private void projectTypeCbElement_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
