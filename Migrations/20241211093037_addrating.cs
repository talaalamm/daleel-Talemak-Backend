using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolsProject.Migrations
{
    /// <inheritdoc />
    public partial class addrating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRatings",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Schools");

            migrationBuilder.AlterColumn<string>(
                name: "CommentBody",
                table: "SchoolComments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "CommentBody",
                table: "SchoolComments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
