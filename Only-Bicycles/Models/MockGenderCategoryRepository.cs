namespace Only_bicycles.Models
{
	public class MockGenderCategoryRepository : IGenderCategoryRepository
	{
		public IEnumerable<GenderCategory> AllGenderCategories =>
			new List<GenderCategory>
			{
				new GenderCategory{GenderCategoryID=1, GenderName="Meskie"},
				new GenderCategory{GenderCategoryID=2, GenderName="Damskie"},
				new GenderCategory{GenderCategoryID=3, GenderName="Dzieciece"},
				new GenderCategory{GenderCategoryID=4, GenderName="Unisex"},
			};
	}
}

