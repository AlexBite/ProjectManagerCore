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
		
		public AddTaskForm()
			//public AddTaskForm(ProjectsDataBase projectsDataBase)
		{
            InitializeComponent();
			//_projectsDataBase = projectsDataBase;
		}
		
		private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void PrAddButton_Click(object sender, EventArgs e)//добавить задачу
        {
            PrRegistrationProcess();
        }

		private void PrRegistrationProcess()//
		{
			
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
    }
}
