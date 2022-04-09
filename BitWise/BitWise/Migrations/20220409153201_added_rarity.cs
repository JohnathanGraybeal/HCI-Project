using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitWise.Migrations
{
    public partial class added_rarity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Trophies");

            migrationBuilder.AddColumn<int>(
                name: "Rarity",
                table: "Trophies",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rarity",
                table: "Trophies");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Trophies",
                type: "text",
                nullable: true);
        }
    }
}
