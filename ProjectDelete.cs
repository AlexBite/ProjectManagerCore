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
	public partial class ProjectDelete : Form
	{
		private readonly IProjectService _projectService;
		private readonly ITaskService _taskService;

		public ProjectDelete()
		{
			_projectService = new ProjectService();
			_taskService = new TaskService();
			InitializeComponent();
		}

		private void projectsCB_Click(object sender, EventArgs e)
		{
			var comboBox = sender as ComboBox;
			var allProjects = _projectService.GetAllProjects();
			comboBox.ValueMember = nameof(ProjectModel.Id);
			comboBox.DisplayMember = nameof(ProjectModel.Name);
			comboBox.DataSource = allProjects;
		}

		private void deleteBtn_Click(object sender, EventArgs e)
		{
			bool notAllInfoInputed = (projectsCB.Text == string.Empty );

			if (notAllInfoInputed)
			{
				MessageBox.Show("Необходимо заполнить все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			var projectToDelete = (ProjectModel)projectsCB.SelectedItem;
			_projectService.DeleteProject(projectToDelete.Id);
			_taskService.DeleteTask(projectToDelete.Id);
			this.Close();
		}

        private void projectsCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
