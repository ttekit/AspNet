﻿using mvc.DB;
using mvc.Entities;
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
                return _rockfestDB.BlogElem.OrderBy(x => x.Title);
            }
        }

        public BlogElem GetBlogElemById(int id)
        {
            return _rockfestDB.BlogElem.Single(blogElem => blogElem.Id == id);
        }

        public bool AddOneBlogElemToDataBase(BlogElem blogElem)
        {
            _rockfestDB.BlogElem.Add(blogElem);
            if (this.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }

        public void UpdateBlogElemInfo(int id, BlogElem blogElem)
        {
           BlogElem blogEl = this.GetBlogElemById(id);
            if (blogEl != null && blogElem != null)
            {
                blogEl.Title = blogElem.Title;
                blogEl.ImgAlt = blogElem.ImgAlt;
                blogEl.ImgSrc = blogElem.ImgSrc;
                this.SaveChanges();
            }
            else
            {
                throw new System.Exception("Incorrect data");
            }
        }



        public int SaveChanges()
        {
            return _rockfestDB.SaveChanges();
        }
    }
}
