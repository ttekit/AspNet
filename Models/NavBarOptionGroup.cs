using mvc.Entities;
using System.Collections.Generic;

namespace mvc.Models
{
    public class NavBarOptionGroup
    {
        public List<Options> GroupedOptions {get; set;}
        public string Name { get; set; }

    }
}
