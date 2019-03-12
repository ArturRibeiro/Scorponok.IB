using Microsoft.EntityFrameworkCore.Migrations;

namespace Scorponok.IB.Cqrs.Data.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Contribution");

            migrationBuilder.AddForeignKey(
                name: "FK_Contribution_Member_Id",
                table: "Contribution",
                column: "Id",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_Member_Id",
                table: "Contribution");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Contribution",
                nullable: false,
                defaultValue: 0);
        }
    }
}
