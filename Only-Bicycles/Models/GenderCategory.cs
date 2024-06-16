namespace Only_bicycles.Models
{
	public class GenderCategory
	{
		public int GenderCategoryID { get; set; }
		public string GenderName { get; set; } = string.Empty;
		public List<Bicycle>? Bicycles { get; set; }
	}
}
