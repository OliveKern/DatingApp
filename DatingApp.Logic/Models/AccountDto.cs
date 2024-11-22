using System;

namespace DatingApp.Logic.Models
{
    public class AccountDto
    {
        public required string UserName { get; set; }

        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
    }
}


