using Microsoft.AspNetCore.Mvc;
using mvc.Entities;
using System.Collections.Generic;

namespace mvc.Components
{
    public class FooterNewsletterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Newsletter");
        }
    }
}
