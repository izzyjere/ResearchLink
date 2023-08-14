using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchLink.Core.Migrations
{
    /// <inheritdoc />
    public partial class Init9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Publisher");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Publisher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Publisher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Publisher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Publisher",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
