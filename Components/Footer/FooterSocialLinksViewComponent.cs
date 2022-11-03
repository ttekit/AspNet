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
    public class FooterSocialLinksViewComponent : ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            return View("SocialLinks", HomeController.OptionsRepository.GetOptionElemByGroup("OurSocLinks").ToList());
        }
    }
}
