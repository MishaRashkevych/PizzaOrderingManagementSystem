using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaOrderingManagementSystem.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Picture",
                value: "/images/1.jfif");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Picture",
                value: "/images/2.jfif");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Picture",
                value: "/images/3.jfif");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Picture",
                value: "~/images/1.jfif");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Picture",
                value: "~/images/2.jfif");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Picture",
                value: "~/images/3.jfif");
        }
    }
}
