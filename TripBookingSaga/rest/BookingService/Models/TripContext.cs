using Microsoft.EntityFrameworkCore;

namespace BookingService.Models
{
    public class TripContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        public string DbPath { get; }

        public TripContext()
        {
            DbPath = System.IO.Path.Join("trip.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}