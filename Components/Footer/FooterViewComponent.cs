using Microsoft.AspNetCore.Mvc;
using mvc.Entities;
using System.Collections.Generic;

namespace mvc.Components
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Footer");
        }
    }
}
