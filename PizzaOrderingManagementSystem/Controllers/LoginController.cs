using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaOrderingManagementSystem.Models;
using PizzaOrderingManagementSystem.Services;
using PizzaOrderingManagementSystem.ViewModel;
using System.Linq;

namespace PizzaOrderingManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly Repository<User> repoUser;
        private readonly Repository<Order> repoOrder;
        private readonly PizzaContext context;

        public LoginController(DbContextOptions<PizzaContext> options)
        {
            context = new PizzaContext(options);
            repoUser = new Repository<User>(context);
            repoOrder = new Repository<Order>(context);
        }

        public IActionResult Login()
        {
            HttpContext.Session.SetString("IsCartEmpty", "true");
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                var user = repoUser.Get(u => u.Email == loginModel.Email && u.Password == loginModel.Password).FirstOrDefault();
                if (user != null)
                {
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    HttpContext.Session.SetString("UserName", user.Name);
                    var order = new Order() { UEmail = loginModel.Email, Phone = user.Phone, Address = user.Address };
                    var newOrder = repoOrder.Create(order);
                    HttpContext.Session.SetInt32("OrderId", newOrder.Id);
                    return RedirectToAction("Index", "Home", new { id = newOrder.Id });
                }
                else
                    ModelState.AddModelError(nameof(user.Email), "Incorrect input!");
                    ModelState.AddModelError(nameof(user.Password), "Incorrect input!");
                return View(loginModel);
            }
            catch (System.Exception)
            {
                return RedirectToAction(nameof(Login));
            }
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

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
