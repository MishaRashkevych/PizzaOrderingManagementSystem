using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaOrderingManagementSystem.Models;
using PizzaOrderingManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingManagementSystem.Controllers
{
    public class RegisterController : Controller
    {
        private readonly PizzaContext _context;
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(PizzaContext context, ILogger<RegisterController> logger)
        {
            _context = context;
            _logger = logger;

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Register register)
        {
            if (ModelState.IsValid)
            {
                //_context.Registers.Add(register);
                //_context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                // if (_context.Logins.Find(login.Email).ToString() != null)
                //if (login.Email.ToString() == "dileep")
                
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Create");
                }
            }
            return View();
        }
    }
}
