using System.ComponentModel.DataAnnotations;

namespace Only_Bikes.Entities;

public class User
{
    public required Guid Id { get; init; }

    [MaxLength(50)] public required string Name { get; set; }

    [MaxLength(128)] public required string PasswordHash { get; set; }
    [MaxLength(64)] public required string PasswordSalt { get; set; }

    public bool IsBlocked { get; set; } = false;
    public bool IsPasswordPolicyEnabled { get; set; } = true;
    public required Guid RoleId { get; init; }
    public required UserRole Role { get; init; }

    public DateTime? PasswordExpirationDate { get; set; }
    public List<string> PreviousPasswordHashes { get; set; } = new List<string>();
    public bool IsFirstLogin { get; set; } = true; 
}