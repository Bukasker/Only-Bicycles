using System.ComponentModel.DataAnnotations;

namespace Only_Bikes.ViewModels;

public class ChangeUserNameViewModel
{
    [Required(ErrorMessage = "Nowa nazwa użytkownika jest wymagana.")]
    [MinLength(3, ErrorMessage = "Nazwa użytkownika musi mieć co najmniej 3 znaki.")]
    [Display(Name = "Nowa nazwa użytkownika")]
    public string? NewUserName { get; init; }
}