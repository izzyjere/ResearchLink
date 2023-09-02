using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchLink.Core.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ResearchGap_ResearchId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Research_ResearchId",
                table: "Comment");

            migrationBuilder.DropTable(
                name: "CommentReplies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "ResearchGapComment");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ResearchId",
                table: "ResearchGapComment",
                newName: "IX_ResearchGapComment_ResearchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResearchGapComment",
                table: "ResearchGapComment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ResearchComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResearchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchComment_Research_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Research",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResearchGapCommentReplies",
                columns: table => new
                {
                    ResearchGapCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchGapCommentReplies", x => new { x.ResearchGapCommentId, x.Id });
                    table.ForeignKey(
                        name: "FK_ResearchGapCommentReplies_ResearchGapComment_ResearchGapCommentId",
                        column: x => x.ResearchGapCommentId,
                        principalTable: "ResearchGapComment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchCommentReplies",
                columns: table => new
                {
                    ResearchCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchCommentReplies", x => new { x.ResearchCommentId, x.Id });
                    table.ForeignKey(
                        name: "FK_ResearchCommentReplies_ResearchComment_ResearchCommentId",
                        column: x => x.ResearchCommentId,
                        principalTable: "ResearchComment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResearchComment_ResearchId",
                table: "ResearchComment",
                column: "ResearchId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchGapComment_ResearchGap_ResearchId",
                table: "ResearchGapComment",
                column: "ResearchId",
                principalTable: "ResearchGap",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResearchGapComment_ResearchGap_ResearchId",
                table: "ResearchGapComment");

            migrationBuilder.DropTable(
                name: "ResearchCommentReplies");

            migrationBuilder.DropTable(
                name: "ResearchGapCommentReplies");

            migrationBuilder.DropTable(
                name: "ResearchComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResearchGapComment",
                table: "ResearchGapComment");

            migrationBuilder.RenameTable(
                name: "ResearchGapComment",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_ResearchGapComment_ResearchId",
                table: "Comment",
                newName: "IX_Comment_ResearchId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CommentReplies",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReplies", x => new { x.CommentId, x.Id });
                    table.ForeignKey(
                        name: "FK_CommentReplies_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ResearchGap_ResearchId",
                table: "Comment",
                column: "ResearchId",
                principalTable: "ResearchGap",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Research_ResearchId",
                table: "Comment",
                column: "ResearchId",
                principalTable: "Research",
                principalColumn: "Id");
        }
    }
}
