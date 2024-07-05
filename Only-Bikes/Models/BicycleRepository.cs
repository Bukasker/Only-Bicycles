using Microsoft.EntityFrameworkCore;
using Only_bicycles.Models;
using System.IO.Pipelines;

namespace Only_Bikes.Models
{
	public class BicycleRepository : IBicycleRepository
	{
		private readonly OnlyBicycleDbContext _onlyBicycleDbContext;

		public BicycleRepository(OnlyBicycleDbContext onlyBicycleDbContext)
		{
			_onlyBicycleDbContext = onlyBicycleDbContext;
		}

		public IEnumerable<Bicycle> AllBicycle
		{
			get
			{
				return _onlyBicycleDbContext.Bicycles.Include(c => c.Category);
			}
		}

        public IEnumerable<Bicycle> BicyclesOfTheWeek
        {
            get
            {
                return _onlyBicycleDbContext.Bicycles.Include(c => c.Category).Where(p => p.IsBikeOfTheWeek);
            }
        }
        public Bicycle? GetBicycleId(int bicycleId)
		{
			return _onlyBicycleDbContext.Bicycles.FirstOrDefault(p => p.BicycleId == bicycleId);
		}

		public IEnumerable<Bicycle> SearchBicycles(string searchQuery)
		{
			throw new NotImplementedException();
		}
	}
}
