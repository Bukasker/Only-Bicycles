 using Only_bicycles.Models;

namespace Only_bicycles.ViewModels
{
	public class BicycleListViewModel
	{
		public IEnumerable<Bicycle> Bicycles { get; }

		public IEnumerable<GenderCategory>? CurrentGenderCategory { get; }
		public string? CurrentCategory { get; }

		public BicycleListViewModel(IEnumerable<Bicycle> bicycles, string? currentCategory, IEnumerable<GenderCategory>? currentGenderCategory)
		{
			Bicycles = bicycles;
			CurrentCategory = currentCategory;
			CurrentGenderCategory = currentGenderCategory;
		}
	}
}
