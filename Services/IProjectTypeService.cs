using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{ 
    public interface IProjectTypeService
    {
        ProjectTypeModel AddType(string name);
        List<ProjectTypeModel> GetAllTypes();
    }
}
