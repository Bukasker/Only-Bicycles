using Only_bicycles.Models;

namespace Only_Bikes.Models
{
	public class GenderCategoryRepository : IGenderCategoryRepository
	{
		private readonly OnlyBicycleDbContext _onlyBicycleDbContext;

		public GenderCategoryRepository(OnlyBicycleDbContext bethanysPieShopDbContext)
		{
			_onlyBicycleDbContext = bethanysPieShopDbContext;
		}

		public IEnumerable<GenderCategory> AllGenderCategories =>
			_onlyBicycleDbContext.GenderCategories.OrderBy(p => p.GenderName);
	}
}
