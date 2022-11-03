using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Controllers;
using mvc.DB;
using mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Components
{
    public class FooterQuickLinksViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View("QuickLinks", HomeController.OptionsRepository.GetOptionElemByGroup("link").ToList());
        }
    }
}
