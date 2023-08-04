using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GoldenGateAPI.Models;

public class User : IdentityUser
{

    // Extra information for user

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? LastName { get; set; }

    
}
