using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaOrderingManagementSystem.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Crust = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVeg = table.Column<bool>(type: "bit", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true),
                    DeliveryCharge = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UEmailNavigationEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UEmailNavigationEmail",
                        column: x => x.UEmailNavigationEmail,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orderdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    PizzaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderdetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orderdetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orderdetails_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemdetails",
                columns: table => new
                {
                    OrderDetailsId = table.Column<int>(type: "int", nullable: false),
                    ToppingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemdetails", x => new { x.OrderDetailsId, x.ToppingId });
                    table.ForeignKey(
                        name: "FK_OrderItemdetails_Orderdetails_OrderDetailsId",
                        column: x => x.OrderDetailsId,
                        principalTable: "Orderdetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemdetails_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Crust", "Details", "IsVeg", "Name", "Picture", "Price", "Speciality" },
                values: new object[,]
                {
                    { 1, "Meat", null, false, "Margherita", "images/1.jfif", 20.0, "Plain" },
                    { 2, "Standart", null, true, "Cheese N Corn", "images/1.jfif", 25.0, "Cheezy" },
                    { 3, "Cheezy", null, false, "Chicken Pepperoni", "images/1.jfif", 20.0, "Spicy" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Olives", 4.0 },
                    { 2, "Tomato", 5.0 },
                    { 3, "Onion", 2.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "Address", "Name", "Password", "Phone" },
                values: new object[] { "Keeru@gmail.com", "6-Nellore", "Keerthana", "Keeru", "12345" });

            migrationBuilder.CreateIndex(
                name: "IX_Orderdetails_OrderId",
                table: "Orderdetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderdetails_PizzaId",
                table: "Orderdetails",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemdetails_ToppingId",
                table: "OrderItemdetails",
                column: "ToppingId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UEmailNavigationEmail",
                table: "Orders",
                column: "UEmailNavigationEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemdetails");

            migrationBuilder.DropTable(
                name: "Orderdetails");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
