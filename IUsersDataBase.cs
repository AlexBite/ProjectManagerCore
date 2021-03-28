using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingTimeTracker
{
	public interface IUsersDataBase
	{
		UserInfo GetUserByLogin(string login);
		UserInfo GetUser(int userId);

		string[] GetNamesOfUsers();
		void AddUser(UserInfo userInfo);

		void DeleteUser(int userId);
		void SaveDataBase();

		bool DataBaseHasChanges();
		void OpenDataBase();

	}
}
