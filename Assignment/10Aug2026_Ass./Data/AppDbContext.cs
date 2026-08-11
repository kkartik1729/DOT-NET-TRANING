using _10Aug2026.Models;
using Microsoft.EntityFrameworkCore;

namespace _10Aug2026.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Passenger> Passengers => Set<Passenger>();

        public DbSet<State> States => Set<State>();

        public DbSet<Bus> Buses => Set<Bus>();

        public DbSet<Booking> Bookings => Set<Booking>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Passenger)
                .WithMany()
                .HasForeignKey(b => b.PassengerId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Bus)
                .WithMany()
                .HasForeignKey(b => b.BusId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.State)
                .WithMany()
                .HasForeignKey(b => b.StateId);

            modelBuilder.Entity<Booking>()
                .HasIndex(b => new
                {
                    b.BusId,
                    b.TravelDate,
                    b.SeatNumber
                })
                .IsUnique();
        }
    }
}