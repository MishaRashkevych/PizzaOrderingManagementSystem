using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaOrderingManagementSystem.ViewModel;

namespace PizzaOrderingManagementSystem.Models
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> Orderdetails { get; set; }
        public DbSet<OrderItemDetail> OrderItemdetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItemDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderDetailsId, e.ToppingId });
            });

            modelBuilder.Entity<User>().HasData(new User() { Email = "Keeru@gmail.com", Name = "Keerthana", Password = "Keeru", Address = "6-Nellore", Phone ="12345" });
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { Id = 1, Name = "Margherita", Price = 20, Speciality = "Plain", Crust = "Meat", IsVeg = false, Picture = "" },
                new Pizza() { Id = 2, Name = "Cheese N Corn", Price = 25, Speciality = "Cheezy", Crust = "Standart", IsVeg = true, Picture = "" },
                new Pizza() { Id = 3, Name = "Chicken Pepperoni", Price = 20, Speciality = "Spicy", Crust = "Cheezy", IsVeg = false, Picture = "" }
                );

            modelBuilder.Entity<Topping>().HasData(
                new Topping() { Id = 1, Name = "Olives", Price = 4 },
                new Topping() { Id = 2, Name = "Tomato", Price = 5 },
                new Topping() { Id = 3, Name = "Onion", Price = 2 }
                );
        }
    }
}
