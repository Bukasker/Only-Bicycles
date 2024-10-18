using System.ComponentModel.DataAnnotations;

namespace Only_Bikes.ViewModels;

public class ResetPasswordViewModel
{
    [Required(ErrorMessage = "Aktualne hasło jest wymagane.")]
    [DataType(DataType.Password)]
    [Display(Name = "Aktualne hasło")]
    public string? CurrentPassword { get; init; }

    [Required(ErrorMessage = "Nowe hasło jest wymagane.")]
    [DataType(DataType.Password)]
    [Display(Name = "Nowe hasło")]
    public string? NewPassword { get; init; }

    [Required(ErrorMessage = "Potwierdzenie nowego hasła jest wymagane.")]
    [DataType(DataType.Password)]
    [Display(Name = "Potwierdź nowe hasło")]
    [Compare(nameof(NewPassword), ErrorMessage = "Hasła muszą się zgadzać.")]
    public string? ConfirmNewPassword { get; init; }
}