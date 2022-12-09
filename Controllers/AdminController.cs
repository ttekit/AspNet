using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mvc.DB;
using mvc.Entities;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;

namespace mvc.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private IWebHostEnvironment _environment;
        private static readonly OptionsRepository optionsRepository = new OptionsRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));

        public AdminController(ILogger<AdminController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        [HttpGet]
        public IActionResult editOptions()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            return View("editOptions", HomeController.OptionsRepository.allOptions);
        }
        [HttpGet]
        public IActionResult editGroups()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            return View("editGroups", GroupRepository.AllGroups.ToList());
        }
        public IActionResult editBlog()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            var blogModel = new BlogRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));
            var data = blogModel.blogElems.ToList();
            return View("editBlog", data);
        }

        [Route("Admin/editPost/{postId?}")]
        public IActionResult editPost(int postId)
        {
            int test = postId;
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            var blogModel = new BlogRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));
            var categoryModel = new CategoryRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));
            var categoryPost = new CategoryBlogRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));
            var currentCat = categoryPost.GetCategoryPostByPostId(postId.ToString());
            return View("editPost", new EditPostAdminViewModel() 
            { 
                BlogPost = blogModel.GetBlogElemById(postId), 
                Category = categoryModel.allCategories.ToList(), 
                CategoryPost = currentCat,
            });
        }

        [HttpGet]
        public List<Group> getOptionsGroupData()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }
            return GroupRepository.AllGroups.ToList();
        }

        [HttpPost]
        public string deleteOnePost(int postId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var blogModel = new BlogRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));
                var blogCatsModel = new CategoryBlogRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));
                bool res = blogCatsModel.deleteRowByPostId(postId.ToString());
                if (res)
                {
                    res = blogModel.deletePost(postId);
                }
                if (res)
                {
                    return res.ToString();
                }
            }
            return "False";
        }

        public IActionResult addNewPost()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }
            var catsRep = new CategoryRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));
            return View("addNewPost", catsRep.allCategories.ToList());
        }

        [HttpPost]
        public string addNewPostAct()
        {
            if (User.Identity.IsAuthenticated)
            {
                var formData = Request.Form;
                var keysData = formData.Keys.ToList();

                var blogRep = new BlogRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));

                var catRep = new CategoryRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));

                BlogElem blogElem = new BlogElem(
                    default,
                    formData["Name"],
                    "",
                    "/",
                    formData["Content"],
                    DateTime.Now
                );

                bool res = blogRep.AddOneBlogElemToDataBase(blogElem, catRep.GetCategoryByName(formData["Category"]).Id);

                if(res == true)
                {
                    if (formData.Files.Count == 1)
                    {
                        if (formData.Files[0].Length > 3 * 1024 * 1024)
                        {
                            throw new Exception("File is too big");
                        }

                        string pathToOptionImage = $"\\images\\blog\\" + blogElem.Id + System.IO.Path.GetExtension(formData.Files[0].FileName);
                        string fullPath = Path.Join(_environment.WebRootPath,
                                                    pathToOptionImage);


                        blogElem.ImgSrc = pathToOptionImage;

                        FileStream fileStream = new FileStream(fullPath, FileMode.Create);
                        formData.Files[0].CopyTo(fileStream);
                        fileStream.Close();
                    };
                }

                res = blogRep.UpdateBlogElemInfo(blogElem.Id, blogElem);

                return res.ToString();

            }
            return "False";
        }


        [HttpPost]
        public string updateOptionData(Options options)
        {
            if (User.Identity.IsAuthenticated)
            {
                return optionsRepository.UpdateOption(options).ToString();

            }
            return "False";
        }

        [HttpPost]
        public string removeOption(Options options)
        {
            if (User.Identity.IsAuthenticated)
            {
                return optionsRepository.RemoveOption(options.Id).ToString();
            }
            return "False";
        }

        [HttpPost]
        public string addNewOption(Options options)
        {
            if (User.Identity.IsAuthenticated)
            {
                return optionsRepository.AddNewOptionToDataBase(options).ToString();
            }
            return "False";
        }



        [HttpPost]
        public string updateGroupData(Group group)
        {
            if (User.Identity.IsAuthenticated)
            {
                return GroupRepository.UpdateData(group).ToString();
            }
            return "False";
        }

        [HttpPost]
        public string removeGroup(Group group)
        {
            if (User.Identity.IsAuthenticated)
            {
                return GroupRepository.RemoveGroup(group.Id).ToString();
            }
            return "False";
        }

        [HttpPost]
        public string addNewGroup(Group group)
        {
            if (User.Identity.IsAuthenticated)
            {
                return GroupRepository.AddNewGroupToDataBase(group).ToString();
            }
            return "False";
        }




        [HttpPost]
        public string updateProduct()
        {
            if (User.Identity.IsAuthenticated)
            {
                var formData = Request.Form;
                var keysData = formData.Keys.ToList();
                BlogElem blogElem = new BlogElem(
                    int.Parse(formData["Id"]),
                    formData["Name"],
                    "",
                    "/",
                    formData["Content"],
                    DateTime.Now
                );
                if (formData.Files.Count == 1)
                {
                    if (formData.Files[0].Length > 3 * 1024 * 1024)
                    {
                        throw new Exception("File is too big");
                    }

                    string pathToOptionImage = $"\\images\\blog\\" + formData["Id"] + System.IO.Path.GetExtension(formData.Files[0].FileName);
                    string fullPath = Path.Join(_environment.WebRootPath,
                                                pathToOptionImage);


                    blogElem.ImgSrc = pathToOptionImage;

                    FileStream fileStream = new FileStream(fullPath, FileMode.Create);
                    formData.Files[0].CopyTo(fileStream);
                    fileStream.Close();
                };

                var blogRep = new BlogRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));

                var catRep = new CategoryRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));
                
                var catBlogRep = new CategoryBlogRepository(new DB.RockfestDB(new DbContextOptions<RockfestDB>()));

                catBlogRep.UpdateCategoryOfPost(formData["id"], catRep.GetCategoryByName(formData["Category"]).Id);


                return blogRep.UpdateBlogElemInfo(blogElem.Id, blogElem).ToString();


            }
            return "False";
        }
    }
}
