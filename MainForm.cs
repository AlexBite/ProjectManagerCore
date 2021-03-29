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

namespace WorkingTimeTracker
{
    [Serializable]

    public partial class MainForm : Form
    {
        private readonly EmployeeModel _employeeModel;
        private readonly IProjectService _projectService;
        private readonly IEmployeeService _employeeService;


        private readonly UsersDataBase _usersDataBase;
        private readonly UserInfo _authenricatedUser;
        private readonly ProjectsDataBase _projectsDataBase;
        private readonly WorkingDataBase _workingDataBase;

		public MainForm(EmployeeModel employeeModel)
		//public MainForm(UsersDataBase usersDataBase, UserInfo authenricatedUser,
		//ProjectsDataBase projectsDataBase, WorkingDataBase workingDataBase)
		{
            _employeeModel = employeeModel;
            _projectService = new ProjectService();
            //_usersDataBase = usersDataBase;
            //_authenricatedUser = authenricatedUser;
            //_projectsDataBase = projectsDataBase;
            //_workingDataBase = workingDataBase;


            //panelReports.Visible = false;
            //fioLabel.Text = _authenricatedUser.Fio;
            //InitializeUi();
            //ShowUserWorkingSessionsInfo();
            //ShowAllUsersWorkingSessionsInfo();
            InitializeComponent();
            SetNameLabel();
            SetProjectsDgv();
            SetWorkersDgv();
            MainPanel.Visible = true;
            //if (UserRole == 1)
            //{

            //}
        }

        private void SetNameLabel()
		{
            fioLabel.Text = $"{_employeeModel.Surname} {_employeeModel.Name} {_employeeModel.MiddleName}";
		}

        private void SetProjectsDgv()
		{
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
            var bindingSource1 = new BindingSource();
            var allEmployee = _employeeService.GetAllEmployee();
            bindingSource1.DataSource = allEmployee;

            WorkersdataGridView.AutoGenerateColumns = false;
            WorkersdataGridView.AutoSize = true;
            WorkersdataGridView.DataSource = bindingSource1;

            var nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = nameof(EmployeeModel.Name);
            nameColumn.Name = "Имя";
            WorkersdataGridView.Columns.Add(nameColumn);
            
            var nameColumn1 = new DataGridViewTextBoxColumn();
            nameColumn1.DataPropertyName = nameof(EmployeeModel.Surname);
            nameColumn1.Name = "Фамилия";
            WorkersdataGridView.Columns.Add(nameColumn1);
            
            var nameColumn2 = new DataGridViewTextBoxColumn();
            nameColumn2.DataPropertyName = nameof(EmployeeModel.MiddleName);
            nameColumn2.Name = "Отчество";
            WorkersdataGridView.Columns.Add(nameColumn2);

            DataGridViewColumn JobColumn = new DataGridViewTextBoxColumn();
            JobColumn.DataPropertyName = nameof(EmployeeDepartmentModel.Position);
            JobColumn.Name = "Должность";
            WorkersdataGridView.Columns.Add(JobColumn);

            DataGridViewColumn DepartmentColumn = new DataGridViewTextBoxColumn();
            DepartmentColumn.DataPropertyName = nameof(EmployeeDepartmentModel.Department);
            DepartmentColumn.Name = "Департамент";
            WorkersdataGridView.Columns.Add(DepartmentColumn);

            DataGridViewColumn startDateColumn = new DataGridViewTextBoxColumn();
            startDateColumn.DataPropertyName = nameof(EmployeeDepartmentModel.StartWorkingDate);
            startDateColumn.Name = "Дата начала работы";
            WorkersdataGridView.Columns.Add(startDateColumn);

            DataGridViewColumn endDateColumn = new DataGridViewTextBoxColumn();
            endDateColumn.DataPropertyName = nameof(EmployeeDepartmentModel.EndWorkingDate);
            endDateColumn.Name = "Дата окончания работы";
            WorkersdataGridView.Columns.Add(endDateColumn);
        }

        private void SetTimeDgv()
        {
            var bindingSource2 = new BindingSource();
            var allTime = _employeeService.GetAllEmployee();
            bindingSource1.DataSource = allEmployee;

            WorkersdataGridView.AutoGenerateColumns = false;
            WorkersdataGridView.AutoSize = true;
            WorkersdataGridView.DataSource = bindingSource;

            var nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = nameof(EmployeeModel.Name);
            nameColumn.Name = "Проект";
            WorkersdataGridView.Columns.Add(nameColumn);

            var nameColumn1 = new DataGridViewTextBoxColumn();
            nameColumn1.DataPropertyName = nameof(EmployeeModel.Surname);
            nameColumn1.Name = "Дата";
            WorkersdataGridView.Columns.Add(nameColumn1);

            var nameColumn2 = new DataGridViewTextBoxColumn();
            nameColumn2.DataPropertyName = nameof(EmployeeModel.MiddleName);
            nameColumn2.Name = "Продолжительность";
            WorkersdataGridView.Columns.Add(nameColumn2);

            DataGridViewColumn JobColumn = new DataGridViewTextBoxColumn();
            JobColumn.DataPropertyName = nameof(EmployeeDepartmentModel.Position);
            JobColumn.Name = "Должность";
            WorkersdataGridView.Columns.Add(JobColumn);

            DataGridViewColumn DepartmentColumn = new DataGridViewTextBoxColumn();
            DepartmentColumn.DataPropertyName = nameof(EmployeeDepartmentModel.Department);
            DepartmentColumn.Name = "Департамент";
            WorkersdataGridView.Columns.Add(DepartmentColumn);

            DataGridViewColumn startDateColumn = new DataGridViewTextBoxColumn();
            startDateColumn.DataPropertyName = nameof(EmployeeDepartmentModel.StartWorkingDate);
            startDateColumn.Name = "дата начала работы";
            WorkersdataGridView.Columns.Add(startDateColumn);

            DataGridViewColumn endDateColumn = new DataGridViewTextBoxColumn();
            endDateColumn.DataPropertyName = nameof(EmployeeDepartmentModel.EndWorkingDate);
            endDateColumn.Name = "Дата окончания работы";
            WorkersdataGridView.Columns.Add(endDateColumn);
        }
        private void InitializeUi()//все ограничения админ -1 разраб 2 дир 3 рук проект 4 
        { 
            if (_authenricatedUser.Role != UserInfo.UserRole.Leader)// роль 2
            {
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button7.Enabled = false;              
            }
            else
            if(_authenricatedUser.Role != UserInfo.UserRole.Leader)// роль 3
            {
                button2.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = true;
                button7.Enabled = true;

                button13.Enabled = false;
                button12.Enabled = false;
                button14.Enabled = false;
            }
            if (_authenricatedUser.Role != UserInfo.UserRole.Leader)// роль 4
            {
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = true;
                button7.Enabled = false;

                button13.Enabled = false;
                button12.Enabled = false;
                button14.Enabled = false;
            }

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

            //panelWorkers.Visible = false;
            //panelProjects.Visible = false;
            //panelDirectories.Visible = false;
            //panelReports.Visible = false;
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
            _usersDataBase.SaveDataBase();
            _projectsDataBase.SaveDataBase();
            _workingDataBase.SaveDataBase();
        }



        public void ShowUserWorkingSessionsInfo()
        {
            dataGridView1.Rows.Clear();
            List<WorkingSessionInfo> workingSessionInfos = _workingDataBase.GetAll();
            foreach (var workingSession in workingSessionInfos)
            {
                if (workingSession.UserId != _authenricatedUser.Id)
                    continue;

                ProjectInfo projectInfo = _projectsDataBase.GetProject(workingSession.ProjectId);
                string projectName = projectInfo.Name;
                DateTime workingSessionDate = workingSession.Date;
                string startWorkingDate = $"{workingSessionDate.Day}/{workingSessionDate.Month}/{workingSessionDate.Year}";
                DateTime workingSessionTime = workingSession.StartTime;
                string startWorkingSessionTime = $"{workingSessionTime.Hour}:{workingSessionTime.Minute}:{workingSessionTime.Second}";
                int workingsessionID = workingSession.Id;
                dataGridView1.Rows.Add(projectName, startWorkingDate, startWorkingSessionTime, workingSession.SpentWorkHours, workingSession.Aim, workingsessionID);
            }
        }

        public void ShowAllUsersWorkingSessionsInfo()
        {
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
            }
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
            comboBox1.Items.Clear();
            var projectNames = _projectsDataBase.GetNamesOfProjects();
            foreach (var projectName in projectNames)
            {
                if (projectName != null)
                {
                    comboBox1.Items.Add(projectName);
                }
            }
        }

        private void AddWorkingSessionProcess()
        {
            bool notAllInfoInputed = textBox1.Text == string.Empty || comboBox1.Text == string.Empty;

            if (notAllInfoInputed)
            {
                MessageBox.Show("Необходимо заполнить все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newAim = textBox1.Text;
            int newSpentHours = Int32.Parse(numericUpDown1.Text);
            DateTime newStartTime = dateTimePicker2.Value;
            DateTime newDate = dateTimePicker1.Value;
            int userId = _authenricatedUser.Id;
            string projectName = comboBox1.Text;

            ProjectInfo projectInfo = _projectsDataBase.GetProjectByName(projectName);


            WorkingSessionInfo newWS = new WorkingSessionInfo()
            {
                Aim = newAim,
                SpentWorkHours = newSpentHours,
                StartTime = newStartTime,
                Date = newDate,
                UserId = userId,
                ProjectId = projectInfo.Id
            };

            _workingDataBase.AddWS(newWS);

            MessageBox.Show("Сеанс успешно добавлен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Clear();
            ShowUserWorkingSessionsInfo();
            //numericUpDown1.Clear();
            //comboBox1.Clear();

        }

        private void addWorkingSessionBt_Click(object sender, EventArgs e)
        {
            AddWorkingSessionProcess();
            ShowUserWorkingSessionsInfo();
            ShowAllUsersWorkingSessionsInfo();
            comboBox1.SelectedIndex = -1;

        }

        private void deleteSession()
        {
            int deletedRow = Int32.Parse(NumRowTB.Text) - 1;
            int deletedWSId;

            try
            {
                if (dataGridView1.RowCount <= deletedRow || deletedRow == -1)
                {
                    MessageBox.Show("Удаление невозможно");
                }
                else
                {
                    object WSidobj = dataGridView1.Rows[deletedRow].Cells[5].Value;
                    deletedWSId = Convert.ToInt32(WSidobj);
                    //dataGridView1.Rows.RemoveAt(deletedRow);
                    //dataGridView1.Refresh();
                    _workingDataBase.DeleteWS(deletedWSId);
                    ShowUserWorkingSessionsInfo();
                    NumRowTB.Clear();
                    ShowAllUsersWorkingSessionsInfo();
                }


            }
            catch (InvalidOperationException)
            { }
        }
        private void DeleteSessionbutton_Click(object sender, EventArgs e)
        {
            deleteSession();
            NumRowTB.Clear();
        }

        private void applyFilterButton_Click(object sender, EventArgs e)
        {
            
        }

        private void HighliteByProject(string projectName, out bool evenOneDataSatisfy)
        {
            evenOneDataSatisfy = false;
            foreach (DataGridViewRow row in projectsDgv.Rows)
            {
                string projectNameFromGrid = row.Cells[1].Value.ToString();
                bool isDataSatisfy = projectNameFromGrid == projectName;

                if (isDataSatisfy)
                {
                    evenOneDataSatisfy = true;
                    HighliteRow(row.Index);
                }
            }
        }

        private void HighliteByUser(string userName, out bool evenOneDataSatisfy)
        {
            evenOneDataSatisfy = false;
            foreach (DataGridViewRow row in projectsDgv.Rows)
            {
                string userNameFromGrid = row.Cells[0].Value.ToString();
                bool isDataSatisfy = userNameFromGrid == userName;

                if (isDataSatisfy)
                {
                    evenOneDataSatisfy = true;
                    HighliteRow(row.Index);
                }
            }
        }

        private void HighliteByUserAndProject(string userName, string projectName, out bool evenOneDataSatisfy)
        {
            evenOneDataSatisfy = false;
            foreach (DataGridViewRow row in projectsDgv.Rows)
            {
                string userNameFromGrid = row.Cells[0].Value.ToString();
                string projectNameFromGrid = row.Cells[1].Value.ToString();

                bool isDataSatisfy = userNameFromGrid == userName && projectNameFromGrid == projectName;

                if (isDataSatisfy)
                {
                    evenOneDataSatisfy = true;
                    HighliteRow(row.Index);
                }
            }
        }

        private void HighliteRow(int rowNum)
        {
            projectsDgv.Rows[rowNum].DefaultCellStyle.BackColor = Color.MediumTurquoise;
        }

        private void UserscomboBox_Click(object sender, EventArgs e)
        {
            
        }


        private void ProjcomboBox_Click(object sender, EventArgs e)
        {
            ProjectsComboBox.Items.Clear();
            var projectNames = _projectsDataBase.GetNamesOfProjects();
            foreach (var projectName in projectNames)
            {
                if (projectName != null)
                {
                    ProjectsComboBox.Items.Add(projectName);
                }
            }
        }

        private void ClearFilterbutton_Click(object sender, EventArgs e)
        {
            ShowAllUsersWorkingSessionsInfo();
            //UsersComboBox.SelectedIndex = -1;
            //ProjectsComboBox.SelectedIndex = -1;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)//добавление сотрудника
        {
            
            AddUserForm addUserForm = new AddUserForm();
            addUserForm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Курсовая.AddUsersPro addUserProForm = new Курсовая.AddUsersPro();
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

        private void button17_Click(object sender, EventArgs e)
        {
            Курсовая.AddDepartmentForm addDepartmentForm = new Курсовая.AddDepartmentForm();
            addDepartmentForm.Show();
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

        private void button13_Click(object sender, EventArgs e)
        {
            Курсовая.ProjectDelete projectDelete = new Курсовая.ProjectDelete();
            projectDelete.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Курсовая.ProgectEdit progectEdit = new Курсовая.ProgectEdit();
            //progectEdit.Show();
        }

		private void addProjBtn_Click(object sender, EventArgs e)//добавление проекта
		{

		}

        private void projectsDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)//задачи проекта
        {
            AddTaskForm addtask = new AddTaskForm();
            addtask.Show();
        }
    }
}
