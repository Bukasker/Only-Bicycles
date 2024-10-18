using System.ComponentModel.DataAnnotations;

namespace Only_Bikes.ViewModels;

public class UserViewModel
{
    public Guid Id { get; set; }
    [Display(Name = "Nazwa użytkownika")] public string UserName { get; set; }

    [Display(Name = "Zablokowany")] public bool IsBlocked { get; set; }

    [Display(Name = "Data wygaśnięcia hasła")]
    public DateTime? PasswordExpirationDate { get; set; }
}