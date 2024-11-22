
using System.Security.Cryptography;
using System.Text;
using DatingApp.Logic.Contracts;
using DatingApp.Logic.Controllers.Account;
using DatingApp.Logic.DataContext;
using DatingApp.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.WebApi.Controllers
{
    public class AccountController(ProjectDbContext dbContext) : BaseApiController
    {
        [HttpPost("register")] //account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto, ITokenService tokenService)     //FromQuery, FromBody, etc. tell the http service where to loog for the param data
        {
            using var accountsCtrl = new AccountsController(dbContext);
            
            if(await accountsCtrl.UserExists(registerDto.Username)) return BadRequest("Username is already taken");

            var userDto = accountsCtrl.Register(registerDto, tokenService);

            return Ok(userDto);   
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto, ITokenService tokenService) 
        {
            using var accountsCtrl = new AccountsController(dbContext);

            var account = await accountsCtrl.Login(loginDto, tokenService);
            if(account == null) 
                return NotFound("Invalid username");

            var pwCorrect = accountsCtrl.CheckPassword(loginDto.Password, account.PasswordSalt, account.PasswordHash);
            if(pwCorrect == false) 
                return NotFound("Invalid password");

            return Ok(new UserDto {
                Username = account.UserName,
                Token = tokenService.ProvideToken(account)
            });
        }
    }
}

