using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogPostsAPI.Migrations
{
    public partial class Addedseparatetableforblogposts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_Users_UserId",
                table: "BlogPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPost",
                table: "BlogPost");

            migrationBuilder.RenameTable(
                name: "BlogPost",
                newName: "BlogPosts");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPost_UserId",
                table: "BlogPosts",
                newName: "IX_BlogPosts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Users_UserId",
                table: "BlogPosts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Users_UserId",
                table: "BlogPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPosts",
                table: "BlogPosts");

            migrationBuilder.RenameTable(
                name: "BlogPosts",
                newName: "BlogPost");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPosts_UserId",
                table: "BlogPost",
                newName: "IX_BlogPost_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPost",
                table: "BlogPost",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_Users_UserId",
                table: "BlogPost",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
