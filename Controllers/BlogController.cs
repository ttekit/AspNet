using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
            Blog.GetAllPostsFromDataBase();
        }

        [HttpPost]
        public JsonResult GetAllPosts()
        {
            return Json(Blog.BlogList);
        }

        public IActionResult Index()
        {
            return View();
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
            Console.WriteLine(id);
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



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
