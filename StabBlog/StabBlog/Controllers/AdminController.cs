using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using StabBlog.Models.AppModels;
using StabBlog.Models.ViewModels;

namespace StabBlog.Controllers
{
    public class AdminController : Controller
    {
        private PostManagement pm = new PostManagement();
        // GET: Admin
        [Authorize]
        public ActionResult AdminHome()
        {
            var vm = new AdminVM();
            return View(vm);
        }
        [Authorize]
        public ActionResult DeleteBlog(int id)
        {
            var blog = pm.GetBlogById(id);
            return View(blog);
        }

        [HttpPost]
        public ActionResult DeleteBlog(Blog blog)
        {
            pm.DeleteBlog(blog.BlogId);
            return RedirectToAction("AdminHome");
        }
        [Authorize]
        public ActionResult DeleteExhibit(int id)
        {
            var exhibit = pm.GetExhibitById(id);
            return View(exhibit);
        }

        [HttpPost]
        public ActionResult DeleteExhibit(Exhibit exhibit)
        {
            pm.DeleteExhibit(exhibit.ExhibitId);
            return RedirectToAction("AdminHome");
        }
        [Authorize]
        public ActionResult DeleteWeapon(int id)
        {
            var weapon = pm.GetWeaponById(id);
            return View(weapon);
        }

        [HttpPost]
        public ActionResult DeleteWeapon(Weapon weapon)
        {
            pm.DeleteWeapon(weapon.WeaponId);
            return RedirectToAction("AdminHome");
        }
        [Authorize]
        public ActionResult PostBlog(int id)
        {
            var blog = pm.GetSingleBlogForAdminPage(id);
            return View(blog);
        }

        [HttpPost]
        public ActionResult PostBlog(Blog blog)
        {
            
            pm.ChangeBlogPostStatus(blog.BlogId);
            
            return RedirectToAction("AdminHome");
        }
        [Authorize]
        public ActionResult PostExhibit(int id)
        {
            var exhibit = pm.GetExhibitById(id);
            return View(exhibit);
        }

        [HttpPost]
        public ActionResult PostExhibit(Exhibit exhibit)
        {
            pm.ChangeExhibitPostStatus(exhibit.ExhibitId);
            return RedirectToAction("AdminHome");
        }
        [Authorize]
        public ActionResult PostWeapon(int id)
        {
            var weapon = pm.GetWeaponById(id);
            return View(weapon);
        }

        [HttpPost]
        public ActionResult PostWeapon(Weapon weapon)
        {
            pm.ChangeWeaponPostStatus(weapon.WeaponId);
            return RedirectToAction("AdminHome");
        }
        [Authorize]
        public ActionResult AddBlog()
        {
            return RedirectToAction("CreateBlogPost", "Post");
        }
        [Authorize]
        public ActionResult AddExhibit()
        {
            return RedirectToAction("CreateExhibitPost","Post");
        }
        [Authorize]
        public ActionResult AddWeapon()
        {
            return RedirectToAction("CreateWeaponPage", "Post");
        }
        [Authorize]
        public ActionResult EditExhibit(int id)
        {
            var exhibit = pm.GetExhibitById(id);
            ExhibitPage model = new ExhibitPage()
            {
                ExhibitId = id,
                Title = exhibit.Title,
                Content = exhibit.Content,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditExhibit(ExhibitPage exhibitPage)
        {
            var exhibit = pm.GetExhibitById(exhibitPage.ExhibitId);
            Exhibit model = new Exhibit
            {
                ExhibitId = exhibit.ExhibitId,
                PostAuthor = exhibit.PostAuthor,
                Weapons = exhibit.Weapons,
                Title = exhibitPage.Title,
                Content = exhibitPage.Content,
                DateLastModified = DateTime.Now
                };
            pm.UpdateExhibit(model);
            return RedirectToAction("AdminHome");
        }
        [Authorize]
        public ActionResult EditWeapon(int id)
        {
            var weapon = pm.GetWeaponById(id);
            WeaponVM  model = new WeaponVM()
            {
                Weapon = new WeaponPage() { 
                 Title = weapon.Title,
                Content = weapon.Content,
                WeaponId = weapon.WeaponId,
                ExhibitId = weapon.ExhibitId,
                ComingSoon = weapon.ComingSoon
            }
                };
            model.SetExhibits();
            return View(model);
        }

        [HttpPost]
        public ActionResult EditWeapon(WeaponVM model)
        {
            
            Weapon weapon =  new Weapon
            {
                WeaponId = model.Weapon.WeaponId,
                ExhibitId = model.Weapon.ExhibitId,
                Title = model.Weapon.Title,
                Content = model.Weapon.Content,
          
                DateLastModified = DateTime.Today,
         
                ComingSoon = false,
                ImagePath =  model.Weapon.ImagePath
            };
            pm.UpdateWeapon(weapon);
            return RedirectToAction("AdminHome");
        }
        [Authorize]
        public ActionResult EditBlog(int id)
        {
            var blog = pm.GetBlogById(id);
            BlogPost post = new BlogPost
            {
                BlogId = id,
                Title = blog.Title,
                Content = blog.Content,
                BlogCatergories = blog.Categories,
                ImagePath = blog.ImagePath
            };
            string blogTags = "";
            foreach (var tag in blog.Tags)
            {
                blogTags += $"{tag.TagTitle} ";
            }
            post.Tags = blogTags.Substring(0, blogTags.Length - 1);
            BlogPostVM model = new BlogPostVM
            {
                Post = post,
            };
            model.SetCategories();
            return View(model);
        }

        [HttpPost]
        public ActionResult EditBlog(BlogPostVM model, IEnumerable<int> checkBoxList )
        {
            var blogToEdit = pm.GetBlogById(model.Post.BlogId);

            Blog blog = new Blog
            {
                BlogId = blogToEdit.BlogId,
                Title = model.Post.Title,
                Content = model.Post.Content,
                DateLastModified = DateTime.Today,
                ImagePath = model.Post.ImagePath
            };
            foreach (var check in checkBoxList)
            {
                blog.Categories.Add(new Category()
                {
                    CategoryId = check
                });
            }

            var tagsSplit = model.Post.Tags.Split(' ');
            blog.Tags = tagsSplit.Select(t => new Tag() { TagTitle = t }).ToList();

            pm.UpdateBlog(blog);
            return RedirectToAction("AdminHome");
        }
    }
}