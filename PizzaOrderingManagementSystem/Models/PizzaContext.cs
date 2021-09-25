using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingManagementSystem.Models
{
    public class PizzaContext : DbContext
    {
        public PizzaContext()
        {

        }
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {
        }

        public DbSet<Register> Registers { get; set; }
        public DbSet<Login> Logins { get; set; }
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

            modelBuilder.Entity<Register>().HasData(new Register() { Email = "Keeru@gmail.com", Name = "Keerthana", Password = "Keeru", Phone =12345, Address = "6-Nellore" });
            modelBuilder.Entity<Login>().HasData(new Login() { Email = "Keeru@gmail.com",Password = "Keeru" });
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { Id = 1, Name = "Margherita", Price = 20, Speciality = "Plain", Crust = "Meat", IsVeg = false },
                new Pizza() { Id = 2, Name = "Cheese N Corn", Price = 25, Speciality = "Cheezy", Crust = "Standart", IsVeg = true },
                new Pizza() { Id = 3, Name = "Chicken Pepperoni", Price = 20, Speciality = "Spicy", Crust = "Cheezy", IsVeg = false }
                );

            modelBuilder.Entity<Topping>().HasData(
                new Topping() { Id = 1, Name = "Olives", Price = 4 },
                new Topping() { Id = 2, Name = "Tomato", Price = 5 },
                new Topping() { Id = 3, Name = "Onion", Price = 2 }
                );
        }
    }
}
