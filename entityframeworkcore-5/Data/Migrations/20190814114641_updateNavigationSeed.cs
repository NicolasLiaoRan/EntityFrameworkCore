using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateNavigationSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "ProvinceId", "Name", "Population" },
                values: new object[] { 2, "重庆市", 8000000 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "AreaCode", "Name", "ProvinceId" },
                values: new object[] { 1, null, "渝北区", 2 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "AreaCode", "Name", "ProvinceId" },
                values: new object[] { 2, null, "沙坪坝区", 2 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "AreaCode", "Name", "ProvinceId" },
                values: new object[] { 3, null, "江北区", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "ProvinceId",
                keyValue: 2);
        }
    }
}
