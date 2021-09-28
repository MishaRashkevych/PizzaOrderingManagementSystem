using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaOrderingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingManagementSystem.ViewModel
{
    public class CartItem
    {
        public CartItem()
        {
        }
        public CartItem(Pizza pizza, IEnumerable<Topping> toppings, int orderDetailsId)
        {
            this.Pizza = pizza;
            this.Toppings = toppings;
            this.OrderDetailsId = orderDetailsId;
        }

        public int OrderDetailsId { get; set; }
        public Pizza Pizza { get; set; }
        public IEnumerable<Topping> Toppings { get; set; }

        public IList<SelectListItem> SelectedToppings { get; set; } = new List<SelectListItem>();
    }
}
