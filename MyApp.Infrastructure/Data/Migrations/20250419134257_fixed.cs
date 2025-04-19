using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp1.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class @fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockedUsers_AspNetUsers_BlockedId",
                table: "BlockedUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockedUsers_AspNetUsers_BlockedId",
                table: "BlockedUsers",
                column: "BlockedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockedUsers_AspNetUsers_BlockedId",
                table: "BlockedUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockedUsers_AspNetUsers_BlockedId",
                table: "BlockedUsers",
                column: "BlockedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
