using DatingApp.Logic.Entities.Base;
using DatingApp.Logic.Models;

namespace DatingApp.Logic.Contracts
{
    public interface ITokenService
    {
        string ProvideToken(AccountDto access);

        string ProvideToken(AppUser user);
    }
}


