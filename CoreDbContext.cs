using Microsoft.EntityFrameworkCore;
using ProjectManagerCore.Models;

namespace ProjectManagerCore
{
	public class CoreDbContext : DbContext
	{
		public DbSet<ActivityModel> Activities { get; set; }

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
