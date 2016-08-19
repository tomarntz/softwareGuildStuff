using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BLL;
using Microsoft.AspNet.Identity.Owin;
using Models;
using StabBlog.Models.AppModels;
using StabBlog.Models.ViewModels;

namespace StabBlog.Controllers
{
    public class PostController : Controller
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Post
        [Authorize]
        public ActionResult CreateExhibitPost()
        {
            ExhibitPage newExhibit = new ExhibitPage();
            return View(newExhibit);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateExhibitPost(ExhibitPage newExhibit)
        {
          var user = await UserManager.FindByNameAsync(User.Identity.Name);
            Exhibit exhibitToAdd = new Exhibit()
            {
                Content = newExhibit.Content,
                DateCreated = DateTime.Now,
                PostStatus = false,
                Title = newExhibit.Title,
                PostAuthor = new Author()
                {
                    AuthorId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                },
                ImagePath = newExhibit.ImagePath
                
            };
            PostManagement pm = new PostManagement();
            pm.PostExhibit(exhibitToAdd);
            return RedirectToAction("AdminHome", "Admin");
        }

        [Authorize]
        public ActionResult CreateWeaponPage()
        {
            WeaponVM weapon = new WeaponVM();
            weapon.SetExhibits();
            return View(weapon);
        }

        [HttpPost]
        public  async Task<ActionResult> CreateWeaponPage(WeaponVM model)
        {
            var user = await UserManager.FindByNameAsync(User.Identity.Name);
            Weapon weapon = new Weapon()
            {
                ComingSoon = model.Weapon.ComingSoon,
                Content = model.Weapon.Content,
                DateCreated = DateTime.Now,
                ExhibitId = model.Weapon.ExhibitId,
                Title = model.Weapon.Title,
                PostStatus = false,
                PostAuthor = new Author()
                {
                    AuthorId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                },
                ImagePath = model.Weapon.ImagePath
                
            };
            PostManagement pm = new PostManagement();
            pm.PostWeapon(weapon);

            return RedirectToAction("AdminHome", "Admin");

        }

        [Authorize]
        public ActionResult CreateBlogPost()
        {
            BlogPostVM post = new BlogPostVM();
            post.SetCategories();
            post.SetTags();
            return View(post);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBlogPost(BlogPostVM model, IEnumerable<int> checkBoxList)
        {
            var user = await UserManager.FindByNameAsync(User.Identity.Name);
            Blog newBlog = new Blog()
            {
                Content = model.Post.Content,
                DateCreated = DateTime.Now,
                PostStatus = false,
                Title = model.Post.Title,
                PostAuthor = new Author()
                {
                    AuthorId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                },
                ImagePath = model.Post.ImagePath
            };

            var tagsSplit = model.Post.Tags.Split(' ');
            newBlog.Tags = tagsSplit.Select(t => new Tag() {TagTitle = t}).ToList();

            foreach (var cat in checkBoxList)
            {
                newBlog.Categories.Add(new Category()
                {
                    CategoryId = cat
                });
            }
            PostManagement pm = new PostManagement();
            pm.PostBlog(newBlog);
            return RedirectToAction("AdminHome", "Admin");
        }

        [Authorize]
        public ActionResult CreateNewCategory()
        {
            Category cat = new Category();
            return View(cat);
        }

        [HttpPost]
        public ActionResult CreateNewCategory(Category model)
        {
            PostManagement pm = new PostManagement();
            pm.PostCategory(model);
            return RedirectToAction("AdminHome", "Admin");
        }
    }
}