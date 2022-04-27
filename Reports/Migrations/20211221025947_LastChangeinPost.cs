using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reports.Migrations
{
    public partial class LastChangeinPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Post",
                newName: "DateTimeLastChange");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeLastChange",
                table: "Post",
                newName: "DateTime");
        }
    }
}
