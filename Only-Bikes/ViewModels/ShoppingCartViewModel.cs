using Only_Bikes.Models;
using Only_Bikes.Services;

namespace Only_bicycles.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal)
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
        }

        public IShoppingCart ShoppingCart { get; }
        public decimal ShoppingCartTotal { get; }
        private DateTime _endDate = DateTime.UtcNow.AddHours(1);
        public DateTime EndDate {
            get => _endDate;
            set
            {
                _endDate = value;
                TotalCost = ReservationService.GetTotalCost(_endDate, ShoppingCart);
            }
        }
        public string? FirstName { get; set; } = default;
        public string? LastName { get; set; } = default;
        public string? PhoneNumber { get; set; } = default;
        public decimal? TotalCost { get; set; } = default;
    }
}
