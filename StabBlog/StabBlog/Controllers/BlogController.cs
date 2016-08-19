using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using BLL;
using Models;
using Sparc.TagCloud;
using StabBlog.Models.ViewModels;

namespace StabBlog.Controllers
{
    public class BlogController : Controller
    {

        private static PostManagement pm = new PostManagement();
        // GET: Blog
        public ActionResult BlogHome()
        {
            var blogVM = new TagBlogVM();
            return View(blogVM);
        }

        public ActionResult SingleBlogView(int id)
        {
           
            var singleBlog = pm.GetBlogById(id);

            return View(singleBlog);
        }

        public ActionResult TagView(string id)
        {
            var blog = pm.GetAllBlogsByTag(id);
            return View(blog);
        }

        public ActionResult CatView(int id)
        {
            var cats = pm.GetAllBlogsByCategory(id);
            return View(cats);
        }
    }
}