using System.Reflection;
using Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure;

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

        modelBuilder.Seed();
    }
}
