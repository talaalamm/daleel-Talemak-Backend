using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolsProject.Migrations
{
    /// <inheritdoc />
    public partial class addcommentbody : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentBody",
                table: "SchoolComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentBody",
                table: "SchoolComments");
        }
    }
}
