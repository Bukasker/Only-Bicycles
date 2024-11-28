using System.Collections;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Only_Bikes.Entities;
using Only_Bikes.Models;

namespace Only_Bikes.Services;

public interface IUserService
{
    IQueryable<User> GetUsers();
    Task<User?> GetUserByNameAsync(string identifier);
    Task<User?> GetUserByIdAsync(Guid userId);
    Task<bool> AuthenticateUserAsync(string identifier, string password);
    Task ResetPasswordAsync(string userName, string newPassword);
    Task ChangeUserNameAsync(Guid userId, string newUserName);
    Task CreateUserAsync(User user, string password);
    Task<bool> UpdatePasswordAsync(Guid userId, string currentPassword, string newPassword);
    Task ToggleUserBlockStatusAsync(Guid userId);
    Task DeleteUserAsync(Guid userId);
    Task TogglePasswordRestrictionsAsync(Guid userId);
    Task UpdateUserAsync(Guid userId, string newUserName, string newPassword, bool? passwordRestrictionsEnabled);
    Task<bool> ValidateUserPasswordAsync(Guid userId, string password);
}

public class UserService(OnlyBicycleDbContext context) : IUserService
{
    public async Task<(byte[] Salt, byte[] Hash)?> GetUserPasswordHashAndSaltAsync(string identifier)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Name == identifier);
        if (user == null)
            return null;

        var salt = PasswordHasher.Base64ToByteArray(user.PasswordSalt);
        var hash = PasswordHasher.Base64ToByteArray(user.PasswordHash);
        return (salt, hash);
    }

    public IQueryable<User> GetUsers()
    {
        return context.Users.AsNoTracking();
    }

    public async Task<User?> GetUserByNameAsync(string identifier)
    {
        return await context.Users
            .AsNoTracking()
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Name == identifier);
    }

    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await context.Users
            .Include(u => u.Role)
            .SingleOrDefaultAsync(u => u.Id.Equals(userId));
    }

    public async Task<bool> AuthenticateUserAsync(string identifier, string password)
    {
        var hashAndSalt = await GetUserPasswordHashAndSaltAsync(identifier);
        if (hashAndSalt == null)
            return false;

        var (salt, hash) = hashAndSalt.Value;
        return PasswordHasher.VerifyPassword(password, salt, hash);
    }

    public async Task ResetPasswordAsync(string userName, string newPassword)
    {
        var user = await context.Users.SingleAsync(u => u.Name == userName);
        var (salt, hash) = PasswordHasher.CreatePasswordHash(newPassword);
        user.PasswordSalt = PasswordHasher.ByteArrayToBase64(salt);
        user.PasswordHash = PasswordHasher.ByteArrayToBase64(hash);
        await context.SaveChangesAsync();
    }

    public async Task ChangeUserNameAsync(Guid userId, string newUserName)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new InvalidOperationException("U¿ytkownik nie zosta³ znaleziony.");
        }

        user.Name = newUserName; // Zmieniamy nazwê u¿ytkownika
        await context.SaveChangesAsync();
    }

    public async Task CreateUserAsync(User user, string password)
    {
        if (user.Role == null)
        {
            throw new ArgumentException("Rola u¿ytkownika nie mo¿e byæ pusta.", nameof(user.Role));
        }

        // Sprawdzanie, czy polityka hase³ jest w³¹czona
        if (user.IsPasswordPolicyEnabled)
        {
            // Weryfikacja, czy has³o spe³nia wymagania
            if (!PasswordHasher.ValidatePassword(password, requireRestrictions: true))
            {
                throw new ArgumentException("Has³o musi zawieraæ co najmniej jedn¹ wielk¹ literê i dwie cyfry.");
            }
        }

        // Tworzenie has³a
        var (salt, hash) = PasswordHasher.CreatePasswordHash(password);
        user.PasswordSalt = PasswordHasher.ByteArrayToBase64(salt);
        user.PasswordHash = PasswordHasher.ByteArrayToBase64(hash);

        // Dodaj u¿ytkownika do bazy
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        // Ustawienie daty wygaœniêcia has³a (np. 90 dni)
        user.PasswordExpirationDate = DateTime.UtcNow.AddDays(90);
        await context.SaveChangesAsync();
    }




    public async Task<bool> UpdatePasswordAsync(Guid userId, string currentPassword, string newPassword)
    {
        // Pobierz u¿ytkownika na podstawie ID
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new InvalidOperationException("U¿ytkownik nie zosta³ znaleziony.");
        }

        // Sprawdzenie, czy has³o wygas³o
        if (user.PasswordExpirationDate.HasValue && user.PasswordExpirationDate.Value < DateTime.UtcNow)
        {
            throw new InvalidOperationException("Twoje has³o wygas³o. Musisz ustawiæ nowe has³o.");
        }

        // Sprawdzenie poprawnoœci obecnego has³a
        var salt = PasswordHasher.Base64ToByteArray(user.PasswordSalt);
        var hash = PasswordHasher.Base64ToByteArray(user.PasswordHash);
        if (!PasswordHasher.VerifyPassword(currentPassword, salt, hash))
        {
            return false; // Nieprawid³owe obecne has³o
        }

        // Sprawdzamy, czy nowe has³o ró¿ni siê od poprzednich
        var (newSalt, newHash) = PasswordHasher.CreatePasswordHash(newPassword);
        if (user.PreviousPasswordHashes.Contains(PasswordHasher.ByteArrayToBase64(newHash)))
        {
            throw new InvalidOperationException("Nowe has³o musi ró¿niæ siê od poprzednich.");
        }

        // Zaktualizuj has³o
        user.PasswordSalt = PasswordHasher.ByteArrayToBase64(newSalt);
        user.PasswordHash = PasswordHasher.ByteArrayToBase64(newHash);

        // Dodaj nowe has³o do historii (np. przechowujemy tylko ostatnich 5 hase³)
        if (user.PreviousPasswordHashes.Count >= 5)
        {
            user.PreviousPasswordHashes.RemoveAt(0); // Usuwamy najstarsze has³o
        }
        user.PreviousPasswordHashes.Add(PasswordHasher.ByteArrayToBase64(newHash));

        // Ustaw now¹ datê wygaœniêcia has³a (np. 90 dni od teraz)
        user.PasswordExpirationDate = DateTime.UtcNow.AddDays(90);

        // Zapisz zmiany w bazie danych
         user.PasswordExpirationDate = DateTime.UtcNow.AddDays(90);
        await context.SaveChangesAsync();
        return true; // Has³o zaktualizowane pomyœlnie
    }


    public async Task ToggleUserBlockStatusAsync(Guid userId)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new InvalidOperationException("U¿ytkownik nie zosta³ znaleziony.");
        }

        // Zmieniamy status blokady
        user.IsBlocked = !user.IsBlocked;
        await context.SaveChangesAsync();
    }
    public async Task DeleteUserAsync(Guid userId)
    {
        var user = await context.Users.FindAsync(userId);
        if (user != null)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }

    public async Task TogglePasswordRestrictionsAsync(Guid userId)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new InvalidOperationException("U¿ytkownik nie zosta³ znaleziony.");
        }

        // Zmiana ustawienia restrykcji has³a
        user.IsPasswordPolicyEnabled = !user.IsPasswordPolicyEnabled;
        await context.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(Guid userId, string newUserName, string newPassword, bool? passwordRestrictionsEnabled)
    {
        // Pobierz u¿ytkownika na podstawie ID
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new InvalidOperationException("U¿ytkownik nie zosta³ znaleziony.");
        }

        // Jeœli u¿ytkownik chce zmieniæ nazwê u¿ytkownika
        if (!string.IsNullOrEmpty(newUserName) && newUserName != user.Name)
        {
            user.Name = newUserName;
        }

        // Jeœli has³o zosta³o podane, zweryfikuj i zaktualizuj
        if (!string.IsNullOrEmpty(newPassword))
        {
            // SprawdŸ, czy polityka has³a zosta³a zmieniona
            if (passwordRestrictionsEnabled.HasValue && passwordRestrictionsEnabled.Value != user.IsPasswordPolicyEnabled)
            {
                // Jeœli polityka zosta³a zmieniona, zweryfikuj i zaktualizuj has³o
                if (passwordRestrictionsEnabled.Value)
                {
                    // W³¹cz restrykcje has³a - sprawdŸ, czy has³o spe³nia wymagania
                    if (!PasswordHasher.ValidatePassword(newPassword, true))
                    {
                        throw new ArgumentException("Has³o musi zawieraæ co najmniej jedn¹ wielk¹ literê i dwie cyfry.");
                    }
                }

                // Zmiana flagi w u¿ytkowniku
                user.IsPasswordPolicyEnabled = passwordRestrictionsEnabled.Value;
            }
            else if (!PasswordHasher.ValidatePassword(newPassword, user.IsPasswordPolicyEnabled))
            {
                throw new ArgumentException("Has³o musi zawieraæ co najmniej jedn¹ wielk¹ literê i dwie cyfry.");
            }

            // Utwórz nowe has³o i zapisujemy je
            var (salt, hash) = PasswordHasher.CreatePasswordHash(newPassword);
            user.PasswordSalt = PasswordHasher.ByteArrayToBase64(salt);
            user.PasswordHash = PasswordHasher.ByteArrayToBase64(hash);
        }

        // Zapisz zmiany w bazie danych
        await context.SaveChangesAsync();
    }
    public async Task<bool> ValidateUserPasswordAsync(Guid userId, string password)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            return false;
        }

        // Jeœli polityka has³a jest wy³¹czona, nie stosujemy restrykcji
        bool isPasswordValid = user.IsPasswordPolicyEnabled
            ? PasswordHasher.ValidatePassword(password, true)
            : PasswordHasher.ValidatePassword(password, false);

        if (isPasswordValid)
        {
            return true;
        }

        return false;
    }

}