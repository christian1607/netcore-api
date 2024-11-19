using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCourseRequiredCourseAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Courses_RequiredCourseId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_RequiredCourseId",
                table: "Courses");

            migrationBuilder.AlterColumn<Guid>(
                name: "RequiredCourseId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RequiredCourseId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_RequiredCourseId",
                table: "Courses",
                column: "RequiredCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Courses_RequiredCourseId",
                table: "Courses",
                column: "RequiredCourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
