using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
