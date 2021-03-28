using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingTimeTracker
{
	public interface IProjectsDataBase
	{
		ProjectInfo GetProject(int projectId);
		void AddProject(ProjectInfo projectInfo);
		void SaveDataBase();
		bool DataBaseHasChanges();
		void OpenDataBase();
		int GetCountOfProjects();
		List<ProjectInfo> GetListOfProjects();


	}
}
