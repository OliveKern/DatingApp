using System.ComponentModel.DataAnnotations;

namespace DatingApp.Logic.Models
{
    public class RegisterDto 
    {
        [Required]
        [MaxLength(100)]
        public required string Username { get; set; }       //required is only for the conpiler to not throw an error

        [Required]
        public required string Password { get; set; }
    }
}

