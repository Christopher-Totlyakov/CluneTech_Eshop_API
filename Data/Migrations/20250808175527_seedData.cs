using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 1L, "123", "john" },
                    { 2L, "456", "jane" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Iso2", "Iso3", "IsoName", "PhoneCode" },
                values: new object[,]
                {
                    { 1L, "BG", "BGR", "Bulgaria", "+359" },
                    { 2L, "US", "USA", "United States", "+1" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AccountId", "Age", "FirstName", "LastName", "Sex" },
                values: new object[,]
                {
                    { 1L, 1L, 30, "John", "Doe", "Male" },
                    { 2L, 2L, 28, "Jane", "Smith", "Female" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "ClientId", "CountryId", "IsMain", "Number", "Street" },
                values: new object[,]
                {
                    { 1L, "Sofia", 1L, 1L, true, "12", "Vitosha" },
                    { 2L, "New York", 2L, 2L, true, "101", "Broadway" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "ClientId", "OrderDate", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, 2.0 },
                    { 2L, 2L, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, 1.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
