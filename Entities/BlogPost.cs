using Microsoft.EntityFrameworkCore;
using mvc.DB;
using mvc.Models;
using System.Collections.Generic;

namespace mvc.Entities
{
    public class BlogPost
    {
        public BlogElem BlogData { get; set; }
        public List<BlogElem> LastFourBlogs { get; set; }
        public List<Comments> Comments { get; set; }
    }
}
