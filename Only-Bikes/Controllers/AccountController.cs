using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Only_Bikes.Services;
using Only_Bikes.ViewModels;

namespace Only_Bikes.Controllers;

public class AccountController(IUserService userService) : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model); // Zwrot błędów walidacji
        }

        var user = await userService.GetUserByNameAsync(model.Name);
        if (user == null || !await userService.AuthenticateUserAsync(model.Name, model.Password))
        {
            ModelState.AddModelError("", "Nieprawidłowe dane logowania.");
            return View(model);
        }

        // Zaloguj użytkownika
        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Role, user.Role.Name) // Jeśli role są używane
    };
        var identity = new ClaimsIdentity(claims, "ApplicationCookie");
        var principal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(principal);

        // Sprawdź, czy to pierwsze logowanie
        if (user.IsFirstLogin)
        {
            TempData["ResetPasswordNotice"] = "Musisz zresetować swoje hasło przed dalszym korzystaniem z aplikacji.";
            return RedirectToAction("ResetPassword", "Settings"); // Przekierowanie do resetu hasła
        }

        return RedirectToAction("Index", "Home"); // Normalne przekierowanie po zalogowaniu
    }




    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}