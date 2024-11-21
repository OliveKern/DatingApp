using Microsoft.EntityFrameworkCore;

namespace DatingApp.Logic.DataContext
{
    // Cannot be named like the folder!
    public class ProjectDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Logic.Entities.Base.AppUser> Users { get; set; }
    }
}
