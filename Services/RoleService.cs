using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
    
	internal class RoleService : IRoleService
	{
		public RoleModel AddRole(string name)
		{
			var role = new RoleModel()
			{
				Name = name
			};

			using (var dbContext = new CoreDbContext())
			{
				dbContext.Roles.Add(role);
				dbContext.SaveChanges();
			}

			return role;
		}
	}
}
 

