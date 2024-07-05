using Only_bicycles.Models;

namespace Only_bicycles.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Bicycle> BicylcesOfTheWeek { get; }

        public HomeViewModel(IEnumerable<Bicycle> bicyclesOfTheWeek)
        {
            BicylcesOfTheWeek = bicyclesOfTheWeek;
        }
    }
}
