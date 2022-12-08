using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Controllers;
using mvc.DB;
using mvc.Entities;
using mvc.Models;
using mvc.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            if (NavBarView.checkIsDataEmpty())
            {
                NavBarView.SetNonGroupOptions(HomeController.OptionsRepository.GetOptionElemByGroupId(GroupRepository.GetGroupIdByName("navBarLink").Id).ToList());
                NavBarView.AddNewOptionGroup(
                    new NavBarOptionGroup()
                    {
                        GroupedOptions = HomeController.OptionsRepository.GetOptionElemByGroupId(GroupRepository.GetGroupIdByName("link").Id).ToList(),
                        Name = "Pages"
                    }
                );
            }
            return View("NavigationMenu");
        }
    }
}
