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
    public partial class AddRoleForm : Form
    {
        private readonly IRoleService _roleService;
        public AddRoleForm()
        {
            _roleService = new RoleService();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool notAllInfoInputed = textBox1.Text == string.Empty;

            if (notAllInfoInputed)
            {
                MessageBox.Show("Необходимо заполнить все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var roleName = textBox1.Text;
            _roleService.AddRole(roleName);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
