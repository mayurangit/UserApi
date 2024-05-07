using Microsoft.EntityFrameworkCore;
using UserApiApp.Model;

namespace UserApiApp.Data
{
	public class APIDbContext : DbContext 
	{
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
