using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingTimeTracker
{
	[Serializable]
	public class ProjectInfo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime StartDay { get; set; }
		public DateTime EndDate { get; set; }
	}
}
