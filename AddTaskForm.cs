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

namespace WorkingTimeTracker
{
	[Serializable]
	public partial class AddTaskForm : Form
    {
		private readonly ProjectsDataBase _projectsDataBase;
        private readonly IProjectService _projectService;
        private readonly ITaskService _taskService;

        public AddTaskForm()
			//public AddTaskForm(ProjectsDataBase projectsDataBase)
		{
            InitializeComponent();
            _projectService = new ProjectService();
            _taskService = new TaskService();
            //_projectsDataBase = projectsDataBase;
            SetProjectsDgv();

        }
		
		private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void PrAddButton_Click(object sender, EventArgs e)//добавить задачу
        {
            bool notAllInfoInputed = (PrOnTaskcombo.Text == string.Empty|| TaskNameBox.Text == string.Empty || TaskNameBox.Text == string.Empty);

            if (notAllInfoInputed)
            {
                MessageBox.Show("Необходимо заполнить все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PrRegistrationProcess();
        }

		private void PrRegistrationProcess()//
		{
            var prName = this.PrOnTaskcombo.SelectedItem as ProjectModel;
            //var prId = Convert.ToInt32(this.PrOnTaskcombo.SelectedItem); 
            //var prName = this.PrOnTaskcombo.Text;
            var taskName = this.TaskNameBox.Text;
            var taskReview = this.TaskReviewBox.Text;
            var taskStartDate = this.StartTaskDateTimePicker.Value;
            var taskEndDate = this.EndTaskDateTimePicker.Value;
            _taskService.AddTask(prName.Id, taskName,  taskStartDate, taskEndDate);
            
            this.Close();

        }
        private void SetProjectsDgv()
        {
            var bindingSource = new BindingSource();
            var allTasks = _taskService.GetAllTasks();
            bindingSource.DataSource = allTasks;

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.AutoSize = true;
            dataGridView2.DataSource = bindingSource;
            dataGridView2.ScrollBars = ScrollBars.Both;

            var nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = nameof(TaskModel.Description);
            nameColumn.Name = "Задача";
            dataGridView2.Columns.Add(nameColumn);

            DataGridViewColumn startDateColumn = new DataGridViewTextBoxColumn();
            startDateColumn.DataPropertyName = nameof(TaskModel.StartDate);
            startDateColumn.Name = "Дата начала";
            dataGridView2.Columns.Add(startDateColumn);

            DataGridViewColumn endDateColumn = new DataGridViewTextBoxColumn();
            endDateColumn.DataPropertyName = nameof(TaskModel.EndDate);
            endDateColumn.Name = "Дата конца";
            dataGridView2.Columns.Add(endDateColumn);
        }
        private void SaveTaskButt_Click(object sender, EventArgs e) //сохранить изменения
        {

        }

        private void DeleteTaskButt_Click(object sender, EventArgs e)//удалить задачу
        {

        }

        private void PersTaskButt_Click(object sender, EventArgs e)//сотрудники задачи
        {
            Курсовая.AddUsersToTask addUsersToTask = new Курсовая.AddUsersToTask();
            addUsersToTask.Show();
        }

        private void PrOnTaskcombo_Click(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            var allProjects = _projectService.GetAllProjects();
            comboBox.ValueMember = nameof(ProjectModel.Id);
            comboBox.DisplayMember = nameof(ProjectModel.Name);
            comboBox.DataSource = allProjects;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
