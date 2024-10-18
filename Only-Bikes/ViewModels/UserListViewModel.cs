namespace Only_Bikes.ViewModels;

public class UserListViewModel
{
    public IEnumerable<UserViewModel> Users { get; set; } = new List<UserViewModel>();
}