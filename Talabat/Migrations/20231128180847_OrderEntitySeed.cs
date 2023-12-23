using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Talabat.Migrations
{
    public partial class OrderEntitySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DeliveryMethods",
                columns: new[] { "Id", "Cost", "DeliveryTIme", "Description", "ShortName" },
                values: new object[,]
                {
                    { 1, 10m, "1-2 Days", "Fastest delivery time", "UPS1" },
                    { 2, 5m, "2-5 Days", "Get it within 5 days", "UPS2" },
                    { 3, 2m, "5-10 Days", "Slower but cheap", "UPS3" },
                    { 4, 0m, "1-2 Weeks", "Free! You get what you pay for", "FREE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DeliveryMethods",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
