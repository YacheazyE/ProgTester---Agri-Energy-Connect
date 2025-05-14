using Microsoft.EntityFrameworkCore;

namespace APICow.Model
{
    public class FarmDbContext : DbContext
    {
        public DbSet<Cow> Cows { get; set; }

        public FarmDbContext(DbContextOptions<FarmDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cow>()
                .Property(c => c.MilkProduction)
                .HasPrecision(5, 2);
        }
    }
}
