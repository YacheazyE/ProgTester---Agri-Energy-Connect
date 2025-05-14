using APIFarm.Models;
using Microsoft.EntityFrameworkCore;

namespace APIFarm.Model
{
    public class FarmDbContext : DbContext
    {
        public DbSet<Farm> Farms { get; set; }

        public FarmDbContext(DbContextOptions<FarmDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Farm>()
                .Property(c => c.FarmID)
                .HasPrecision(5, 2);
        }
    }
}
