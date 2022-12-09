using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using mvc.DB;
using mvc.Entities;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace mvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;
        private static BlogRepository _blogRepository = new BlogRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;   
        }

        [HttpPost]
        public List<BlogElem> GetAllPosts()
        {
            return Blog.BlogList.ToList();
        }

        public IActionResult Index()
        {
            PostsCats postsCats = new PostsCats();
            var catRep = new CategoryRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));
            postsCats.BlogPost = GetAllPosts();
            postsCats.Category = catRep.allCategories.ToList();
            Blog.GetAllPostsFromDataBase();
            return View("Index", postsCats);
        }

        [HttpPost]
        public RedirectResult AddNewCommentToPost(Comments comment)
        {
            if (ModelState.IsValid)
            {
                comment.Date = DateTime.Now;
                var commentsDataBase = new CommentsRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));
                commentsDataBase.AddOneCommentToPost(comment);
                return Redirect("/Blog/Post/"+comment.postId);
            }
            return Redirect("/Blog");
        }


        [Route("Blog/Post/{id?}")]
        public IActionResult Post(int id)
        {
            BlogRepository blogRepository = new BlogRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));
            BlogElem blogData = blogRepository.GetBlogElemById(id);
            List<BlogElem> lastFourBlogs = blogRepository.GetLastPosts(4).ToList();

            CommentsRepository commentsRep = new CommentsRepository(new mvc.DB.RockfestDB(new DbContextOptions<RockfestDB>()));
            List<Comments> comments = commentsRep.GetCommentsByPostId(id);

            return View("Post", new BlogPost()
            {
                BlogData = blogData,
                LastFourBlogs = lastFourBlogs,
                Comments = comments,
            }
            );
        }

        [HttpGet]
        public List<BlogElem> GetCatsPosts(string catName)
        {
            var catRep = new CategoryRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));
            var catPostRep = new CategoryBlogRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));

            int catId = catRep.GetCategoryByName(catName).Id;


            return catPostRep.GetAllPostsWithCategoryId(catId.ToString()).ToList(); ;
        }   

    }
}
