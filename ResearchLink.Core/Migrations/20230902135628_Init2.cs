using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchLink.Core.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
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

            migrationBuilder.AlterColumn<Guid>(
                name: "ResearchId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ResearchGap_ResearchId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Research_ResearchId",
                table: "Comment");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResearchId",
                table: "Comment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ResearchGap_ResearchId",
                table: "Comment",
                column: "ResearchId",
                principalTable: "ResearchGap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Research_ResearchId",
                table: "Comment",
                column: "ResearchId",
                principalTable: "Research",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
