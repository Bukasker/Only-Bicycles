using System.ComponentModel.DataAnnotations;

namespace Only_Bikes.Entities;

public class User
{
    public required Guid Id { get; init; }

    [MaxLength(50)] public required string Name { get; set; }

    [MaxLength(128)] public required string PasswordHash { get; set; }
    [MaxLength(64)] public required string PasswordSalt { get; set; }

    public required Guid RoleId { get; init; }
    public required UserRole Role { get; init; }
}