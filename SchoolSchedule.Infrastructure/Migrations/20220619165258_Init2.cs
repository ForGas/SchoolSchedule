using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSchedule.Infrastructure.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EducationalClassId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EducationalClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalClasses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_EducationalClassId",
                table: "Students",
                column: "EducationalClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_EducationalClasses_EducationalClassId",
                table: "Students",
                column: "EducationalClassId",
                principalTable: "EducationalClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_EducationalClasses_EducationalClassId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "EducationalClasses");

            migrationBuilder.DropIndex(
                name: "IX_Students_EducationalClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EducationalClassId",
                table: "Students");
        }
    }
}
