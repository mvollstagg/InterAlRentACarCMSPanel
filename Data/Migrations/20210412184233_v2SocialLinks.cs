using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class v2SocialLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "aee59b9ac70678735c61476536a4b2168be8bab6ee6c3d5f817a473a0824adc830fde4129ea69c6424a2051a0d5a7c0f1d6bc7564c19a2711dd5e40061de52cb", new DateTime(2021, 4, 12, 21, 42, 31, 136, DateTimeKind.Local).AddTicks(8600), "6643c5e5c0fb4d3b9e9355921224e6e84/12/202194231PM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "SiteSettings");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "968194d09e6889ab989bc1d9a5f4f76ddda9600f011c0bb1a8ea799a82a67b7852fb533c7dc9d6cd2e5814f1b860800bac9e6b3aef3ffa5c629218c66f280718", new DateTime(2021, 4, 7, 1, 15, 39, 900, DateTimeKind.Local).AddTicks(9950), "fdd345cb606d43f29a49018c2f935a6e4/7/202111539AM" });
        }
    }
}
