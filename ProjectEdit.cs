using ProjectManagerCore.Models;
using ProjectManagerCore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectManagerCore
{
    public partial class ProjectEdit : Form
    {
        private readonly IProjectService _projectService;
        private readonly IEmployeeService _employeeService;
        public ProjectEdit()
        {
            InitializeComponent();
            _projectService = new ProjectService();
            _employeeService = new EmployeeService();
        }

        private void comboBox1_Click(object sender, EventArgs e)//вывод меню проектов
        {
            var comboBox = sender as ComboBox;
            var allProjects = _projectService.GetAllProjects();
            comboBox.ValueMember = nameof(ProjectModel.Id);
            comboBox.DisplayMember = nameof(ProjectModel.Name);
            comboBox.DataSource = allProjects;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            var allEmployees = _employeeService.GetAllEmployee();
            comboBox.ValueMember = nameof(EmployeeModel.Id);
            comboBox.DisplayMember = nameof(EmployeeModel.Name);
            comboBox.DataSource = allEmployees;
        }

        private void button1_Click(object sender, EventArgs e)// сохранение 
        {
            if (comboBox1.Text== "" || comboBox2.Text == "")
            {
                MessageBox.Show ("Заполните все поля");
            }
            else { 
            if (textBox1.Text == "")
            { 
               // var proname= (ProjectModel)comboBox1.Text;
                var projectToEdit = (ProjectModel)comboBox1.SelectedItem;
            var emplpoeeToEdit = (EmployeeModel)comboBox2.SelectedItem;            
            var projectStartDate = this.projectStartDateDTP.Value;
            var projectEndDate = this.projectEndDateDTP.Value;

            _projectService.EditProject(projectToEdit.Name, projectToEdit.Id, emplpoeeToEdit.Id, projectStartDate, projectEndDate);
                this.Close(); 
            }
            else
                {
                    var projectToEdit = (ProjectModel)comboBox1.SelectedItem;
                    var emplpoeeToEdit = (EmployeeModel)comboBox2.SelectedItem;
                    var projectStartDate = this.projectStartDateDTP.Value;
                    var projectEndDate = this.projectEndDateDTP.Value;
                    var projectNameNew = textBox1.Text;

                    _projectService.EditProjectName(projectNameNew, projectToEdit.Id, emplpoeeToEdit.Id, projectStartDate, projectEndDate);
                    this.Close();
                }        
            }
        }

        
    }
}
