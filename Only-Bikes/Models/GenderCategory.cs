using System.ComponentModel.DataAnnotations;

namespace Only_bicycles.Models
{
	public class GenderCategory
	{
		[Key]
		public required int GenderCategoryID { get; set; }
		public string GenderName { get; set; } = string.Empty;
		public List<Bicycle>? Bicycles { get; set; }
	}
}
