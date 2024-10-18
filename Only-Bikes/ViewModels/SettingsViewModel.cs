using Only_Bikes.Entities;

namespace Only_Bikes.ViewModels;

public class SettingsViewModel
{
    public required UserRole UserRole { get; init; }
    public required IEnumerable<UserViewModel> Users { get; init; } = new List<UserViewModel>();
}