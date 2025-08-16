using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionArchOrnegi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreatedUSerIdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "Users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b621cca-3ea3-4705-ac61-47f500fb1115", "AQAAAAIAAYagAAAAEA+KBn4JcCAvbcq2YfvdH2KzJCS83TPdGmym5iSf+BbLaMNsiSX1sbu4IzrOwsypxQ==", "f1e46361-f61a-4f28-af29-1b52dbac3db4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatedByUserId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6814e094-6480-4d4c-acae-b83c7dd769f3", "AQAAAAIAAYagAAAAEN/FikvJc16j6DG/h5ILOOPhBDowBJo8Iv74G/60h3LbuVa6msijvJtUgtSm6Ehj2w==", "1e2e338b-298b-40ad-a055-a2a68858495a" });
        }
    }
}
