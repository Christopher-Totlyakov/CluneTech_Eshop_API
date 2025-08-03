using System.Reflection;
using Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Database
/// </summary>
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options)
       : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Optional: seed example
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Lion King", Type = "Book", Price = 25.00M },
            new Product { Id = 2, Name = "Gladiator 2", Type = "Movie", Price = 30.50M },
            new Product { Id = 3, Name = "God Of War: Ragnarok", Type = "PS5 Game", Price = 69.90M }
        );
    }
}
