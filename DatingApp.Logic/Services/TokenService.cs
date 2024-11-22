using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DatingApp.Logic.Contracts;
using DatingApp.Logic.Controllers;
using DatingApp.Logic.Entities.Base;
using DatingApp.Logic.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.Logic.Services
{
    public class TokenService(IConfiguration config) : ServiceObject, ITokenService
    {
        public string ProvideToken(AccountDto account)
        {
            var userName = account.UserName;

            var token = CreateToken(userName);

            return token;
        }

        public string ProvideToken(AppUser user)
        {
            var userName = user.UserName;

            var token = CreateToken(userName);

            return token;
        }

        public string CreateToken(string userName)
        {
            var tokenKey = config["TokenKey"] ?? throw new Exception("Cannot access tokenkey from appsettings");
            if(tokenKey.Length < 64) throw new Exception("Applied tokenKey is not long enough");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, userName)
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}


