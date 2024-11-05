
using System.Security.Cryptography;
using System.Text;
using DatingApp.Logic.Contracts;
using DatingApp.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.WebApi.Controllers
{
    public class AccountController(Logic.DataContext.ProjectDbContext dbContext) : BaseApiController
    {
        [HttpPost("register")] //account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto, ITokenService tokenService)     //FromQuery, FromBody, etc. tell the http service where to loog for the param data
        {
            if(await UserExists(registerDto.Username)) return BadRequest("Username is already taken");

            using var hmac = new HMACSHA512();

            var user = new Logic.Entities.Base.AppUser
            {
                UserName = registerDto.Username.ToLower(),  // ausnahmsweise tolower weil datingapp und nicht spielapp
                PassswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return new UserDto {
                Username = user.UserName,
                Token = tokenService.CreateToken(user)
            };    
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto, ITokenService tokenService) 
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if(user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt); //passes the salt to hmac

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != user.PassswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDto {
                Username = user.UserName,
                Token = tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username) 
        {
            return await dbContext.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower()); //Bob != bob 
        }
    }
}

