using Microsoft.EntityFrameworkCore;

namespace API.Model 
{
    public class Context : DbContext 
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Position> Position { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}