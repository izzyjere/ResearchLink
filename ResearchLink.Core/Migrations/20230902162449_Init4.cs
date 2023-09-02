using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchLink.Core.Migrations
{
    /// <inheritdoc />
    public partial class Init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReseaechTopicId",
                table: "ResearchGap",
                newName: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchGap_DistrictId",
                table: "ResearchGap",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchGap_District_DistrictId",
                table: "ResearchGap",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResearchGap_District_DistrictId",
                table: "ResearchGap");

            migrationBuilder.DropIndex(
                name: "IX_ResearchGap_DistrictId",
                table: "ResearchGap");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                table: "ResearchGap",
                newName: "ReseaechTopicId");
        }
    }
}
