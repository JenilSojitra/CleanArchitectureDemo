
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);

            // Seed data
            modelBuilder.Entity<Product>().HasData(
                new Product("Test Product 1", "Description 1", 19.99m) { Id = 1 },
                new Product("Test Product 2", "Description 2", 29.99m) { Id = 2 }
            );
        }
    }
}
