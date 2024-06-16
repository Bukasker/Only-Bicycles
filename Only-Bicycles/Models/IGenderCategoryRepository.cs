namespace Only_bicycles.Models
{
	public interface IGenderCategoryRepository
	{
		IEnumerable<GenderCategory> AllGenderCategories { get; }
	}
}
