using Only_bicycles.Models;
using Only_bicycles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Only_bicycles.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBicycleRepository _bikeRepository;

        public HomeController(IBicycleRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public ViewResult Index()
        {
            var bikeOfTheWeek = _bikeRepository.BicyclesOfTheWeek;

            var homeViewModel = new HomeViewModel(bikeOfTheWeek);

            return View(homeViewModel);
        }
    }
}
