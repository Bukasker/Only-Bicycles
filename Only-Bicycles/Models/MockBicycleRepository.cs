namespace Only_bicycles.Models
{
	public class MockBicycleRepository : IBicycleRepository
	{
		private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
		private readonly IGenderCategoryRepository _genderCategoryRepository = new MockGenderCategoryRepository();
		public IEnumerable<Bicycle> AllBicycle =>
			new List<Bicycle>
			{
				new Bicycle{BicycleId=1,RentCost=50.00M,isAvailableNow=true, Model="JD-2137",Brand="Merida", FrameSize=12,
					Category=_categoryRepository.AllCategories.ToList()[0],GenderCategory = _genderCategoryRepository.AllGenderCategories.ToList()[0],
					ImageUrl="www",
					ImageThumbnailUrl="www",
				}
			};

		public IEnumerable<Bicycle> MaleBicycles
		{
			get
			{
				return AllBicycle.Where(p => p.GenderCategory.GenderCategoryID == 0);
			}
		}
		
		public Bicycle? GetBicycleId(int bicycleId) => AllBicycle.FirstOrDefault(p => p.BicycleId == bicycleId);

		public IEnumerable<Bicycle> SearchBicycles(string searchQuary)
		{
			throw new NotImplementedException();
		}
	}

}
