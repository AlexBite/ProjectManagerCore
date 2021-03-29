using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
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
	}
}
