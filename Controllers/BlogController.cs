using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
            if (Blog.BlogList.Count() == 0)
            {
                Blog.AddBlogPost(new Entities.BlogElem()
                {
                    Id = 1,
                    Title = "Hematochezia nonpurchase alilonghi funt Istiophorus victualer incunabula",
                    ImgSrc = "images/blog/1.jpg",
                    ImgAlt = "",
                    Content = "Dolore officia sint incididunt non excepteur ea mollit commodo ut enim reprehenderit cupidatat labore ad laborum consectetur consequat..."
                }); Blog.AddBlogPost(new Entities.BlogElem()
                {
                    Id = 2,
                    Title = "Corticipetally unentrance Ponerinae anthocyan multiserial parsonship penumbrous",
                    ImgSrc = "images/blog/2.jpg",
                    ImgAlt = "",
                    Content = "Dolore officia sint incididunt non excepteur ea mollit commodo ut enim reprehenderit cupidatat labore ad laborum consectetur consequat..."
                }); Blog.AddBlogPost(new Entities.BlogElem()
                {
                    Id = 3,
                    Title = "Latching aphagia prostatelcosis gadolinium hemikaryon aftergrief ventricumbent Swab",
                    ImgSrc = "images/blog/3.jpg",
                    ImgAlt = "",
                    Content = "Dolore officia sint incididunt non excepteur ea mollit commodo ut enim reprehenderit cupidatat labore ad laborum consectetur consequat..."
                }); Blog.AddBlogPost(new Entities.BlogElem()
                {
                    Id = 4,
                    Title = "Thermodynamicist aeolistic lipsanotheca nearaway Tamworth pycnid subtower",
                    ImgSrc = "images/blog/4.jpg",
                    ImgAlt = "",
                    Content = "Dolore officia sint incididunt non excepteur ea mollit commodo ut enim reprehenderit cupidatat labore ad laborum consectetur consequat..."
                }); Blog.AddBlogPost(new Entities.BlogElem()
                {
                    Id = 5,
                    Title = "Unpresumptuously carnelian trochiscus echoic enmask myodynamiometer",
                    ImgSrc = "images/blog/5.jpg",
                    ImgAlt = "",
                    Content = "Dolore officia sint incididunt non excepteur ea mollit commodo ut enim reprehenderit cupidatat labore ad laborum consectetur consequat..."
                }); Blog.AddBlogPost(new Entities.BlogElem()
                {
                    Id = 6,
                    Title = "Statesmanese pseudhemal steatite Wendish boxhaul equiprobability xylonic",
                    ImgSrc = "images/blog/6.jpg",
                    ImgAlt = "",
                    Content = "Dolore officia sint incididunt non excepteur ea mollit commodo ut enim reprehenderit cupidatat labore ad laborum consectetur consequat..."
                });
            }
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
