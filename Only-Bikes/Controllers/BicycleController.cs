using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Only_bicycles.Models;
using Only_bicycles.ViewModels;

namespace Only_Bikes.Controllers;

public class BicycleController(
    IBicycleRepository bicycleRepository,
    ICategoryRepository category,
    IGenderCategoryRepository genderCategory)
    : Controller
{
    [Authorize]
    public IActionResult List()
    {
        //ViewBag.CurrentCategory = "Rower Górski";
        //return View(_bicycleRepository.AllBicycle);
        BicycleListViewModel bicycleListViewModel = new BicycleListViewModel(bicycleRepository.AllBicycle, "All Bikes",
            genderCategory.AllGenderCategories);
        return View(bicycleListViewModel);
    }

    [Authorize]
    public IActionResult Details(int id)
    {
        var bicycle = bicycleRepository.GetBicycleId(id);
        if (bicycle == null)
            return NotFound();
        return View(bicycle);
    }
}