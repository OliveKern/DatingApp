using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.WebApi.Controllers
{
    public class UsersController(Logic.DataContext.ProjectDbContext dbContext) : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Logic.Entities.Base.AppUser>>> GetUsers() 
        {
            using var usersController = new Logic.Controllers.UsersController(dbContext);

            var users = await usersController.GetUsers();

            return users == null ? NotFound() : Ok(users);
        }

        [Authorize]
        [HttpGet("{id:int}")]   // /api/users/3
        public async Task<ActionResult<Logic.Entities.Base.AppUser>> GetUser(int id) 
        {
            using var usersController = new Logic.Controllers.UsersController(dbContext);

            var user = await usersController.GetUser(id);

            return user == null ? NotFound() : Ok(user);
        }
    }
}


