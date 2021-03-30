using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{  
    public interface IRoleService
    {
        public RoleModel AddRole(string name);
    }
}
