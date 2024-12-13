using System;
using System.Reflection.Metadata.Ecma335;
using DatingApp.Logic.DataContext;
using DatingApp.Logic.Entities.Base;

namespace DatingApp.Logic.Controllers;

public class BuggsController(ProjectDbContext dbContext) : GenericController<AppUser>
{
    public AppUser? GetNotFound() 
    {
        var thing = dbContext.Users.Find(-1);

        return thing;
    }

    public AppUser? GetServerError()
    {
        var thing = dbContext.Users.Find(-1);

        return thing;
    }

}
