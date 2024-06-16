namespace Only_bicycles.Models
{
	public class Bicycle
	{
		public int BicycleId { get; set; }
		public decimal RentCost { get; set; }
		public bool isAvailableNow { get; set; }
		public string? ImageUrl { get; set; }
		public string? ImageThumbnailUrl { get; set; }

		public string Model { get; set; } = string.Empty;
		public string? Brand { get; set; }
		public int? FrameSize { get; set; }

		
		public int CategoryId { get; set; }
		public Category Category { get; set; } = default!;

		public int GenderCategoryID { get; set; }
		public GenderCategory GenderCategory { get; set; } = default!;

	}
}
