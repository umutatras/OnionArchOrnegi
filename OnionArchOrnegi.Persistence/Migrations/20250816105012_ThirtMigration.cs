using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionArchOrnegi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ThirtMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedByUserId", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedByUserId", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "6814e094-6480-4d4c-acae-b83c7dd769f3", 1, new DateTimeOffset(new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "umut@gmail.com", true, "Umut", "Atraş", false, null, null, null, "UMUT@GMAIL.COM", "UMUT", "AQAAAAIAAYagAAAAEN/FikvJc16j6DG/h5ILOOPhBDowBJo8Iv74G/60h3LbuVa6msijvJtUgtSm6Ehj2w==", null, false, "1e2e338b-298b-40ad-a055-a2a68858495a", false, "umut" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
