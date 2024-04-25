using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Migrations
{
    /// <inheritdoc />
    public partial class borrow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRequests_AspNetUsers_UserId",
                table: "BorrowRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRequests_Books_BookId",
                table: "BorrowRequests");

            migrationBuilder.DropIndex(
                name: "IX_BorrowRequests_BookId",
                table: "BorrowRequests");

            migrationBuilder.DropIndex(
                name: "IX_BorrowRequests_UserId",
                table: "BorrowRequests");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BorrowRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "BorrowRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "BorrowRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "BorrowRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "BorrowRequests");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "BorrowRequests");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "BorrowRequests");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BorrowRequests",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRequests_BookId",
                table: "BorrowRequests",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRequests_UserId",
                table: "BorrowRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRequests_AspNetUsers_UserId",
                table: "BorrowRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRequests_Books_BookId",
                table: "BorrowRequests",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
