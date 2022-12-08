using System.Collections.Generic;

namespace mvc.Entities
{
    public class EditPostAdminViewModel
    {
        public BlogElem BlogPost { get; set; }
        public List<Categories> Category { get; set; }
        public CategoryPost CategoryPost { get; set; }
    }
}
