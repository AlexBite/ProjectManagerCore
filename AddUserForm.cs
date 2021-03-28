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

namespace WorkingTimeTracker
{
	[Serializable]

	public partial class AddUserForm : Form
	{
		private readonly UsersDataBase _usersDataBase;
		public AddUserForm()
		{
			InitializeComponent();
			
		}
		//public AddUserForm(UsersDataBase usersDataBase)
		//{
		//	InitializeComponent();
		//	//_usersDataBase = usersDataBase;
		//}

		#region --- Events ---
		private void fioTb_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back)
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
			}
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			RegistrationProcess();
		}
		#endregion

		#region --- Methods ---
		private void RegistrationProcess()
		{
			//bool notAllInfoInputed = SurnameTb.Text == string.Empty || NameTb.Text == string.Empty ||
			//	 MiddleNameTb.Text == string.Empty || LoginTb.Text == string.Empty || PasswordTb.Text == string.Empty;

			//if (notAllInfoInputed)
			//{
			//	MessageBox.Show("Необходимо заполнить все поля!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//	return;
			//}

			//string newSurName = SurnameTb.Text;
			//string newName = NameTb.Text;
			//string newMiddleName = MiddleNameTb.Text;
			//string newLogin = LoginTb.Text;
			//string newPassword = PasswordTb.Text;
			//UserInfo.UserRole newRole = ConvertTextToRole();
			//string newFio = $"{newSurName} {newName} {newMiddleName}";

			//UserInfo newUser = new UserInfo()
			//{
			//	Fio = newFio,
			//	Login = newLogin,
			//	Password = newPassword,
			//	Role = newRole
			//};

			//UserInfo userWithSameAuthorizationData = _usersDataBase.GetUserByLogin(newUser.Login);
			//bool authorizationDataIsAlreadyInUse = userWithSameAuthorizationData != null;
			//if (authorizationDataIsAlreadyInUse)
			//{
			//	MessageBox.Show("Логин уже используется!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//	return;
			//}

			//_usersDataBase.AddUser(newUser);

			//MessageBox.Show("Пользователь успешно добавлен!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
			////очищение полей 
			//SurnameTb.Clear();
			//NameTb.Clear();
			//MiddleNameTb.Clear();
			//UserRoleCb.SelectedIndex = -1;
			//LoginTb.Clear();
			//PasswordTb.Clear();
		}
		//выбор должности 
		//public UserInfo.UserRole ConvertTextToRole()
		//public UserInfo.UserRole ConvertTextToRole()
		//{
		//	string chosenRole = UserRoleCb.Text;
		//	if (chosenRole == "Директор")
		//		return UserInfo.UserRole.Leader;

		//	if (chosenRole == "Разработчик")
		//		return UserInfo.UserRole.Employee;

		//	return UserInfo.UserRole.Empty;
		}
		#endregion

		//private void SurnameTb_TextChanged(object sender, EventArgs e)
		//{

		//}

  //      private void EndDateTimePicker_ValueChanged(object sender, EventArgs e)
  //      {

  //      }
    }


