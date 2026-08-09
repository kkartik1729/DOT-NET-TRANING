using _08Aug2026_Ass.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace _08Aug2026_Ass.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Batch> Batches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One Batch -> Many Students
            modelBuilder.Entity<Batch>()
                .HasMany(b => b.Students)
                .WithOne(s => s.Batch)
                .HasForeignKey(s => s.BatchId)
                .OnDelete(DeleteBehavior.Restrict);

            // One Teacher -> Many Courses
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many Students <-> Many Courses (implicit join table "StudentCourses")
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentCourses",
                    j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
                    j =>
                    {
                        j.HasKey("StudentId", "CourseId");
                        j.ToTable("StudentCourses");
                    });

            // Unique email constraints (optional but sensible)
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();

            modelBuilder.Entity<Teacher>()
                .HasIndex(t => t.Email)
                .IsUnique();
        }
    }
}