using Only_bicycles.Models;
using System.ComponentModel.DataAnnotations;

namespace Only_Bikes.Models
{
    public class ShoppingCartItem
    {

        public int ShoppingCartItemId {  get; set; }
        public Bicycle Bicycle { get; set; } = default!;

        [Key]
        public string? ShoppingCartId { get; set; }

    }
}
