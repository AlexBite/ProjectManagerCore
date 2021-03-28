using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingTimeTracker
{
	public interface IWorkingDataBase
	{
		WorkingSessionInfo GetWS(int WsId);
		void  AddWS(WorkingSessionInfo wsInfo);
		void DeleteWS(int WSId);
		void SaveDataBase();
		bool DataBaseHasChanges(); 
		void OpenDataBase();
		

	}
}
