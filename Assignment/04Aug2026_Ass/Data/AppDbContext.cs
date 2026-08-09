using _04Aug2026_Ass.Models;
using Microsoft.EntityFrameworkCore;

namespace _04Aug2026_Ass.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }
    }
}
