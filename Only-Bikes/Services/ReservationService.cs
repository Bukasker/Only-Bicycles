using Only_Bikes.Models;

namespace Only_Bikes.Services
{
    public static class ReservationService
    {
        public static decimal GetTotalCost(DateTime endDate, IShoppingCart cart)
        {
            var hours = (endDate - DateTime.UtcNow).TotalHours;
            var totalCost =  (decimal)hours * cart.GetHourlyRate();
            return Math.Round(totalCost, 2);
        }
    }
}
