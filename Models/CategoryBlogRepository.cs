using mvc.DB;
using mvc.Entities;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;

namespace mvc.Models
{
    public class CategoryBlogRepository
    {
        private readonly RockfestDB _rockfestDB;

        public CategoryBlogRepository(RockfestDB rockfestDB)
        {
            _rockfestDB = rockfestDB;
        }

        public bool AddNewCategoryToPost(string catId, string postId)
        {
            _rockfestDB.CategoryPosts.Add(new CategoryPost() { CategoryId = catId, PostId = int.Parse(postId) });
            if (this.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }
        public bool RemoveCategoryFromPost(CategoryPost categoryPost)
        {
            _rockfestDB.CategoryPosts.Remove(categoryPost);
            if (this.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }
        public CategoryPost GetCategoryPostByPostId(string postId)
        {
            return _rockfestDB.CategoryPosts.First(catPost => catPost.PostId.ToString() == postId);
        }
        public IQueryable<BlogElem> GetAllPostsWithCategoryId(string catId)
        {

            //SELECT*
            //FROM BlogElem
            //LEFT JOIN CategoryPosts ON CategoryPosts.PostId = BlogElem.Id
            //WHERE CategoryId = 4
            IQueryable<BlogElem> result = from post in _rockfestDB.BlogElem
                              join cat in _rockfestDB.CategoryPosts
                              on post.Id equals cat.PostId
                              where cat.CategoryId == catId
                              select post;

            return result;
        }        
        public bool UpdateCategoryOfPost(string postId, int catId)
        {
            CategoryPost CatEl = this.GetCategoryPostByPostId(postId);
            if (CatEl != null )
            {
                CatEl.CategoryId = catId.ToString();
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

        public bool deleteRowByPostId(string postId)
        {
            _rockfestDB.CategoryPosts.Remove(_rockfestDB.CategoryPosts.First(row => row.PostId == int.Parse(postId)));
            if (_rockfestDB.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }
        public int SaveChanges()
        {
            return _rockfestDB.SaveChanges();
        }

    }
}
