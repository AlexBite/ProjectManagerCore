using Microsoft.EntityFrameworkCore;
using ProjectManagerCore.Models;

namespace ProjectManagerCore
{
	public class CoreDbContext : DbContext
	{
		public DbSet<ActivityModel> Activities { get; set; }
		public DbSet<DepartmentModel> DepartmentModels { get; set; }
		public DbSet<EmployeeDepartmentModel> EmployeeDepartments { get; set; }
		public DbSet<EmployeeModel> Employees { get; set; }
		public DbSet<EmployeeProjectModel> EmployeeProjects { get; set; }
		public DbSet<EmployeeTaskModel> EmployeeTasks { get; set; }
		public DbSet<PositionModel> Positions { get; set; }
		public DbSet<ProjectModel> Projects { get; set; }
		public DbSet<ProjectTypeModel> ProjectTypes { get; set; }
		public DbSet<RoleModel> Roles { get; set; }
		public DbSet<TaskModel> Tasks { get; set; }
		public DbSet<TimeRecordModel> TimeRecords { get; set; }

		public CoreDbContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Filename=core.db");
		}
	}
}
