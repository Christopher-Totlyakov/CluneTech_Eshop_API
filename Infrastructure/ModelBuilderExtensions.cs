using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, IsoName = "Bulgaria", Iso2 = "BG", Iso3 = "BGR", PhoneCode = "+359" },
                new Country { Id = 2, IsoName = "United States", Iso2 = "US", Iso3 = "USA", PhoneCode = "+1" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Lion King", Type = "Book", Price = 25.00M },
                new Product { Id = 2, Name = "Gladiator 2", Type = "Movie", Price = 30.50M },
                new Product { Id = 3, Name = "God Of War: Ragnarok", Type = "PS5 Game", Price = 69.90M }
            );

            // Seed Accounts
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, Username = "john", PasswordHash = /* Password 123*/ "AQAAAAIAAYagAAAAEAxjKtqPXJbtPnrX32KgHbvQA5rvu2bSTYDYq2SjNEaY0mdSlALNdcCvp82YuWvmFA==" },
                new Account { Id = 2, Username = "jane", PasswordHash = /* Password 456*/ "AQAAAAIAAYagAAAAECHmQ4+S0UPAT15a3814iGf/8PbsyTJoTPkIgEDZNyPISXRP6DXfKfX8FT1+J9sRGQ==" }
            );

            // Seed Clients
            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, AccountId = 1, FirstName = "John", LastName = "Doe", Age = 30, Sex = "Male" },
                new Client { Id = 2, AccountId = 2, FirstName = "Jane", LastName = "Smith", Age = 28, Sex = "Female" }
            );

            // Seed Addresses
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, ClientId = 1, CountryId = 1, City = "Sofia", Street = "Vitosha", Number = "12", IsMain = true },
                new Address { Id = 2, ClientId = 2, CountryId = 2, City = "New York", Street = "Broadway", Number = "101", IsMain = true }
            );

            // Seed Sales
            modelBuilder.Entity<Sale>().HasData(
                new Sale { Id = 1, Quantity = 2, OrderDate = new DateTime(2023, 1, 1), ClientId = 1, ProductId = 1 },
                new Sale { Id = 2, Quantity = 1, OrderDate = new DateTime(2023, 1, 2), ClientId = 2, ProductId = 3 }
            );
        }
    }
}
