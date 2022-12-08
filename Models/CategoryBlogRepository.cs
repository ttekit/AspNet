using mvc.DB;
using mvc.Entities;
using System;
using System.IO;
using System.Linq;

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
            _rockfestDB.CategoryPosts.Add(new CategoryPost() { CategoryId = catId, PostId = postId });
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
            return _rockfestDB.CategoryPosts.First(catPost => catPost.PostId == postId);
        }
        public IQueryable<CategoryPost> GetAllPostsWithCategoryId(string catId)
        {
            return _rockfestDB.CategoryPosts.Where(catPost => catPost.CategoryId == catId);
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

        public int SaveChanges()
        {
            return _rockfestDB.SaveChanges();
        }

    }
}
