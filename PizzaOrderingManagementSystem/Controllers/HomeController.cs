using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaOrderingManagementSystem.Models;
using PizzaOrderingManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaOrderingManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Pizza> _repo;

        public HomeController(ILogger<HomeController> logger, IRepository<Pizza> repo)
        {
            _logger = logger;
            _repo = repo;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View(_repo.Get());
        }

    }
}
