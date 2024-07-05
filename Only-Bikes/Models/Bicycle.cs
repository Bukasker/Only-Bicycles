using Only_Bikes.Models;
using System.ComponentModel.DataAnnotations;

namespace Only_bicycles.Models
{
	public class Bicycle
	{
		[Key]
		public required int BicycleId { get; set; }
		public decimal RentCost { get; set; }
		public bool isAvailableNow { get; set; }
		public string? ImageUrl { get; set; }
		public string? ImageThumbnailUrl { get; set; }

		public string Model { get; set; } = string.Empty;
		public string? Brand { get; set; }
		public string? FrameSize { get; set; }
        public bool IsBikeOfTheWeek { get; set; }

       // public List<Reservation> Reservations { get; set; }

        public required int CategoryId { get; set; }
		public Category Category { get; set; } = default!;

		public required int GenderCategoryID { get; set; }
		public GenderCategory GenderCategory { get; set; } = default!;

	}
}
