using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Somu.Backend.Models.Auth;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
