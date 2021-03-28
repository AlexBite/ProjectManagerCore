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
	public partial class AddProjectForm : Form
    {
		private readonly ProjectsDataBase _projectsDataBase;
		
		public AddProjectForm(ProjectsDataBase projectsDataBase)
        {
            InitializeComponent();
			_projectsDataBase = projectsDataBase;
		}
		
		private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void PrAddButton_Click(object sender, EventArgs e)
        {
            PrRegistrationProcess();
        }

		private void PrRegistrationProcess()
		{
			//bool notAllInfoInputed =  ProjectTB.Text == string.Empty;

			//if (notAllInfoInputed)
			//{
			//	MessageBox.Show("Необходимо заполнить название проекта!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//	return;
			//}

			//string newName = ProjectTB.Text;
			//DateTime newStDay = StartTaskDateTimePicker.Value;
			//DateTime newEndDay = EndTaskDateTimePicker.Value;
			//string newStDay = StartDateTimePicker.Text;
			//string newEndDay = EndDateTimePicker.Text;


			//ProjectInfo newProject = new ProjectInfo()
			//{
			//	Name = newName,
			//	StartDay = newStDay,
			//	EndDate = newEndDay,
				
			//};

			
			
			//MessageBox.Show("Проект успешно добавлен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
			////очищение полей 
			//ProjectTB.Clear();
			//_projectsDataBase.AddProject(newProject);
			//_projectsDataBase.SaveDataBase();
			
		}
	}
}
