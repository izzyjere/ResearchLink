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
            migrationBuilder.DropColumn(
                name: "ResearchMethod",
                table: "ResearchGap");

            migrationBuilder.DropColumn(
                name: "ResearchQuestion",
                table: "ResearchGap");

            migrationBuilder.RenameColumn(
                name: "Pages",
                table: "Research",
                newName: "ResearchMethod");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Research",
                newName: "Abstract");

            migrationBuilder.AddColumn<Guid>(
                name: "ReseaechTopicId",
                table: "ResearchGap",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResearchTopicId",
                table: "ResearchGap",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResearchGapId",
                table: "Research",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResearchGap_ResearchTopicId",
                table: "ResearchGap",
                column: "ResearchTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Research_ResearchGapId",
                table: "Research",
                column: "ResearchGapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Research_ResearchGap_ResearchGapId",
                table: "Research",
                column: "ResearchGapId",
                principalTable: "ResearchGap",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchGap_ResearchTopic_ResearchTopicId",
                table: "ResearchGap",
                column: "ResearchTopicId",
                principalTable: "ResearchTopic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Research_ResearchGap_ResearchGapId",
                table: "Research");

            migrationBuilder.DropForeignKey(
                name: "FK_ResearchGap_ResearchTopic_ResearchTopicId",
                table: "ResearchGap");

            migrationBuilder.DropIndex(
                name: "IX_ResearchGap_ResearchTopicId",
                table: "ResearchGap");

            migrationBuilder.DropIndex(
                name: "IX_Research_ResearchGapId",
                table: "Research");

            migrationBuilder.DropColumn(
                name: "ReseaechTopicId",
                table: "ResearchGap");

            migrationBuilder.DropColumn(
                name: "ResearchTopicId",
                table: "ResearchGap");

            migrationBuilder.DropColumn(
                name: "ResearchGapId",
                table: "Research");

            migrationBuilder.RenameColumn(
                name: "ResearchMethod",
                table: "Research",
                newName: "Pages");

            migrationBuilder.RenameColumn(
                name: "Abstract",
                table: "Research",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "ResearchMethod",
                table: "ResearchGap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResearchQuestion",
                table: "ResearchGap",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
