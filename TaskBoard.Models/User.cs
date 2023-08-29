
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Models
{
    public class User :IdentityUser 
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public UserRole Role { get; set; }

    }   
}
