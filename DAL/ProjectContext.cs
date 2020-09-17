using Microsoft.EntityFrameworkCore;
using TestGreenAtom.Models;

namespace TestGreenAtom.DAL
{
    public class ProjectContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
