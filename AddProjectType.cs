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
    public partial class AddProjectType : Form
    {
        private readonly IProjectTypeService _typeService;
        public AddProjectType()
        {
            InitializeComponent(); 
            _typeService = new ProjectTypeService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool notAllInfoInputed = textBox1.Text == string.Empty;

            if (notAllInfoInputed)
            {
                MessageBox.Show("Необходимо заполнить все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var typeName = textBox1.Text;
            _typeService.AddType(typeName);
            this.Close();
        }
    }
}
