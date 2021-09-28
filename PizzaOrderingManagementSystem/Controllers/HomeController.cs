using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PizzaOrderingManagementSystem.Models;
using PizzaOrderingManagementSystem.Services;
using PizzaOrderingManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PizzaOrderingManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PizzaContext context;
        private readonly Repository<Pizza> repoPizza;
        private readonly Repository<OrderDetail> repoOrderDetail;
        private readonly Repository<OrderItemDetail> repoOrderItemDetail;
        private readonly Repository<Topping> repoTopping;

        public HomeController(ILogger<HomeController> logger, DbContextOptions<PizzaContext> options)
        {
            context = new PizzaContext(options);
            repoPizza = new Repository<Pizza>(context);
            repoOrderDetail = new Repository<OrderDetail>(context);
            repoTopping = new Repository<Topping>(context);
            repoOrderItemDetail = new Repository<OrderItemDetail>(context);
            _logger = logger;
        }

        public IActionResult Index()
        {
            var pizzas = repoPizza.Get();
            return View(pizzas);
        }

        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("UserEmail") == null)
                return RedirectToAction("Login","Login");

            var orderDetail = repoOrderDetail.Create(new OrderDetail() { OrderId = HttpContext.Session.GetInt32("OrderId"), PizzaId = id });
            TempData["OrderDetailId"] = orderDetail.Id;
            var pizza = repoPizza.Get(p => p.Id == id).FirstOrDefault();
            var cartItem = new CartItem() { Pizza = pizza, Toppings = repoTopping.Get()};
            foreach (var item in cartItem.Toppings)
            {
                cartItem.SelectedToppings.Add(new SelectListItem { Text = item.Name + " " + item.Price + "$", Value = item.Name, Selected = false });
            }
            return View(cartItem);
        }

        [HttpPost]
        public IActionResult Edit(CartItem cItem, string button)
        {
            foreach (var item in cItem.SelectedToppings)
            {
                if (item.Selected)
                {
                    var topping = repoTopping.Get(t => t.Name == item.Value).FirstOrDefault();
                    repoOrderItemDetail.Create(new OrderItemDetail() { OrderDetailsId = int.Parse(TempData.Peek("OrderDetailId").ToString()), ToppingId = topping.Id });
                }
            }
            if (button == "Add more pizza")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Order");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
