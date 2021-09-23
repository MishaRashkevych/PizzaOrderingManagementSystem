using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingManagementSystem.Models
{
    public class PizzaContext
    {
        public PizzaContext()
        {

        }
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {


        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<order> Orders { get; set; }
        public DbSet<Orderdetail> Orderdetails { get; set; }
        public DbSet<OrderItemdetail> OrderItemdetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User() { UserEmail = "Keeru@gmail.com", Name = "Keerthana", Password = "Keeru", Address = "6-Nellore", Phone =12345 });
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { PizzaNumber = 1, Name = "Margherita", Price = 20, Type = "Plain" },
                new Pizza() { PizzaNumber = 2, Name = "Cheese N Corn", Price = 25, Type = "Cheezy" },
                new Pizza() { PizzaNumber = 3, Name = "Chicken Pepperoni", Price = 20, Type = "Spicy" }

                );
            modelBuilder.Entity<Topping>().HasData(
                new Topping() { ToppingNumber = 1, Name = "Olives", Price = 4 },
                new Topping() { ToppingNumber = 2, Name = "Tomato", Price = 5 },
                new Topping() { ToppingNumber = 3, Name = "Onion", Price = 2 }
                );
        }
    }
}
