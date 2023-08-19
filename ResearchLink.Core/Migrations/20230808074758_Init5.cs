using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchLink.Core.Migrations
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Volume_VolumeId",
                table: "Article");

            migrationBuilder.AlterColumn<Guid>(
                name: "VolumeId",
                table: "Article",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Volume_VolumeId",
                table: "Article",
                column: "VolumeId",
                principalTable: "Volume",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Volume_VolumeId",
                table: "Article");

            migrationBuilder.AlterColumn<Guid>(
                name: "VolumeId",
                table: "Article",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Volume_VolumeId",
                table: "Article",
                column: "VolumeId",
                principalTable: "Volume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
