using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BitWise.Migrations.CoursesDb
{
    public partial class CourseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseNames = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    Topic = table.Column<string>(type: "text", nullable: false),
                    CourseNameId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseTopics_CourseNames_CourseNameId",
                        column: x => x.CourseNameId,
                        principalTable: "CourseNames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TopicDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TopicId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CourseTopicsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicDescriptions_CourseTopics_CourseTopicsId",
                        column: x => x.CourseTopicsId,
                        principalTable: "CourseTopics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TopicImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TopicId = table.Column<int>(type: "integer", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    CourseTopicsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicImages_CourseTopics_CourseTopicsId",
                        column: x => x.CourseTopicsId,
                        principalTable: "CourseTopics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTopics_CourseNameId",
                table: "CourseTopics",
                column: "CourseNameId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicDescriptions_CourseTopicsId",
                table: "TopicDescriptions",
                column: "CourseTopicsId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicImages_CourseTopicsId",
                table: "TopicImages",
                column: "CourseTopicsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicDescriptions");

            migrationBuilder.DropTable(
                name: "TopicImages");

            migrationBuilder.DropTable(
                name: "CourseTopics");

            migrationBuilder.DropTable(
                name: "CourseNames");
        }
    }
}
