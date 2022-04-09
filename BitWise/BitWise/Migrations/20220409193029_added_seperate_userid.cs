using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitWise.Migrations
{
    public partial class added_seperate_userid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trophies_AspNetUsers_BitWiseUserId",
                table: "Trophies");

            migrationBuilder.AlterColumn<string>(
                name: "BitWiseUserId",
                table: "Trophies",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trophies_AspNetUsers_BitWiseUserId",
                table: "Trophies",
                column: "BitWiseUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trophies_AspNetUsers_BitWiseUserId",
                table: "Trophies");

            migrationBuilder.AlterColumn<string>(
                name: "BitWiseUserId",
                table: "Trophies",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Trophies_AspNetUsers_BitWiseUserId",
                table: "Trophies",
                column: "BitWiseUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
