using Microsoft.EntityFrameworkCore;
using Only_Bikes.Entities;
using Only_Bikes.Models;

namespace Only_Bikes.Services;

public interface IUserService
{
    Task<(byte[] Salt, byte[] Hash)?> GetUserPasswordHashAndSaltAsync(string identifier);
    Task<User?> GetUserByNameAsync(string identifier);
    Task<bool> AuthenticateUserAsync(string identifier, string password);
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

    public async Task<User?> GetUserByNameAsync(string identifier)
    {
        return await context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Name == identifier);
    }

    public async Task<bool> AuthenticateUserAsync(string identifier, string password)
    {
        var hashAndSalt = await GetUserPasswordHashAndSaltAsync(identifier);
        if (hashAndSalt == null)
            return false;

        var (salt, hash) = hashAndSalt.Value;
        return PasswordHasher.VerifyPassword(password, salt, hash);
    }
}