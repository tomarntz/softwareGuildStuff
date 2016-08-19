using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using StabBlog.Models.AppModels;

namespace StabBlog.Models.ViewModels
{
    public class HomeVM
    {
        public Blog ViewBlog { get; set; }
        public Exhibit ViewExhibit { get; set; }
        public Weapon ViewWeapon { get; set; }
        public List<Blog> CarouselBlogImage { get; set; }


        public HomeVM()
        {
            PostManagement pm = new PostManagement();
            ViewBlog = pm.GetMostRecentBlog();
            CarouselBlogImage = pm.GetAllBlogs();
            ViewExhibit = pm.GetMostRecentExhibit();
            ViewWeapon = pm.GetMostRecentWeapon();
        }
    }
}