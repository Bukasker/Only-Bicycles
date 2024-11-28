using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Only_Bikes.Entities;
using Only_Bikes.Models;
using Only_Bikes.Services;
using Only_Bikes.ViewModels;

namespace Only_Bikes.Controllers;

[Authorize]
public class SettingsController(IUserService userService, OnlyBicycleDbContext context) : Controller
{
    private readonly IUserService _userService = userService;
    private readonly OnlyBicycleDbContext _context = context;

    [HttpGet]
    public async Task<IActionResult> Settings()
    {
        var userNameIdentifierValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userNameIdentifierValue is null || !Guid.TryParse(userNameIdentifierValue, out var userId))
        {
            ModelState.AddModelError("", "Nie znaleziono użytkownika.");
            return View();
        }

        var user = await _userService.GetUserByIdAsync(userId);
        if (user is null)
        {
            ModelState.AddModelError("", "Nie znaleziono użytkownika.");
            return View();
        }

        var users = await _userService.GetUsers()
            .Select(u => new UserViewModel
            {
                Id = u.Id,
                UserName = u.Name,
                IsBlocked = u.IsBlocked  // Upewnij się, że status blokady jest uwzględniany
            }).ToListAsync();

        var model = new SettingsViewModel
        {
            UserRole = user.Role,
            Users = users
        };

        return View(model); // Zaktualizowane dane użytkowników
    }
    public async Task UpdateUserAsync(Guid userId, string newUserName, string newPassword, bool? passwordRestrictionsEnabled)
    {
        // Pobierz użytkownika na podstawie ID
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new InvalidOperationException("Użytkownik nie został znaleziony.");
        }

        // Jeśli użytkownik chce zmienić nazwę użytkownika
        if (!string.IsNullOrEmpty(newUserName) && newUserName != user.Name)
        {
            user.Name = newUserName;
        }

        // Jeśli hasło zostało podane, zweryfikuj i zaktualizuj
        if (!string.IsNullOrEmpty(newPassword))
        {
            // Sprawdź, czy polityka hasła została zmieniona
            if (passwordRestrictionsEnabled.HasValue && passwordRestrictionsEnabled.Value != user.IsPasswordPolicyEnabled)
            {
                // Jeśli polityka została zmieniona, zweryfikuj i zaktualizuj hasło
                if (passwordRestrictionsEnabled.Value)
                {
                    // Włącz restrykcje hasła - sprawdź, czy hasło spełnia wymagania
                    if (!PasswordHasher.ValidatePassword(newPassword, true))
                    {
                        throw new ArgumentException("Hasło musi zawierać co najmniej jedną wielką literę i dwie cyfry.");
                    }
                }
                // Zmiana flagi w użytkowniku
                user.IsPasswordPolicyEnabled = passwordRestrictionsEnabled.Value;
            }
            else
            {
                // Jeśli hasło nie ma wymagań (brak ograniczeń), przechodzimy do zapisu bez weryfikacji
                if (user.IsPasswordPolicyEnabled && !PasswordHasher.ValidatePassword(newPassword, user.IsPasswordPolicyEnabled))
                {
                    throw new ArgumentException("Hasło musi zawierać co najmniej jedną wielką literę i dwie cyfry.");
                }
            }

            // Utwórz nowe hasło i zapisujemy je
            var (salt, hash) = PasswordHasher.CreatePasswordHash(newPassword);
            user.PasswordSalt = PasswordHasher.ByteArrayToBase64(salt);
            user.PasswordHash = PasswordHasher.ByteArrayToBase64(hash);
        }

        // Zapisz zmiany w bazie danych
        await context.SaveChangesAsync();
    }



    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        var roles = _context.UserRoles.ToList();
        if (roles == null || !roles.Any())
        {
            ModelState.AddModelError("", "Brak dostępnych ról.");
            return View();
        }
        if (!roles.Any())
        {
            throw new Exception("Brak ról w bazie danych");
        }

        ViewBag.Roles = roles; // Pobierz dostępne role
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateUserViewModel model)
    {
        // Sprawdzenie walidacji modelu
        if (!ModelState.IsValid)
        {
            // Załaduj role ponownie, jeśli walidacja się nie powiedzie
            ViewBag.Roles = await _context.UserRoles.ToListAsync();
            return View(model);
        }

        // Pobranie wybranej roli na podstawie RoleId
        var role = await _context.UserRoles.SingleOrDefaultAsync(r => r.Id == model.RoleId);
        if (role == null)
        {
            ModelState.AddModelError("", "Wybrana rola jest nieprawidłowa.");

            // Załaduj role ponownie przed zwróceniem widoku
            ViewBag.Roles = await _context.UserRoles.ToListAsync();
            return View(model);
        }

        // Utworzenie nowego użytkownika
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            RoleId = role.Id,
            Role = role,
            PasswordSalt = string.Empty, // Tymczasowe wartości dla hash i salt
            PasswordHash = string.Empty // Do uzupełnienia np. w UserService
        };

        // Przed przekazaniem hasła do utworzenia użytkownika, sprawdź, czy spełnia wymagania
        if (!PasswordHasher.ValidatePassword(model.Password, true))  // Zmieniliśmy na 'true', by wymusić restrykcje
        {
            ModelState.AddModelError("", "Hasło musi zawierać co najmniej jedną wielką literę i dwie cyfry.");
            ViewBag.Roles = await _context.UserRoles.ToListAsync();
            return View(model); // Jeśli hasło nie spełnia restrykcji, zwróć formularz
        }

        // Tworzenie użytkownika w bazie danych
        await _userService.CreateUserAsync(user, model.Password);

        // Przekierowanie po sukcesie
        TempData["UserCreationSuccess"] = "Użytkownik został pomyślnie dodany.";
        return RedirectToAction("Settings");
    }


    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var userIdValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdValue == null || !Guid.TryParse(userIdValue, out var userId))
        {
            ModelState.AddModelError("", "Nie można zweryfikować tożsamości użytkownika.");
            return View(model);
        }

        var isUpdated = await _userService.UpdatePasswordAsync(userId, model.CurrentPassword, model.NewPassword);
        if (!isUpdated)
        {
            ModelState.AddModelError("", "Podano nieprawidłowe aktualne hasło.");
            return View(model);
        }

        TempData["ResetPasswordSuccess"] = "Hasło zostało pomyślnie zresetowane.";
        return RedirectToAction("Settings");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ChangeUserName(ChangeUserNameViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model); // Jeśli model jest nieprawidłowy, zwróć widok
        }

        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        try
        {
            // Wywołaj usługę, aby zmienić nazwę użytkownika
            await _userService.ChangeUserNameAsync(userId, model.NewUserName);
            TempData["UserNameChangeSuccess"] = "Nazwa użytkownika została pomyślnie zmieniona.";
            return RedirectToAction("Settings"); // Przekieruj do widoku ustawień
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Błąd zmiany nazwy: {ex.Message}");
            return View(model); // Jeśli wystąpił błąd, wyświetl formularz ponownie
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Block(Guid id)
    {
        try
        {
            // Toggle status blokady użytkownika
            await _userService.ToggleUserBlockStatusAsync(id);

            // Dodaj komunikat o sukcesie do TempData
            TempData["SuccessMessage"] = "Status użytkownika został pomyślnie zaktualizowany.";
        }
        catch (Exception ex)
        {
            TempData["SuccessMessage"] = $"Błąd: {ex.Message}";
        }

        // Przekierowanie do widoku Settings, aby zaktualizować listę użytkowników
        return RedirectToAction("Settings"); // Możesz również przekierować do innej metody (np. UserList), jeśli chcesz
    }

    public async Task<IActionResult> UserList()
    {
        var users = await _userService.GetUsers()
                                      .Select(u => new UserViewModel
                                      {
                                          Id = u.Id,
                                          UserName = u.Name,
                                          IsBlocked = u.IsBlocked
                                      })
                                      .ToListAsync();

        return View(new UserListViewModel { Users = users });
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Użytkownik nie został znaleziony.";
                return RedirectToAction("UserList");  // Przekierowanie na stronę listy użytkowników
            }

            // Usuń użytkownika
            await _userService.DeleteUserAsync(id);

            // Przekierowanie na stronę Settings z komunikatem o sukcesie
            TempData["SuccessMessage"] = "Użytkownik został pomyślnie usunięty.";
            return RedirectToAction("Settings");  // Strona z ustawieniami
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Błąd: {ex.Message}";
            return RedirectToAction("UserList");  // Jeśli wystąpił błąd, przekierowanie na stronę listy użytkowników
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> TogglePasswordRestrictions(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            TempData["ErrorMessage"] = "Użytkownik nie został znaleziony.";
            return RedirectToAction("Settings");
        }

        // Przełączamy stan wymagania hasła
        bool newPasswordPolicyState = !user.IsPasswordPolicyEnabled;

        // Przekazujemy zmieniony stan do metody UpdateUserAsync
        await _userService.UpdateUserAsync(user.Id, user.Name, null, newPasswordPolicyState);

        TempData["SuccessMessage"] = $"Wymaganie dotyczące hasła zostało {(newPasswordPolicyState ? "włączone" : "wyłączone")}.";
        return RedirectToAction("Settings");
    }

}

