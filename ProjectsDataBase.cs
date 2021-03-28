using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Linq;

namespace WorkingTimeTracker
{
	public class ProjectsDataBase : IProjectsDataBase
	{
		private List<ProjectInfo> DataBase = new List<ProjectInfo>();

		public ProjectInfo GetProject(int projectId)
		{
			foreach (var project in DataBase)
			{
				if (project.Id == projectId)
					return project;
			}
			return null;
		}

		public ProjectInfo GetProjectByName(string projectName)
		{
			foreach (var project in DataBase)
			{
				if (project.Name == projectName)
					return project;
			}
			return null;
		}

		public ProjectInfo GetProjectName(string newPrName)
		{
			foreach (var project in DataBase)
			{
				if (project.Name == newPrName)
					return project;
			}
			return null;
		}

		public List<ProjectInfo> GetListOfProjects()
		{
			return DataBase;
		}
		public int GetCountOfProjects()
		{
			return DataBase.Count();
		}

		public void AddProject(ProjectInfo projectInfo)
		{
			int unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
			projectInfo.Id = unixTime;
			DataBase.Add(projectInfo);
		}

		public string[] GetNamesOfProjects()
		{
			List<string> names = new List<string>();
			foreach (var project in DataBase)
			{
				names.Add(project.Name);
			}
			return names.ToArray();
		}

		public void SaveDataBase()
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = new FileStream("project.dat", FileMode.OpenOrCreate);
			binaryFormatter.Serialize(fileStream, DataBase);
			fileStream.Close();
			
		}
		

		public bool DataBaseHasChanges()
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = new FileStream("project.dat", FileMode.OpenOrCreate);
			List<ProjectInfo> oldDataBase = new List<ProjectInfo>();
			if (fileStream.Length != 0)
			{
				oldDataBase = (List<ProjectInfo>)binaryFormatter.Deserialize(fileStream);
			}
			fileStream.Close();

			foreach (var project in DataBase)
			{
				ProjectInfo foundProject = oldDataBase.Find(item => item.Id == project.Id);
				if (foundProject == null)
					return true;
			}

			foreach (var project in oldDataBase)
			{
				ProjectInfo foundProject = DataBase.Find(item => item.Id == project.Id);
				if (foundProject == null)
					return true;
			}
			return false;
		}

		public void OpenDataBase()
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			FileStream fileStream = new FileStream("project.dat", FileMode.OpenOrCreate);
			if (fileStream.Length != 0)
			{
				DataBase = (List<ProjectInfo>)binaryFormatter.Deserialize(fileStream);
			}
			fileStream.Close();
		}
		
	}
}
