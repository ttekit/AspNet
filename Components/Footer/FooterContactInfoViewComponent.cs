using Microsoft.AspNetCore.Mvc;
using mvc.Controllers;
using mvc.Entities;
using mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Components
{
    public class FooterContactInfoViewComponent : ViewComponent
    {
        private static List<Options> _contactInfoFields = new List<Options>();
        public IViewComponentResult Invoke()
        {
            return View("ContactInfo", HomeController.OptionsRepository.GetOptionElemByGroupId(GroupRepository.GetGroupIdByName("ContactUs").Id).ToList());
        }
    }
}
 