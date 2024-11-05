//Visual Studio adds .Folder automatically. Needs to be added manually if one codes without such tools. (conventional)
namespace DatingApp.Logic.Entities.Base
{
    public class AppUser : IdentityEntity
    {
        //required laut kurs
        public required string UserName { get; set; }

        public required byte[] PassswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
        

        //falls nicht required.
        //public string UserName { get; set; } = string.Empty;
    }
}
