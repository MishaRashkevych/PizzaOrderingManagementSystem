using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaOrderingManagementSystem.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Picture",
                value: "/images/pizza1.jpg");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Picture",
                value: "/images/pizza2.jpg");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Picture",
                value: "/images/pizza3.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Picture",
                value: ".wwwroot/images/pizza1.jpg");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Picture",
                value: ".wwwroot/images/pizza2.jpg");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Picture",
                value: ".wwwroot/images/pizza3.jpg");
        }
    }
}
