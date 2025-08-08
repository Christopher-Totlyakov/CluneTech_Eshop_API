using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class setHashedPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEAxjKtqPXJbtPnrX32KgHbvQA5rvu2bSTYDYq2SjNEaY0mdSlALNdcCvp82YuWvmFA==");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2L,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECHmQ4+S0UPAT15a3814iGf/8PbsyTJoTPkIgEDZNyPISXRP6DXfKfX8FT1+J9sRGQ==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: "123");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2L,
                column: "PasswordHash",
                value: "456");
        }
    }
}
