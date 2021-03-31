using ProjectManagerCore.Services;
using System;
using System.Windows.Forms;
using WorkingTimeTracker;

namespace Курсовая
{
	[Serializable]
	public partial class LoginForm : Form
	{
		private readonly IAuthenticationService authService;

		public LoginForm()
		{
			authService = new AuthenticationService();
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			bool notAllInfoInputed = (loginTb.Text == string.Empty || passwordTb.Text == string.Empty );

			if (notAllInfoInputed)
			{
				MessageBox.Show("Необходимо заполнить все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			LoginProcess();
		}

		private void LoginProcess()
		{
			var login = loginTb.Text;
			var password = passwordTb.Text;

			var authenticatedUser = authService.AuthenticateUser(login, password);
			bool userIsRegistered = authenticatedUser != null;

			if (userIsRegistered)
			{
				var mainForm = new MainForm(authenticatedUser);
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
