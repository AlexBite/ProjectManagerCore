using ProjectManagerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagerCore.Services
{
	public interface IPositionService
	{
		public PositionModel AddPosition(string name);
		PositionModel GetPosition(int posId);

		List<PositionModel> GetAllPosition();
	}
}
