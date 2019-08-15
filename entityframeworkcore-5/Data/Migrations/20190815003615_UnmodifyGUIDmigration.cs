using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UnmodifyGUIDmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("57f436d1-c85a-41a8-839b-5545d8fdea0f"),
                column: "Name",
                value: "廖然2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("57f436d1-c85a-41a8-839b-5545d8fdea0f"),
                column: "Name",
                value: "廖然1");
        }
    }
}
