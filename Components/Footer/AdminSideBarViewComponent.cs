using Microsoft.AspNetCore.Mvc;
using mvc.Controllers;
using mvc.Entities;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Components
{
    public class AdminSideBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("AdminSideBar");
        }
    }
}
 