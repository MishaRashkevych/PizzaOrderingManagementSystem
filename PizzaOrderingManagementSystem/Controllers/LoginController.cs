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
    public class LoginController : Controller
    {
        private readonly Repository<User> repoUser;
        private readonly Repository<Order> repoOrder;

        private readonly PizzaContext context;
        protected CartRepo cartRepo;
        public static List<CartItem> cartItems = new();
        public LoginController(DbContextOptions<PizzaContext> options)
        {
            context = new PizzaContext(options);
            repoUser = new Repository<User>(context);
            repoOrder = new Repository<Order>(context);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            if (repoUser.Get(u=>u.Email == loginModel.Email && u.Password == loginModel.Password).Any())
            {
                var order = new Order() { UEmail = loginModel.Email};
                var newOrder = repoOrder.Create(order);
                HttpContext.Session.SetInt32("OrderId", newOrder.Id);
                return RedirectToAction("Index", "Home", new {id = newOrder.Id });
            }
            else
                return RedirectToAction(nameof(Login));
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (repoUser.Get(u=>u.Email == user.Email).Any())
            {
                ModelState.AddModelError(nameof(user.Email), "User already exist!");
                return View(user);
            }
            repoUser.Create(user);
            return RedirectToAction(nameof(Login));
        }
    }
}
