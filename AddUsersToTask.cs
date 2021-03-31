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
            bool notAllInfoInputed = (comboBox1.Text == string.Empty || comboBox2.Text == string.Empty );

            if (notAllInfoInputed)
            {
                MessageBox.Show("Необходимо заполнить все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PrRegistrationProcess();
            SetTasksDgv();
        }
        private void PrRegistrationProcess()//
        {
            var employee = this.comboBox1.SelectedItem as EmployeeModel;
            var task = this.comboBox2.SelectedItem as TaskModel;
            //var rate = Convert.ToDouble(this.rateTb.Text);
            _employeetaskService.AddTaskEmpoyee(task.Id, employee.Id);            

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
            nameColumn.DataPropertyName = nameof(EmployeeTaskModel.Task);
            nameColumn.Name = "Задача";
            dataGridView1.Columns.Add(nameColumn);

            DataGridViewColumn startDateColumn = new DataGridViewTextBoxColumn();
            startDateColumn.DataPropertyName = nameof(EmployeeTaskModel.Employee);
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
