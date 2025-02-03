//Visual Studio adds .Folder automatically. Needs to be added manually if one codes without such tools. (conventional)
namespace DatingApp.Logic.Entities.Base
{
    public class Photo : IdentityEntity
    {
        public required string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; } = string.Empty;
    }
}
