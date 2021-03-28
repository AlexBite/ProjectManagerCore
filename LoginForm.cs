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
    [Serializable]
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        private void LoginProcess()
        {
            string login = loginTb.Text;
            string password = passwordTb.Text;

            //UserInfo authenticatedUser = _usersDataBase.GetAuthenticatedUser(login, password);
            //bool userIsRegistered = authenticatedUser != null;
            if (login =="1" && password =="1")
            {
                WorkingTimeTracker.MainForm mainForm = new WorkingTimeTracker.MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
