using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;

namespace ProjectManagerCore.Services
{
	public interface IProjectService
	{
		ProjectModel AddProject(string name, string leadEmployeeId, DateTime startDate, DateTime endDate);
		List<ProjectModel> GetAllProjects();
	}
}
