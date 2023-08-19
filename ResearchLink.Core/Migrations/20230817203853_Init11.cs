using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchLink.Core.Migrations
{
    /// <inheritdoc />
    public partial class Init11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Article");

            migrationBuilder.CreateTable(
                name: "ArticleDocuments",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileStore = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleDocuments", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_ArticleDocuments_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleDocuments");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Article",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: false,
                defaultValue: "");
        }
    }
}
