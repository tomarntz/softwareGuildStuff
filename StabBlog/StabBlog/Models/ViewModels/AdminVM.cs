using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Models;

namespace StabBlog.Models.ViewModels
{
    public class AdminVM
    {
        public List<Blog> AllBlogs { get; set; }
        public List<Exhibit> AllExhibits { get; set; }
        public List<Weapon> AllWeapons { get; set; }
        public IEnumerable<string> AllTags { get; set; }

        public AdminVM()
        {
            PostManagement pm = new PostManagement();
            AllBlogs = pm.GetAllBlogsForAdminPage();
            AllTags = pm.GetAllTags();
            AllExhibits = pm.GetAllExhibits();
            AllWeapons = pm.GetAllWeapons();
        }
    }
}