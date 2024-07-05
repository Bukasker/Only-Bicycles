using Only_bicycles.Models;
using Microsoft.AspNetCore.Mvc;
using Only_Bikes.Models;
using Only_bicycles.ViewModels;
using Only_Bikes.Services;

namespace Only_bicycles.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBicycleRepository _bicycleRepository;
        private readonly IShoppingCart _shoppingCart;
        private readonly OnlyBicycleDbContext _context;

        public ShoppingCartController(
            IBicycleRepository bicycleRepository,
            IShoppingCart shoppingCart,
            OnlyBicycleDbContext context
            )
        {
            _bicycleRepository = bicycleRepository;
            _shoppingCart = shoppingCart;
            _context = context;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());
            shoppingCartViewModel.TotalCost = ReservationService.GetTotalCost(shoppingCartViewModel.EndDate, _shoppingCart);
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

		[HttpPost]
		public IActionResult UpdateTotalCost(ShoppingCartViewModel model)
        {
			model.TotalCost = ReservationService.GetTotalCost(model.EndDate, _shoppingCart);
			return View("Index", model);
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

        [HttpPost]
        public IActionResult CreateReservation(ShoppingCartViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<Reservation> reservations = new();
                foreach(var bicycle in model.ShoppingCart.GetShoppingCartItems())
                {
                    var reservation = new Reservation
                    {
                        EndDate = model.EndDate,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        PhoneNumber = model.PhoneNumber,
                        BicycleId = bicycle.BicycleId,
                    };
                    reservations.Add(reservation);
                }

                _context.Reservations.AddRange(reservations);
                _context.SaveChanges();

                return RedirectToAction("Summary");
            }

            return View("Index", model);
        }

        public IActionResult Summary()
        {
            return View();
        }
    }
}
