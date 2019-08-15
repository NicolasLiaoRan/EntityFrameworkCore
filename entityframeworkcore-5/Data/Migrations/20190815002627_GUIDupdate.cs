using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class GUIDupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("57f436d1-c85a-41a8-839b-5545d8fdea0f"));

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6def51c0-05e8-443b-a5a3-9d5037615713"), "廖然1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("6def51c0-05e8-443b-a5a3-9d5037615713"));

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("57f436d1-c85a-41a8-839b-5545d8fdea0f"), "廖然" });
        }
    }
}
