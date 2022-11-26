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
        [HttpGet]
        public IActionResult editGroups()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            return View("editGroups", GroupRepository.AllGroups.ToList());
        }   
        
        [HttpGet]
        public List<Group> getOptionsGroupData()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }
            return GroupRepository.AllGroups.ToList();
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
                return optionsRepository.RemoveOption(options.Id).ToString();
            }
            return "False";
        }
        [HttpPost]
        public string addNewOption(Options options)
        {
            if (User.Identity.IsAuthenticated)
            {
                return optionsRepository.AddNewOptionToDataBase(options).ToString();
            }
            return "False";
        }


        [HttpPost]
        public string updateGroupData(Group group)
        {
            if (User.Identity.IsAuthenticated)
            {
                return GroupRepository.UpdateData(group).ToString();

            }
            return "False";
        }
        [HttpPost]
        public string removeGroup(Group group)
        {
            if (User.Identity.IsAuthenticated)
            {
                return GroupRepository.RemoveGroup(group.Id).ToString();
            }
            return "False";
        }
        [HttpPost]
        public string addNewGroup(Group group)
        {
            if (User.Identity.IsAuthenticated)
            {
                return GroupRepository.AddNewGroupToDataBase(group).ToString();
            }
            return "False";
        }
    }
}
