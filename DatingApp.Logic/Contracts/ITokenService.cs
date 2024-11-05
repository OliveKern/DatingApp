using DatingApp.Logic.Entities.Base;

namespace DatingApp.Logic.Contracts
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}


