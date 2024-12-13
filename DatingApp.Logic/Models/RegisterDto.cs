using System.ComponentModel.DataAnnotations;

namespace DatingApp.Logic.Models
{
    public class RegisterDto 
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;      //required is only for the conpiler to not throw an error

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; } = string.Empty;
    }
}

