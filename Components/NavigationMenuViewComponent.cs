using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Controllers;
using mvc.DB;
using mvc.Entities;
using mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            var navBarLinks = HomeController.OptionsRepository.GetOptionElemByGroup("navBarLink").ToList();
            var pageLinks = HomeController.OptionsRepository.GetOptionElemByGroup("link").ToList();
            return View("NavigationMenu", navBarLinks.Concat(pageLinks));
        }
    }
}
