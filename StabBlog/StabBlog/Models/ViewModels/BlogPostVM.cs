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
    public class BlogPostVM
    {
        public BlogPost Post { get; set; }
        public List<Category> Categories { get; set; }
        public IEnumerable<string> AllTags { get; set; }

        public BlogPostVM()
        {
            Categories = new List<Category>();
        }

        public void SetCategories()
        {
            PostManagement pm = new PostManagement();
            Categories = pm.GetAllCategories();
        }

        public void SetTags()
        {
            PostManagement pm = new PostManagement();
            AllTags = pm.GetAllTags();
        }
    }
}