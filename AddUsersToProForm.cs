using ProjectManagerCore.Models;
using ProjectManagerCore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private readonly ITaskService _taskService;
        public AddUsersPro()
        {
            InitializeComponent();
            SetProjectsDgv();
            _projectService = new ProjectService();
            _taskService = new TaskService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUsersProPosess();
        }

        private void AddUsersProPosess ()
        {

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
            var allProjects = _projectService.GetAllProjects();
            bindingSource.DataSource = allProjects;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.ScrollBars = ScrollBars.Both;

            var nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = nameof(ProjectModel.Name);
            nameColumn.Name = "Название проекта";
            dataGridView1.Columns.Add(nameColumn);

            DataGridViewColumn startDateColumn = new DataGridViewTextBoxColumn();
            startDateColumn.DataPropertyName = nameof(EmployeeModel.Surname);
            startDateColumn.Name = "Фамилия";
            dataGridView1.Columns.Add(startDateColumn);

            DataGridViewColumn endDateColumn = new DataGridViewTextBoxColumn();
            endDateColumn.DataPropertyName = nameof(EmployeeModel.Name);
            endDateColumn.Name = "Имя";
            dataGridView1.Columns.Add(endDateColumn);
            
            DataGridViewColumn endDate1Column = new DataGridViewTextBoxColumn();
            endDate1Column.DataPropertyName = nameof(EmployeeModel.MiddleName);
            endDate1Column.Name = "Отчество";
            dataGridView1.Columns.Add(endDate1Column);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
