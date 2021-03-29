using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;

namespace ProjectManagerCore.Services
{
	public interface IProjectService
	{
		ProjectModel AddProject(string name, DateTime startDate, DateTime endDate);
		List<ProjectModel> GetAllProjects();
		void DeleteProject(int id);
	}
}
