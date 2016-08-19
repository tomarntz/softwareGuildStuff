using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Models;
using Sparc.TagCloud;

namespace StabBlog.Models.ViewModels
{
    public class TagBlogVM
    {
        public List<Blog> BlogList { get; set; }
        public IEnumerable<TagCloudTag> TagList { get; set; }
        public List<Category> AllCats { get; set; }

        public TagBlogVM()
        {
            PostManagement pm = new PostManagement();
            //var tagRepo = TagsRepoFactory.CreateTagRepo();
            BlogList = pm.GetAllBlogs();
            var tl = pm.GetAllTagsByPostStatus().ToArray();

            var tagObject = new TagCloudAnalyzer();
            TagList = tagObject.ComputeTagCloud(tl).Shuffle();

            AllCats = pm.GetCategoriesByPostStatus();

        }
    }
}