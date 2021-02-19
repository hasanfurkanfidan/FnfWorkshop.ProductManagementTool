using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addedSeriLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "Urgency",
                table: "Logs",
                newName: "MessageTemplate");

            migrationBuilder.RenameColumn(
                name: "Detail",
                table: "Logs",
                newName: "Level");

            migrationBuilder.AddColumn<string>(
                name: "Exception",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "TimeStamp",
                table: "Logs",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exception",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "MessageTemplate",
                table: "Logs",
                newName: "Urgency");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Logs",
                newName: "Detail");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
