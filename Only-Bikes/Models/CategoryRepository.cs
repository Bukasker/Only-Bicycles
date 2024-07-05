using Only_bicycles.Models;

namespace Only_Bikes.Models
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly OnlyBicycleDbContext _onlyBicycleDbContext;

		public CategoryRepository(OnlyBicycleDbContext bethanysPieShopDbContext)
		{
			_onlyBicycleDbContext = bethanysPieShopDbContext;
		}

		public IEnumerable<Category> AllCategories => 
			_onlyBicycleDbContext.Categories.OrderBy(p => p.CategoryName);
	}
}
