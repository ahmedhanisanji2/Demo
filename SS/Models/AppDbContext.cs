using Microsoft.EntityFrameworkCore;

namespace SS.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ArtPiece> artPieces { get; set; }
        public DbSet<Category> categories { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<LoyaltyCard> loyaltyCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasMany(x => x.artPieces).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerID);
            modelBuilder.Entity<Category>().HasMany(x => x.artPieces).WithMany(x => x.categories);
            modelBuilder.Entity<LoyaltyCard>().HasOne(x => x.Customer).WithOne(x => x.LoyaltyCard).HasForeignKey<LoyaltyCard>(x => x.CustomerId);

        }

    }
}
