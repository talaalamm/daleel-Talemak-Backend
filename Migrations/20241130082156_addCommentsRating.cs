using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolsProject.Migrations
{
    /// <inheritdoc />
    public partial class addCommentsRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfRatings",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Schools",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRatings",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Schools");
        }
    }
}
