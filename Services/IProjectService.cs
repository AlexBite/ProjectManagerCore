using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;

namespace ProjectManagerCore.Services
{
	public interface IProjectService
	{
		ProjectModel AddProject(string name, DateTime startDate, DateTime endDate, int typeId);
		List<ProjectModel> GetAllProjects();
		void DeleteProject(int id);
		void EditProject(string name, int id, int ide, DateTime startDate, DateTime endDate);
		void EditProjectName(string name, int id, int ide, DateTime startDate, DateTime endDate);
		ProjectModel GetProject(int projectId);
	}
}
