using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogPostsAPI.Migrations
{
    public partial class AddedLocationToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "users");
        }
    }
}
