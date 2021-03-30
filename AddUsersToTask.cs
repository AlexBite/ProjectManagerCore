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
    public partial class AddUsersToTask : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly ITaskService _taskService;
        private readonly IEmployeeTaskService _employeetaskService;
        public AddUsersToTask()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _taskService = new TaskService();
            _employeetaskService = new EmployeeTaskService();
            SetTasksDgv();
        }

        private void button1_Click(object sender, EventArgs e)// добавить задачу
        {
            PrRegistrationProcess();
        }
        private void PrRegistrationProcess()//
        {
            var employee = this.comboBox1.SelectedItem as EmployeeModel;
            //var prName = this.PrOnTaskcombo.Text;
            var taskName = this.comboBox2.SelectedItem as TaskModel;
            //var taskStartDate = this.StartTaskDateTimePicker.Value;
            //var taskEndDate = this.EndTaskDateTimePicker.Value;
            //int taskNameInt = Convert.ToInt32(taskName);
            //int employeeInt = Convert.ToInt32(employee);// ошибка
            _employeetaskService.AddTaskEmpoyee(taskName.Id, employee.Id);

            this.Close();

        }
        private void comboBox2_Click(object sender, EventArgs e)// кб задачи
        {
            var comboBox = sender as ComboBox;
            var allTasks = _taskService.GetAllTasks();
            comboBox.ValueMember = nameof(TaskModel.Id);
            comboBox.DisplayMember = nameof(TaskModel.Description);
            comboBox.DataSource = allTasks;
        }

        private void comboBox1_Click(object sender, EventArgs e)// кб сотрудника
        {
            var comboBox = sender as ComboBox;
            var allEmployees = _employeeService.GetAllEmployee();
            comboBox.ValueMember = nameof(EmployeeModel.Id);
            comboBox.DisplayMember = nameof(EmployeeModel.Name );
            comboBox.DataSource = allEmployees;
        }
        private void SetTasksDgv()
        {
            var bindingSource = new BindingSource();
            var allTasks = _taskService.GetAllTasks();
            bindingSource.DataSource = allTasks;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.ScrollBars = ScrollBars.Both;

            var nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = nameof(TaskModel.Description);
            nameColumn.Name = "Задача";
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
    }
}
