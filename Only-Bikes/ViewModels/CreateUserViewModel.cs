using System.ComponentModel.DataAnnotations;

namespace Only_Bikes.ViewModels;

public class CreateUserViewModel
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = default!;

    [Required]
    [MinLength(6, ErrorMessage = "Hasło musi mieć przynajmniej 6 znaków.")]
    public string Password { get; set; } = default!;

    [Required]
    [Compare("Password", ErrorMessage = "Hasła muszą być identyczne.")]
    public string ConfirmPassword { get; set; } = default!;

    [Required]
    public Guid RoleId { get; set; } = default!;// Wybór roli użytkownika
}
