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
using Курсовая;

namespace Курсовая
{
    public partial class DepartmentJobConnect : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly IPositionService _positionService;
        public DepartmentJobConnect()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
            _positionService = new PositionService();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            var allDepartments = _departmentService.GetAllDepartment();
            comboBox.ValueMember = nameof(DepartmentModel.Id);
            comboBox.DisplayMember = nameof(DepartmentModel.Name);
            comboBox.DataSource = allDepartments;
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            var allPositions = _positionService.GetAllPosition();
            comboBox.ValueMember = nameof(PositionModel.Id);
            comboBox.DisplayMember = nameof(PositionModel.Name);
            comboBox.DataSource = allPositions;
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            var allEmployees = _employeeService.GetAllEmployee();
            comboBox.ValueMember = nameof(EmployeeModel.Id);
            comboBox.DisplayMember = nameof(EmployeeModel.Name);
            comboBox.DataSource = allEmployees;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
