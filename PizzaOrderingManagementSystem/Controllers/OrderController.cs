using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrderingManagementSystem.Models;
using PizzaOrderingManagementSystem.Services;
using System.Linq;

namespace PizzaOrderingManagementSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly PizzaContext context;
        private CartRepo cartRepo;
        private readonly Repository<OrderDetail> orderDetailRepo;
        private readonly Repository<Order> orderRepo;

        public OrderController(DbContextOptions<PizzaContext> options)
        {
            context = new PizzaContext(options);
            orderDetailRepo = new Repository<OrderDetail>(context);
            orderRepo = new Repository<Order>(context);
        }

        public ActionResult Index()
        {
            cartRepo = new CartRepo(context, HttpContext.Session.GetInt32("OrderId"));
            var items = cartRepo.Get();
            cartRepo.GetTotalSum();
            return View(items);
        }

        [HttpPost]
        public ActionResult OrderDelete()
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
            var order = orderRepo.Get(o => o.Id == HttpContext.Session.GetInt32("OrderId")).FirstOrDefault();
            return View(order);
        }

        [HttpPost]
        public ActionResult Confirm(bool confirm)
        {
            if (confirm)
            {
                var user = context.Users.Where(u => u.Email == HttpContext.Session.GetString("UserEmail")).FirstOrDefault();
                Order order = new Order() { Address = user.Address, Phone = user.Phone, UEmail = user.Email};
                var newOrder = orderRepo.Create(order);
                HttpContext.Session.SetInt32("OrderId", newOrder.Id);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
