﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaOrderingManagementSystem.Models;

namespace PizzaOrderingManagementSystem.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20210923144219_initMigration")]
    partial class initMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaOrderingManagementSystem.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("DeliveryCharge")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Total")
                        .HasColumnType("float");

                    b.Property<string>("UEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UEmailNavigationEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UEmailNavigationEmail");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaOrderingManagementSystem.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("Orderdetails");
                });

            modelBuilder.Entity("PizzaOrderingManagementSystem.Models.OrderItemDetail", b =>
                {
                    b.Property<int>("OrderDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("ToppingId")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailsId", "ToppingId");

                    b.HasIndex("ToppingId");

                    b.ToTable("OrderItemdetails");
                });

            modelBuilder.Entity("PizzaOrderingManagementSystem.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Crust")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVeg")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Speciality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Crust = "Meat",
                            IsVeg = false,
                            Name = "Margherita",
                            Price = 20.0,
                            Speciality = "Plain"
                        },
                        new
                        {
                            Id = 2,
                            Crust = "Standart",
                            IsVeg = true,
                            Name = "Cheese N Corn",
                            Price = 25.0,
                            Speciality = "Cheezy"
                        },
                        new
                        {
                            Id = 3,
                            Crust = "Cheezy",
                            IsVeg = false,
                            Name = "Chicken Pepperoni",
                            Price = 20.0,
                            Speciality = "Spicy"
                        });
                });

            modelBuilder.Entity("PizzaOrderingManagementSystem.Models.Topping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Toppings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Olives",
                            Price = 4.0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tomato",
                            Price = 5.0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Onion",
                            Price = 2.0
                        });
                });

            modelBuilder.Entity("PizzaOrderingManagementSystem.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Email = "Keeru@gmail.com",
                            Address = "6-Nellore",
                            Name = "Keerthana",
                            Password = "Keeru",
                            Phone = "12345"
                        });
                });

            modelBuilder.Entity("PizzaOrderingManagementSystem.Models.Order", b =>
                {
                    b.HasOne("PizzaOrderingManagementSystem.Models.User", "UEmailNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("UEmailNavigationEmail");

                    b.Navigation("UEmailNavigation");
                });

            modelBuilder.Entity("PizzaOrderingManagementSystem.Models.OrderDetail", b =>
                {
                    b.HasOne("PizzaOrderingManagementSystem.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId");

                    b.HasOne("PizzaOrderingManagementSystem.Models.Pizza", "Pizza")
                        .WithMany("OrderDetails")
                        .HasForeignKey("PizzaId");

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzaOrderingManagementSystem.Models.OrderItemDetail", b =>
                {
                    b.HasOne("PizzaOrderingManagementSystem.Models.OrderDetail", "OrderDetails")
                        .WithMany("OrderItemDetails")
                        .HasForeignKey("OrderDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaOrderingManagementSystem.Models.Topping", "Topping")
                        .WithMany("OrderItemDetails")
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderDetails");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("PizzaOrderingManagementSystem.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("PizzaOrderingManagementSystem.Models.OrderDetail", b =>
                {
                    b.Navigation("OrderItemDetails");
                });

            modelBuilder.Entity("PizzaOrderingManagementSystem.Models.Pizza", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("PizzaOrderingManagementSystem.Models.Topping", b =>
                {
                    b.Navigation("OrderItemDetails");
                });

            modelBuilder.Entity("PizzaOrderingManagementSystem.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
