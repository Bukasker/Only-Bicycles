using Only_bicycles.Models;
using System.ComponentModel.DataAnnotations;

namespace Only_Bikes.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemId {  get; set; }
        public required int BicycleId { get; set; }
        public Bicycle Bicycle { get; set; } = default!;
        public required string? ShoppingCartId { get; set; }
    }
}
