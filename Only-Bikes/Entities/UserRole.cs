using System.ComponentModel.DataAnnotations;

namespace Only_Bikes.Entities;

public class UserRole
{
    public required Guid Id { get; init; }
    [MaxLength(50)] public required string Name { get; init; }
}