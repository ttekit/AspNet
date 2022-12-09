using mvc.DB;
using mvc.Entities;
using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;

namespace mvc.Models
{
    public class BlogRepository
    {
        private readonly RockfestDB _rockfestDB;

        public BlogRepository(RockfestDB rockfestDB)
        {
            _rockfestDB = rockfestDB;
        }
        public IQueryable<BlogElem> blogElems
        {
            get
            {
                return _rockfestDB.BlogElem.OrderBy(x => x.Id);
            }
        }

        public BlogElem GetBlogElemById(int id)
        {
            return _rockfestDB.BlogElem.First(blogElem => blogElem.Id == id);
        }

        public bool AddOneBlogElemToDataBase(BlogElem blogElem, int catId)
        {
            _rockfestDB.BlogElem.Add(blogElem);
            this.SaveChanges();
            _rockfestDB.CategoryPosts.Add(new CategoryPost(blogElem.Id, catId));
            if (this.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }

        public bool UpdateBlogElemInfo(int id, BlogElem blogElem)
        {
            BlogElem blogEl = this.GetBlogElemById(id);
            if (blogEl != null && blogElem != null)
            {
                blogEl.Title = blogElem.Title;
                blogEl.ImgAlt = blogElem.ImgAlt;
                blogEl.ImgSrc = blogElem.ImgSrc;
                blogEl.Content = blogElem.Content;
                blogEl.Date = blogElem.Date;
                if (this.SaveChanges() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new System.Exception("Incorrect data");
            }
        }

        public IQueryable<BlogElem> GetLastPosts(int limit)
        {
            return _rockfestDB.BlogElem.OrderBy(x => x.Date).Take(limit);
        }

        public int SaveChanges()
        {
            return _rockfestDB.SaveChanges();
        }

        internal bool deletePost(int postId)
        {
            var post = _rockfestDB.BlogElem.First(post => post.Id == postId);
            _rockfestDB.BlogElem.Remove(post);
            if (this.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }
    }
}
