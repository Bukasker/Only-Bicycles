using Only_bicycles.Models;
using Microsoft.AspNetCore.Mvc;
using Only_Bikes.Models;
using Only_bicycles.ViewModels;

namespace Only_bicycles.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBicycleRepository _bicycleRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IBicycleRepository bicycleRepository, IShoppingCart shoppingCart)
        {
            _bicycleRepository = bicycleRepository;
            _shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int bicycleId)
        {
            var selectedBike = _bicycleRepository.AllBicycle.FirstOrDefault(p => p.BicycleId == bicycleId);

            if (selectedBike != null)
            {
                _shoppingCart.AddToCart(selectedBike);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int bicycleId)
        {
            var selectedBike = _bicycleRepository.AllBicycle.FirstOrDefault(p => p.BicycleId == bicycleId);

            if (selectedBike != null)
            {
                _shoppingCart.RemoveFromCart(selectedBike);
            }
            return RedirectToAction("Index");
        }
    }
}
