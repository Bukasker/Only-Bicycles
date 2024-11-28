using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.ErrorMessage = "Login lub Hasło niepoprawne";
            return View(model);
        }

        // Próbujemy uwierzytelnić użytkownika
        var isAuthenticated = await userService.AuthenticateUserAsync(model.Name, model.Password);

        if (isAuthenticated)
        {
            var user = await userService.GetUserByNameAsync(model.Name);

            if (user is null)
            {
                model.ErrorMessage = "Login lub Hasło niepoprawne";
                return View(model);
            }

            // Sprawdzamy, czy użytkownik jest zablokowany
            if (user.IsBlocked)
            {
                model.ErrorMessage = "Twoje konto zostało zablokowane. Skontaktuj się z administratorem.";
                return View(model); // Zwracamy widok z komunikatem o błędzie
            }

            // Tworzymy claimy dla użytkownika
            var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Role, user.Role.Name)
        };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity)
            );

            return RedirectToAction("Index", "Home");
        }

        model.ErrorMessage = "Login lub Hasło niepoprawny";
        return View(model);
    }


    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}