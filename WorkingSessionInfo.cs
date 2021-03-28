using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WorkingTimeTracker
{[Serializable]
	public class WorkingSessionInfo
	{
		
		public int Id { get; set; }
		public int UserId { get; set; }
		public int ProjectId { get; set; }
		public string Aim { get; set; }
		public DateTime StartTime { get; set; }
		public int SpentWorkHours { get; set; }
		public DateTime Date { get; set; }
	}
}
