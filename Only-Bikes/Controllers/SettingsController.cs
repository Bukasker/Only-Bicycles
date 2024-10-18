using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Only_Bikes.Services;
using Only_Bikes.ViewModels;

namespace Only_Bikes.Controllers;

[Authorize]
public class SettingsController(IUserService userService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Settings()
    {
        var userNameIdentifierValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userNameIdentifierValue is null || !Guid.TryParse(userNameIdentifierValue, out var userId))
        {
            ModelState.AddModelError("", "Nie znaleziono użytkownika.");
            return View();
        }

        var user = await userService.GetUserByIdAsync(userId);
        if (user is null)
        {
            ModelState.AddModelError("", "Nie znaleziono użytkownika.");
            return View();
        }

        var users = await userService
            .GetUsers()
            .Select(u => new UserViewModel
            {
                Id = u.Id,
                UserName = u.Name,
                IsBlocked = false,
                PasswordExpirationDate = null
            }).ToListAsync();

        var model = new SettingsViewModel
        {
            UserRole = user.Role,
            Users = users
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var userNameClaimValue = User.FindFirst(ClaimTypes.Name)?.Value;
        if (userNameClaimValue is null)
        {
            ModelState.AddModelError("", "Nie znaleziono użytkownika.");
            return View(model);
        }

        if (model.CurrentPassword is null)
        {
            ModelState.AddModelError(nameof(ResetPasswordViewModel.CurrentPassword), "Aktualne hasło jest wymagane.");
            return View(model);
        }

        var isValidCurrentPassword = await userService.AuthenticateUserAsync(userNameClaimValue, model.CurrentPassword);
        if (!isValidCurrentPassword)
        {
            ModelState.AddModelError(nameof(ResetPasswordViewModel.CurrentPassword), "Nieprawidłowe hasło.");
            return View(model);
        }

        if (!string.Equals(model.NewPassword, model.ConfirmNewPassword))
        {
            ModelState.AddModelError(nameof(ResetPasswordViewModel.ConfirmNewPassword), "Hasła się nie zgadzają.");
            return View(model);
        }

        await userService.ResetPasswordAsync(userName: userNameClaimValue, newPassword: model.NewPassword);
        TempData["ResetPasswordSuccess"] = "Hasło zostało zmienione.";
        return RedirectToAction("Settings");
    }

    [HttpPost]
    public async Task<IActionResult> ChangeUserName(ChangeUserNameViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var userIdClaimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaimValue is null || !Guid.TryParse(userIdClaimValue, out var userId))
        {
            ModelState.AddModelError("", "Nie znaleziono użytkownika.");
            return View(model);
        }

        if (string.IsNullOrWhiteSpace(model.NewUserName))
        {
            ModelState.AddModelError(nameof(ChangeUserNameViewModel.NewUserName),
                "Nowa nazwa użytkownika jest wymagana.");
            return View(model);
        }

        await userService.ChangeUserNameAsync(userId, model.NewUserName);
        TempData["UserNameChangeSuccess"] = "Nazwa użytkownika została zmieniona.";
        return RedirectToAction("Settings");
    }
}