using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Entities;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult buyTicket()
        {
            return View();
        }
        [HttpPost]
        public ViewResult BuyTicket([Bind("Id,Name,Email,Phone,ticketA,ticketB,ticketC")] GuestTicket msg)
        {
            if (ModelState.IsValid)
            {
                return View("Succsess", msg);
            }
            return View("buyTicket");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
