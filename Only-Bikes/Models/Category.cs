namespace Only_bicycles.Models
{
	public class Category
	{
		public required int CategoryId { get; set; }
		public string CategoryName { get; set; } = string.Empty;
		public string CategoryDescription { get; set; } = string.Empty;
		public List<Bicycle>? Bicycles { get; set; }
	}
}
