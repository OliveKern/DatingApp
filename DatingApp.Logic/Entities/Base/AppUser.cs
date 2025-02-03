//Visual Studio adds .Folder automatically. Needs to be added manually if one codes without such tools. (conventional)
using System.ComponentModel.DataAnnotations;

namespace DatingApp.Logic.Entities.Base
{
    public class AppUser : IdentityEntity
    {
        //required laut kurs
        public required string UserName { get; set; } //= string.Empty;
        //falls nicht required.
        //public string UserName { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
        public DateOnly DateOfBirth { get; set; }
        public required string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
        public required string Gender { get; set; }
        public string Introduction { get; set; } = string.Empty;
        public string Interests { get; set; } = string.Empty;
        public string LookingFor { get; set; } = string.Empty;
        public required string City { get; set; }
        public required string Country { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();
    }
}
