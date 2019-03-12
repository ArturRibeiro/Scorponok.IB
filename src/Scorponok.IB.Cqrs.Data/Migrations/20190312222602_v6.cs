using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scorponok.IB.Cqrs.Data.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_Member_Id",
                table: "Contribution");

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "Contribution",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Contribution_MemberId",
                table: "Contribution",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contribution_Member_MemberId",
                table: "Contribution",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_Member_MemberId",
                table: "Contribution");

            migrationBuilder.DropIndex(
                name: "IX_Contribution_MemberId",
                table: "Contribution");

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
    }
}
