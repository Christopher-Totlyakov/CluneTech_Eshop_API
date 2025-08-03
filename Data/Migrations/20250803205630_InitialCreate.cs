using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Primary key of the account.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Username for login."),
                    PasswordHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Hashed password used for secure login.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                },
                comment: "Represents a user account used for authentication.");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Primary key of the country.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsoName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Official ISO name of the country."),
                    Iso2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false, comment: "2-letter ISO code."),
                    Iso3 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, comment: "3-letter ISO code."),
                    PhoneCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "International phone code")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                },
                comment: "Represents a country, including ISO codes and phone code.");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Primary key of the product.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Name of the product."),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Type or category of the product."),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of the product in the applicable currency.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                },
                comment: "Represents a product available for sale.");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Primary key of the client.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<long>(type: "bigint", nullable: false, comment: "Foreign key referencing the related account."),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Client's first name."),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Client's last name."),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Client's age."),
                    Sex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Client's gender (e.g., Male, Female, Other).")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Represents a client who can place orders.");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Primary key of the address.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(type: "bigint", nullable: false, comment: "Foreign key referencing the client."),
                    CountryId = table.Column<long>(type: "bigint", nullable: false, comment: "Foreign key referencing the country."),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "City where the address is located."),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Street name of the address."),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Street number or apartment number."),
                    IsMain = table.Column<bool>(type: "bit", nullable: false, comment: "Indicates whether this is the client's main address.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Represents a physical address associated with a client.");

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Primary key of the sale.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false, comment: "Quantity of the product sold."),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the order was placed.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Represents a product sale made by a client.");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1L, "Lion King", 25.00m, "Book" },
                    { 2L, "Gladiator 2", 30.50m, "Movie" },
                    { 3L, "God Of War: Ragnarok", 69.90m, "PS5 Game" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ClientId",
                table: "Addresses",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AccountId",
                table: "Clients",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ClientId",
                table: "Sales",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
