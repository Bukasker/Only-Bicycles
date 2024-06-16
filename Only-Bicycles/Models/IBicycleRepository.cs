namespace Only_bicycles.Models
{
	public interface IBicycleRepository
	{
		IEnumerable<Bicycle> AllBicycle {  get; }

		Bicycle? GetBicycleId(int pieId);
	}
}
