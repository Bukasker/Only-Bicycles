using System.ComponentModel.DataAnnotations;

namespace Only_Bikes.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
    [Display(Name = nameof(Name))]
    public string Name { get; set; }

    [Required(ErrorMessage = "Hasło jest wymagane")]
    [DataType(DataType.Password)]
    [Display(Name = nameof(Password))]
    public string Password { get; set; }

    public string? ErrorMessage { get; set; }
}