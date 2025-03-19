using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolsProject.Migrations
{
    /// <inheritdoc />
    public partial class addrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GovernorateId",
                table: "Regions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_RegionId",
                table: "Schools",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_GovernorateId",
                table: "Regions",
                column: "GovernorateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Governorates_GovernorateId",
                table: "Regions",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "GovernorateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Regions_RegionId",
                table: "Schools",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Governorates_GovernorateId",
                table: "Regions");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Regions_RegionId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_RegionId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Regions_GovernorateId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "GovernorateId",
                table: "Regions");
        }
    }
}
