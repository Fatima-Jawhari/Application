using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp1.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadeDeleteOnBlockedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockedUsers_AspNetUsers_BlockerId",
                table: "BlockedUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockedUsers_AspNetUsers_BlockerId",
                table: "BlockedUsers",
                column: "BlockerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockedUsers_AspNetUsers_BlockerId",
                table: "BlockedUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockedUsers_AspNetUsers_BlockerId",
                table: "BlockedUsers",
                column: "BlockerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
