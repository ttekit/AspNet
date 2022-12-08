using System.Collections.Generic;

namespace mvc.Entities
{
    public class PostsCats
    {
        public List<BlogElem> BlogPost { get; set; }
        public List<Categories> Category { get; set; }
    }
}
