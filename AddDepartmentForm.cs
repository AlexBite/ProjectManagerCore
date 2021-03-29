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
    public partial class AddDepartmentForm : Form
    {
        private readonly IDepartmentService _departmentService;

        public AddDepartmentForm()
        {
            _departmentService = new DepartmentService();
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var departmentName = nameTb.Text;
            _departmentService.AddDepartment(departmentName);
            this.Close();
        }
    }
}
