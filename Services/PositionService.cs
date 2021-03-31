using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerCore.Services
{
	internal class PositionService : IPositionService
	{
		public PositionModel AddPosition(string name)
		{
			var position = new PositionModel()
			{
				Name = name
			};

			using (var dbContext = new CoreDbContext())
			{
				dbContext.Positions.Add(position);
				dbContext.SaveChanges();
			}

			return position;
		}
		public List<PositionModel> GetAllPosition()
		{
			List<PositionModel> departments;
			using (var dbContext = new CoreDbContext())
			{
				departments = dbContext.Positions.ToList();
			}
			return departments;
		}

		public PositionModel GetPosition(int posId)
        {
			PositionModel depModel;
			using (var dbContext = new CoreDbContext())
			{
				depModel = dbContext.Positions.Where(e => e.Id == posId)
					.FirstOrDefault();
			}

			return depModel;
		}
	}
}
