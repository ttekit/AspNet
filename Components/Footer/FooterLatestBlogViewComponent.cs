using Microsoft.AspNetCore.Mvc;
using mvc.Controllers;
using mvc.Entities;
using mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Components
{
    public class FooterLatestBlogViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View("LatestBlog", HomeController.OptionsRepository.GetOptionElemByGroupId(GroupRepository.GetGroupIdByName("LatestBlog").Id).ToList());
        }
    }
}
