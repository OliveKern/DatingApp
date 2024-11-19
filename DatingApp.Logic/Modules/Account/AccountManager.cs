using System;
using System.Security.Cryptography;
using System.Text;
using DatingApp.Logic.Contracts;
using DatingApp.Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Logic.Modules.Account;

    public class AccountManager(Logic.DataContext.ProjectDbContext dbContext)
    {
    }
