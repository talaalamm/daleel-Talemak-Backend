using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolsProject.Migrations
{
    /// <inheritdoc />
    public partial class addcommenttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolComments",
                columns: table => new
                {
                    SchoolCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolComments", x => x.SchoolCommentId);
                    table.ForeignKey(
                        name: "FK_SchoolComments_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolComments_SchoolId",
                table: "SchoolComments",
                column: "SchoolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolComments");
        }
    }
}
