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

namespace WorkingTimeTracker
{
    [Serializable]

    public partial class MainForm : Form
    {
        private readonly EmployeeModel _employeeModel;

        private readonly UsersDataBase _usersDataBase;
        private readonly UserInfo _authenricatedUser;
        private readonly ProjectsDataBase _projectsDataBase;
        private readonly WorkingDataBase _workingDataBase;

		public MainForm(EmployeeModel employeeModel)
		//public MainForm(UsersDataBase usersDataBase, UserInfo authenricatedUser,
		//ProjectsDataBase projectsDataBase, WorkingDataBase workingDataBase)
		{
            _employeeModel = employeeModel;
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
            MainPanel.Visible = true;
        }

        private void SetNameLabel()
		{
            fioLabel.Text = $"{_employeeModel.Surname} {_employeeModel.Name} {_employeeModel.MiddleName}";
		}

		private void InitializeUi()
        { 
            if (_authenricatedUser.Role != UserInfo.UserRole.Leader)
            {
                button3.Enabled = false;
                button4.Enabled = false;
                button7.Enabled = false;
              
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
            //MainPanel.Visible = false;
            //panelProjects.Visible = false;
            //panelDirectories.Visible = false;
            //panelReports.Visible = false;
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

            
            MainPanel.Visible = true;            
            //panelWorkers.Visible = false;           
            //panelProjects.Visible = false;
            //panelDirectories.Visible = false;
            //panelReports.Visible = false;

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
            
            //panelWorkers.Visible = false;
            //panelDirectories.Visible = false;
            //panelReports.Visible = false;
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
            dataGridView2.Rows.Clear();
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
                dataGridView2.Rows.Add(userFio, projectName, startWorkingDate, startWorkingSessionTime, workingSession.SpentWorkHours);
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
            //bool mathesExist = false;
            //string userName = UsersComboBox.Text;
            //string projectName = ProjectsComboBox.Text;

            //foreach (DataGridViewRow row in dataGridView2.Rows)
            //{
            //    row.DefaultCellStyle.BackColor = Color.White;
            //}

            //bool searchProjectsAndUsers = projectName != string.Empty && userName != string.Empty;
            //if (searchProjectsAndUsers)
            //{
            //    HighliteByUserAndProject(userName, projectName, out mathesExist);
            //}

            //bool searchUsersOnly = projectName == string.Empty && userName != string.Empty;
            //if (searchUsersOnly)
            //{
            //    HighliteByUser(userName, out mathesExist);
            //}

            //bool searchProjectsOnly = projectName != string.Empty && userName == string.Empty;
            //if (searchProjectsOnly)
            //{
            //    HighliteByProject(projectName, out mathesExist);
            //}

            //if (!mathesExist)
            //{
            //    MessageBox.Show("По данному запросу ничего не найдено.");
            //}
        }

        private void HighliteByProject(string projectName, out bool evenOneDataSatisfy)
        {
            evenOneDataSatisfy = false;
            foreach (DataGridViewRow row in dataGridView2.Rows)
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
            foreach (DataGridViewRow row in dataGridView2.Rows)
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
            foreach (DataGridViewRow row in dataGridView2.Rows)
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
            dataGridView2.Rows[rowNum].DefaultCellStyle.BackColor = Color.MediumTurquoise;
        }

        private void UserscomboBox_Click(object sender, EventArgs e)
        {
            //UsersComboBox.Items.Clear();
            //var usersNames = _usersDataBase.GetNamesOfUsers();
            //foreach (var user in usersNames)
            //{
            //    if (user != null)
            //    {
            //        UsersComboBox.Items.Add(user);
            //    }
            //}
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
            //AddUsersPro addUserProForm = new AddUsersToProForm();
            //addUserProForm.Show();
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
    }
}
