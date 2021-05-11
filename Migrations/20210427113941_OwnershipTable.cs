using Microsoft.EntityFrameworkCore.Migrations;

namespace FizzBuzzNET.Migrations
{
    public partial class OwnershipTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FizzBuzzOwnership",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FizzBuzzRecordsID = table.Column<int>(type: "INTEGER", nullable: true),
                    ASPNETUsersId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FizzBuzzOwnership", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FizzBuzzOwnership_AspNetUsers_ASPNETUsersId",
                        column: x => x.ASPNETUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FizzBuzzOwnership_FizzBuzzRecords_FizzBuzzRecordsID",
                        column: x => x.FizzBuzzRecordsID,
                        principalTable: "FizzBuzzRecords",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FizzBuzzOwnership_ASPNETUsersId",
                table: "FizzBuzzOwnership",
                column: "ASPNETUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_FizzBuzzOwnership_FizzBuzzRecordsID",
                table: "FizzBuzzOwnership",
                column: "FizzBuzzRecordsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FizzBuzzOwnership");
        }
    }
}
