using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Only_Bikes.Services;
using Only_Bikes.ViewModels;

namespace Only_Bikes.Controllers;

[Authorize]
public class SettingsController(IUserService userService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Settings()
    {
        var userNameClaimValue = User.FindFirst(ClaimTypes.Name)?.Value;
        if (userNameClaimValue is null)
        {
            throw new InvalidOperationException("User role not found.");
        }

        var user = await userService.GetUserByNameAsync(userNameClaimValue);
        if (user is null)
        {
            throw new InvalidOperationException("User with given name not found.");
        }

        var model = new SettingsViewModel
        {
            UserRole = user.Role
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
        TempData["SuccessMessage"] = "Hasło zostało zmienione.";
        return RedirectToAction("Settings");
    }
}