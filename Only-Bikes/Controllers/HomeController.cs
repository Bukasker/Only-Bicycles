using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Only_bicycles.Models;
using Only_bicycles.ViewModels;

namespace Only_Bikes.Controllers;

public class HomeController(IBicycleRepository bikeRepository) : Controller
{
    [Authorize]
    public IActionResult Index()
    {
        if (User.Identity is null || !User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Account");
        }

        var bikeOfTheWeek = bikeRepository.BicyclesOfTheWeek;

        var homeViewModel = new HomeViewModel(bikeOfTheWeek);

        return View(homeViewModel);
    }
}