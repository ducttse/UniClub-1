using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniClub.Infrastructure.Migrations
{
    public partial class Add_EmailClubAdmin_For_Club : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberRole_ClubRole",
                table: "MemberRole");

            migrationBuilder.DropTable(
                name: "ClubRole");

            migrationBuilder.DropIndex(
                name: "IX_MemberRole_ClubRoleId",
                table: "MemberRole");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Club",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Club");

            migrationBuilder.CreateTable(
                name: "ClubRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportToRoleId = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, collation: "SQL_Latin1_General_CP1_CI_AI")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubRole_ClubRole",
                        column: x => x.ReportToRoleId,
                        principalTable: "ClubRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberRole_ClubRoleId",
                table: "MemberRole",
                column: "ClubRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubRole_ReportToRoleId",
                table: "ClubRole",
                column: "ReportToRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberRole_ClubRole",
                table: "MemberRole",
                column: "ClubRoleId",
                principalTable: "ClubRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
