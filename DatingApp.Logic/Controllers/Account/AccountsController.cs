using System;
using System.Security.Cryptography;
using System.Text;
using DatingApp.Logic.Contracts;
using DatingApp.Logic.DataContext;
using DatingApp.Logic.Entities.Base;
using DatingApp.Logic.Models;
using Microsoft.EntityFrameworkCore;
using QTSocialSecurity5.Logic.Modules.Exceptions;

namespace DatingApp.Logic.Controllers.Account
{
    public class AccountsController(ProjectDbContext dbContext) : GenericController<Entities.Base.AppUser>
    {
        public async Task<UserDto> Register(RegisterDto registerDto, ITokenService tokenService)     //FromQuery, FromBody, etc. tell the http service where to loog for the param data
        {
            using var hmac = new HMACSHA512();

            var user = new Logic.Entities.Base.AppUser
            {
                UserName = registerDto.Username.ToLower(),  // ausnahmsweise tolower weil datingapp und nicht spielapp
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return new UserDto {
                Username = user.UserName,
                Token = tokenService.ProvideToken(user)
            };    
        }

        public async Task<AccountDto?> Login(LoginDto loginDto, ITokenService tokenService) 
        {   
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username!.ToLower());

            return user == null ? null : new AccountDto {
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            };
        }

        public bool CheckPassword(string password, byte[] pwSalt, byte[] pwHash)
        {
            var correct = true;

            using var hmac = new HMACSHA512(pwSalt); //passes the salt to hmac

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != pwHash[i]) 
                    correct = false;
            }

            return correct;
        }

        public async Task<bool> UserExists(string username) 
        {
            return await dbContext.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower()); //Bob != bob 
        }
    }
}


