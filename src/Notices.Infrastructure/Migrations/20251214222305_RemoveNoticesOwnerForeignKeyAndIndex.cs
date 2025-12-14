using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notices.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNoticesOwnerForeignKeyAndIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notices_Users_OwnerId",
                table: "Notices");

            migrationBuilder.DropIndex(
                name: "IX_Notices_OwnerId",
                table: "Notices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Notices_OwnerId",
                table: "Notices",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_Users_OwnerId",
                table: "Notices",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
