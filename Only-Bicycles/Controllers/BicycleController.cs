using Microsoft.AspNetCore.Mvc;
using Only_bicycles.Models;
using Only_bicycles.ViewModels;

namespace Only_bicycles.Controllers
{
	public class BicycleController : Controller
	{
		private readonly IBicycleRepository _bicycleRepository;
		private readonly ICategoryRepository _categoryRepository;
		private readonly IGenderCategoryRepository _genderRepository;
		
		public BicycleController(IBicycleRepository bicycleRepository, ICategoryRepository category, IGenderCategoryRepository genderCategory)
		{
			_bicycleRepository = bicycleRepository;
			_categoryRepository = category;
			_genderRepository = genderCategory;
		}

		public IActionResult List() 
		{
			//ViewBag.CurrentCategory = "Rower Górski";
			//return View(_bicycleRepository.AllBicycle);
			BicycleListViewModel bicycleListViewModel = new BicycleListViewModel(_bicycleRepository.AllBicycle,"Rower Górski",_genderRepository.AllGenderCategories);
			return View(bicycleListViewModel);
		}
	}
}
