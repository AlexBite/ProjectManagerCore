using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Linq;

namespace WorkingTimeTracker
{

	public class WorkingDataBase : IWorkingDataBase
	{
		private List<WorkingSessionInfo> DataBase = new List<WorkingSessionInfo>();

		public List<WorkingSessionInfo> GetAll()
		{
			return DataBase;
		}

		public WorkingSessionInfo GetWS(int WsId)
		{
			foreach (var WS in DataBase)
			{
				if (WS.Id == WsId)
					return WS;
			}
			return null;
		}

		/*public WorkingSessionInfo GetWSByParams(int wsId)
		{
			foreach (var WS in DataBase)
			{
				if (WS.StartTime == StartTime && WS.Date==Date)
				{
					wsId = WS.Id;
					return WS;
				}

					
			}
			return null;
		}*/

		public void AddWS(WorkingSessionInfo wsInfo)
		{
			int unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
			wsInfo.Id = unixTime;
			DataBase.Add(wsInfo);
		}

		public void DeleteWS(int WSId)
		{
			var WS = GetWS(WSId);
			DataBase.Remove(WS);
		}

		public void SaveDataBase()
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = new FileStream("sessions.dat", FileMode.OpenOrCreate);
			binaryFormatter.Serialize(fileStream, DataBase);
			fileStream.Close();
		}

		public bool DataBaseHasChanges()
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = new FileStream("sessions.dat", FileMode.OpenOrCreate);
			List<WorkingSessionInfo> oldDataBase = new List<WorkingSessionInfo>();
			if (fileStream.Length != 0)
			{
				oldDataBase = (List<WorkingSessionInfo>)binaryFormatter.Deserialize(fileStream);
			}
			fileStream.Close();

			foreach (var ws in DataBase)
			{
				WorkingSessionInfo foundWS = oldDataBase.Find(item => item.Id == ws.Id);
				if (foundWS == null)
					return true;
			}

			foreach (var ws in oldDataBase)
			{
				WorkingSessionInfo foundWS = DataBase.Find(item => item.Id == ws.Id);
				if (foundWS == null)
					return true;
			}
			return false;
		}

		public void OpenDataBase()
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = new FileStream("sessions.dat", FileMode.OpenOrCreate);
			if (fileStream.Length != 0)
			{
				DataBase = (List<WorkingSessionInfo>)binaryFormatter.Deserialize(fileStream);
			}
			fileStream.Close();
		}

	}
}
