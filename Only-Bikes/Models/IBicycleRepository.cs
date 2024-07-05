using System.IO.Pipelines;

namespace Only_bicycles.Models
{
	public interface IBicycleRepository
	{
		IEnumerable<Bicycle> AllBicycle {  get; }
        IEnumerable<Bicycle> BicyclesOfTheWeek { get; }
        Bicycle? GetBicycleId(int bicycleId);
		IEnumerable<Bicycle> SearchBicycles(string searchQuery);
	}
}
