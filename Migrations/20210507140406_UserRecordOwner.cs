using Microsoft.EntityFrameworkCore.Migrations;

namespace FizzBuzzNET.Migrations
{
    public partial class UserRecordOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecordUserId",
                table: "FizzBuzzRecords",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FizzBuzzRecords_RecordUserId",
                table: "FizzBuzzRecords",
                column: "RecordUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FizzBuzzRecords_AspNetUsers_RecordUserId",
                table: "FizzBuzzRecords",
                column: "RecordUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FizzBuzzRecords_AspNetUsers_RecordUserId",
                table: "FizzBuzzRecords");

            migrationBuilder.DropIndex(
                name: "IX_FizzBuzzRecords_RecordUserId",
                table: "FizzBuzzRecords");

            migrationBuilder.DropColumn(
                name: "RecordUserId",
                table: "FizzBuzzRecords");
        }
    }
}
