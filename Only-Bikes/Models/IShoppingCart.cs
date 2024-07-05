using Only_bicycles.Models;
using System.IO.Pipelines;

namespace Only_Bikes.Models
{
    public interface IShoppingCart
    {
        /*
        void AddReservation(Reservation reservation);
        int RemoveReservation(Reservation reservation);
        */
        void AddToCart(Bicycle bicycle);
        int RemoveFromCart(Bicycle bicycle);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        decimal GetHourlyRate();

        List<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
