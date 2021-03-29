using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Linq;

namespace WorkingTimeTracker
{
	
//	public class UsersDataBase : IUsersDataBase
//	{
//		private List<UserInfo> DataBase = new List<UserInfo>();
		
//		public UserInfo GetAuthenticatedUser(string login, string password)
//		{
//			foreach (UserInfo user in DataBase)
//			{
//				if (user.Login == login && user.Password == password)
//					return user;
//			}
//			return null;
//		}

//		public string [] GetNamesOfUsers()
//		{
//			List<string> names = new List<string>();
//			foreach (var user in DataBase)
//			{
//				names.Add(user.Fio);
//			}
//			return names.ToArray();

////			return names.ToString();
//		}


//		public UserInfo GetUserByLogin(string login)
//		{
//			foreach (var user in DataBase)
//			{
//				if (user.Login == login)
//					return user;
//			}
//			return null;
//		}

//		public UserInfo GetUser(int userId)
//		{/*
//			foreach (var user in DataBase)
//			{
//				if (user.Id == userId)
//					return user;
//			}
//			return null;*/
//		}

//		public void AddUser(UserInfo userInfo)
//		{
//			int unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
//			userInfo.Id = unixTime;
//			DataBase.Add(userInfo);
//		}

//		public void DeleteUser(int userId)
//		{
//			var user = GetUser(userId);
//			DataBase.Remove(user);
//		}

//		public void SaveDataBase()
//		{
//			BinaryFormatter binaryFormatter = new BinaryFormatter();
//			FileStream fileStream = new FileStream("users.dat", FileMode.OpenOrCreate);
//			binaryFormatter.Serialize(fileStream, DataBase);
//			fileStream.Close();
//		}

//		public bool DataBaseHasChanges()
//		{
//			BinaryFormatter binaryFormatter = new BinaryFormatter();
//			FileStream fileStream = new FileStream("users.dat", FileMode.OpenOrCreate);
//			List<UserInfo> oldDataBase = new List<UserInfo>();
//			if (fileStream.Length != 0)
//			{
//				oldDataBase = (List<UserInfo>)binaryFormatter.Deserialize(fileStream);
//			}
//			fileStream.Close();

//			foreach (var user in DataBase)
//			{
//				UserInfo foundUser = oldDataBase.Find(item => item.Id == user.Id);
//				if (foundUser == null)
//					return true;
//			}

//			foreach (var user in oldDataBase)
//			{
//				UserInfo foundUser = DataBase.Find(item => item.Id == user.Id);
//				if (foundUser == null)
//					return true;
//			}
//			return false;
//		}

//		public void OpenDataBase()
//		{
//			BinaryFormatter binaryFormatter = new BinaryFormatter();
//			FileStream fileStream = new FileStream("users.dat", FileMode.OpenOrCreate);
//			if (fileStream.Length != 0)
//			{
//				DataBase = (List<UserInfo>)binaryFormatter.Deserialize(fileStream);
//			}
//			fileStream.Close();
//		}
//	}
}
