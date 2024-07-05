using Only_bicycles.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Only_Bikes.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        [Required]
        public required DateTime EndDate { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
        
        public required int BicycleId { get; set; }
        [ForeignKey(nameof(BicycleId))]
        public Bicycle Bicycle { get; set; }
    }
}
