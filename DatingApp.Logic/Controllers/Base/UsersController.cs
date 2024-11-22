using DatingApp.Logic.DataContext;
using Microsoft.EntityFrameworkCore;
using DatingApp.Logic.Entities.Base;

namespace DatingApp.Logic.Controllers
{
    public class UsersController(ProjectDbContext dbContext) : ControllerObject
    {

        public async Task<IEnumerable<AppUser>?> GetUsers() 
        {
            var users = await dbContext.Users.ToListAsync();

            return users;
        }

        public async Task<AppUser?> GetUser(int id) 
        {
            var user = await dbContext.Users.FindAsync(id);

            return user;
        }
    }
}


