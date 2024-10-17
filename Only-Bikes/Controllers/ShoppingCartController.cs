using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Only_bicycles.Models;
using Only_bicycles.ViewModels;
using Only_Bikes.Models;
using Only_Bikes.Services;

namespace Only_Bikes.Controllers;

public class ShoppingCartController(
    IBicycleRepository bicycleRepository,
    IShoppingCart shoppingCart,
    OnlyBicycleDbContext context)
    : Controller
{
    [Authorize]
    public ViewResult Index()
    {
        var items = shoppingCart.GetShoppingCartItems();
        shoppingCart.ShoppingCartItems = items;

        var shoppingCartViewModel = new ShoppingCartViewModel(shoppingCart, shoppingCart.GetShoppingCartTotal());
        shoppingCartViewModel.TotalCost = ReservationService.GetTotalCost(shoppingCartViewModel.EndDate, shoppingCart);
        return View(shoppingCartViewModel);
    }

    public RedirectToActionResult AddToShoppingCart(int bicycleId)
    {
        var selectedBike = bicycleRepository.AllBicycle.FirstOrDefault(p => p.BicycleId == bicycleId);

        if (selectedBike != null)
        {
            shoppingCart.AddToCart(selectedBike);
        }

        return RedirectToAction("Index");
    }

    [Authorize]
    [HttpPost]
    public IActionResult UpdateTotalCost(ShoppingCartViewModel model)
    {
        model.TotalCost = ReservationService.GetTotalCost(model.EndDate, shoppingCart);
        return View("Index", model);
    }


    public RedirectToActionResult RemoveFromShoppingCart(int bicycleId)
    {
        var selectedBike = bicycleRepository.AllBicycle.FirstOrDefault(p => p.BicycleId == bicycleId);

        if (selectedBike != null)
        {
            shoppingCart.RemoveFromCart(selectedBike);
        }

        return RedirectToAction("Index");
    }

    [Authorize]
    [HttpPost]
    public IActionResult CreateReservation(ShoppingCartViewModel model)
    {
        if (ModelState.IsValid)
        {
            List<Reservation> reservations = new();
            foreach (var bicycle in model.ShoppingCart.GetShoppingCartItems())
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

            context.Reservations.AddRange(reservations);
            context.SaveChanges();

            return RedirectToAction("Summary");
        }

        return View("Index", model);
    }

    public IActionResult Summary()
    {
        return View();
    }
}