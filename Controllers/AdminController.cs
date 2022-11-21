using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mvc.DB;
using mvc.Entities;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private static readonly OptionsRepository optionsRepository = new OptionsRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        [HttpGet]
        public IActionResult editOptions()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            return View("editOptions", HomeController.OptionsRepository.allOptions);
        }

        [HttpPost]
        public string updateOptionData(Options options)
        {
            if (User.Identity.IsAuthenticated)
            {
                return optionsRepository.UpdateOption(options).ToString();

            }
            return "False";
        }        
        [HttpPost]
        public string removeOption(Options options)
        {
            if (User.Identity.IsAuthenticated)
            {
                return optionsRepository.RemoveOption(options).ToString();
            }
            return "False";
        }

    }
}
