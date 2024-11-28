using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

public static class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 4;
    private const int MemorySize = 65536;
    private const int DegreeOfParallelism = 8;

    private static byte[] GenerateSalt()
    {
        using var rng = RandomNumberGenerator.Create();
        var salt = new byte[SaltSize];
        rng.GetBytes(salt);
        return salt;
    }

    private static byte[] HashPassword(string password, byte[] salt)
    {
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
        {
            Salt = salt,
            Iterations = Iterations,
            MemorySize = MemorySize,
            DegreeOfParallelism = DegreeOfParallelism
        };

        return argon2.GetBytes(HashSize);
    }

    public static (byte[] Salt, byte[] Hash) CreatePasswordHash(string password)
    {
        var salt = GenerateSalt();
        var hash = HashPassword(password, salt);
        return (salt, hash);
    }

    public static bool VerifyPassword(string password, byte[] salt, byte[] storedHash)
    {
        var hash = HashPassword(password, salt);
        return hash.SequenceEqual(storedHash);
    }

    public static string ByteArrayToBase64(byte[] array)
    {
        return Convert.ToBase64String(array);
    }

    public static byte[] Base64ToByteArray(string base64)
    {
        return Convert.FromBase64String(base64);
    }

    public static bool ValidatePassword(string password, bool requireRestrictions)
    {
        if (requireRestrictions)
        {
            // Sprawdzenie polityki hase�: has�o musi zawiera� co najmniej jedn� wielk� liter� i dwie cyfry
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasDigit = password.Count(char.IsDigit) >= 2; // Sprawdzamy, czy s� co najmniej dwie cyfry

            return hasUpperCase && hasDigit;  // Warunki polityki has�a
        }

        return true;  // Je�li polityka has�a nie jest wymagana, zawsze zwr�ci true
    }

}
