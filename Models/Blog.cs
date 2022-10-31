using mvc.Entities;
using System.Collections.Generic;

namespace mvc.Models
{
    public class Blog
    {
        private static List<BlogElem> _blogList = new List<BlogElem>();
        public static void AddBlogPost(BlogElem blogElem)
        {
            _blogList.Add(blogElem);
        }
        public static IEnumerable<BlogElem> BlogList
        {
            get { return _blogList; }
        }
    }
}
