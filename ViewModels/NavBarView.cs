using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvc.DB;
using mvc.Entities;
using mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace mvc.ViewModels
{
    public class NavBarView
    {
        private static List<Options> _nonGroupOptions = new List<Options>();
        private static List<NavBarOptionGroup> _groupedOptions = new List<NavBarOptionGroup>();

        public static void SetNonGroupOptions(List<Options> newOptions)
        {
            _nonGroupOptions = newOptions;
        }
        public static void AddNewOptionGroup(NavBarOptionGroup newOptionGrop)
        {
            _groupedOptions.Add(newOptionGrop);
        }

        public static NavBarOptionGroup GetOptionGroup(string name)
        {
            foreach(var group in _groupedOptions)
            {
                if(group.Name == name)
                {
                    return group;
                }
            }
            return new NavBarOptionGroup();
        }
        public static List<NavBarOptionGroup> GetAllGroupedOptions()
        {
            return _groupedOptions;
        }
        public static List<Options> GetNonGroupOptions()
        {
            return _nonGroupOptions;
        }
        public static bool checkIsDataEmpty()
        {
            if (_groupedOptions.Any() && _nonGroupOptions.Any())
            {
                return false;
            }
            return true;
        }
    }
}
