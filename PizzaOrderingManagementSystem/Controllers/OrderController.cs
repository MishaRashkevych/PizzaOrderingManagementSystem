using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrderingManagementSystem.Models;
using PizzaOrderingManagementSystem.Services;
using PizzaOrderingManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingManagementSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly PizzaContext context;
        private CartRepo cartRepo;
        private Repository<OrderDetail> orderDetailRepo;
        
        public OrderController(DbContextOptions<PizzaContext> options)
        {
            context = new PizzaContext(options);
            orderDetailRepo = new Repository<OrderDetail>(context);
        }

        public ActionResult Index()
        {
            cartRepo = new CartRepo(context, HttpContext.Session.GetInt32("OrderId"));
            var items = cartRepo.Get();
            cartRepo.GetTotalSum();
            return View(items);
        }

        [HttpPost]
        public ActionResult OrderDelete(CartItem cartItem)
        {
            cartRepo.DeleteOrder();
            return View("Index");
        }


        [HttpPost]
        public ActionResult ItemDelete(int id)
        {
            var cartItem = orderDetailRepo.FindById(id);
            orderDetailRepo.Remove(cartItem);
            return RedirectToAction("Index");
        }

        public ActionResult Confirm()
        {


            return RedirectToAction("Index");
        }
    }
}
