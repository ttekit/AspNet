using Microsoft.EntityFrameworkCore;
using mvc.Controllers;
using mvc.DB;
using mvc.Entities;
using System.Collections.Generic;
using System.Linq;

namespace mvc.Models
{
    public class Blog
    {
        private static List<BlogElem> _blogList = new List<BlogElem>();
        private static BlogRepository _blogRepository = new BlogRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));
        public static void AddBlogPost(BlogElem blogElem)
        {
            _blogList.Add(blogElem);
        }
        public static void GetAllPostsFromDataBase()
        {
            _blogList = _blogRepository.blogElems.ToList();
        }
        public static IEnumerable<BlogElem> BlogList
        {
            get { return _blogList; }
        }
    }
}
