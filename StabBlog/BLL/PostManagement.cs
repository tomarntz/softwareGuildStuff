using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.BlogRepo;
using Data.CategoriesRepos;
using Data.ExhibitsRepos;
using Data.TagsRepos;
using Data.WeaponsRepo;
using Models;

namespace BLL
{
    public class PostManagement
    {
        private static IBlogRepo _blogRepo = BlogFactoryRepo.CreateBlogRepo();
        private static IExhibitRepo _exhibitRepo = ExhibitRepoFactory.CreateRepo();
        private static IWeaponRepo _weaponRepo = WeaponFactoryRepo.CreateRepo();
        private static ICategoryRepo _categoryRepo = CategoryRepoFactory.CreateCategoryRepo();
        private static ITagRepo _tagRepo = TagsRepoFactory.CreateTagRepo();

        public void PostBlog(Blog post)
        {
            List<Category> catsToAdd = new List<Category>();
            List<Tag> tagsToAdd = new List<Tag>();
            foreach (var cat in post.Categories)
            {
                 catsToAdd.Add(_categoryRepo.GetCategoryById(cat.CategoryId));
            }
            foreach (var tag in post.Tags)
            {
                tagsToAdd.Add(_tagRepo.Post(tag));
            }
            post.Categories = catsToAdd;
            post.Tags = tagsToAdd;
            _blogRepo.Post(post);
        }

        public void PostExhibit(Exhibit post)
        {
            _exhibitRepo.Post(post);
        }

        public void PostWeapon(Weapon post)
        {
            _weaponRepo.Post(post);
         }

        public List<Exhibit> GetAllExhibits()
        {
            List<Exhibit> exhibits = _exhibitRepo.GetAll();
            foreach (var exhibit in exhibits)
            {
                exhibit.Weapons = _weaponRepo.GetAllWeaponsByExhibit(exhibit.ExhibitId);
            }
            return exhibits;
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepo.GetAll();
        }

        public Blog GetBlogById(int id)
        {
            return _blogRepo.Get(id);
        }

        public void DeleteBlog(int id)
        {
            _blogRepo.Delete(id);
        }

        public Exhibit GetExhibitById(int id)
        {
            
            Exhibit exhibit = _exhibitRepo.Get(id);
            exhibit.Weapons = _weaponRepo.GetAllWeaponsByExhibit(id);
            return exhibit;
        }

        public void DeleteExhibit(int id)
        {
            _exhibitRepo.Delete(id);
        }

        public Weapon GetWeaponById(int id)
        {
            return _weaponRepo.Get(id);
        }

        public void DeleteWeapon(int id)
        {
            _weaponRepo.Delete(id);
        }

        public void ChangeBlogPostStatus(int id)
        {
            _blogRepo.ChangePostStatus(id);
        }

        public void ChangeExhibitPostStatus(int id)
        {
            _exhibitRepo.ChangePostStatus(id);
        }

        public void ChangeWeaponPostStatus(int id)
        {
            _weaponRepo.ChangePostStatus(id);
        }

        public void UpdateBlog(Blog blog)
        {
            List<Category> catsToAdd = new List<Category>();
            List<Tag> tagsToAdd = new List<Tag>();
            foreach (var cat in blog.Categories)
            {
                catsToAdd.Add(_categoryRepo.GetCategoryById(cat.CategoryId));
            }
            foreach (var tag in blog.Tags)
            {
                tagsToAdd.Add(_tagRepo.Post(tag));
            }
            blog.Categories = catsToAdd;
            blog.Tags = tagsToAdd;
            _blogRepo.Update(blog);
        }

        public void UpdateExhibit(Exhibit exhibit)
        {
            _exhibitRepo.Update(exhibit);
        }

        public void UpdateWeapon(Weapon weapon)
        {
            _weaponRepo.Update(weapon);
        }

        public List<Blog> GetAllBlogs()
        {
            return _blogRepo.GetAll();
        }

        public List<Blog> GetAllBlogsByTag(string id)
        {
            return _blogRepo.GetByTag(id);
        }

        public List<Blog> GetAllBlogsByCategory(int id)
        {
            return _blogRepo.GetAllBlogsByCategory(id);
        }

        public List<Weapon> GetAllWeapons()
        {
            return _weaponRepo.GetAll();
        }

        public IEnumerable<string> GetAllTags()
        {
            return _tagRepo.GetAll();
        }

        public IEnumerable<string> GetAllTagsByPostStatus()
        {
            return _blogRepo.GetTagsByPostStatus();
        }

        public Blog GetMostRecentBlog()
        {
            return _blogRepo.GetMostRecentBlog();
        }

        public Exhibit GetMostRecentExhibit()
        {
            return _exhibitRepo.GetMostRecentExhibit();
        }

        public Weapon GetMostRecentWeapon()
        {
            return _weaponRepo.GetMostRecentWeapon();
        }

        public List<Category> GetCategoriesByPostStatus()
        {
            return _blogRepo.CatsByPostStatus();
        }

        public void PostCategory(Category cat)
        {
            _categoryRepo.Post(cat);
        }

        public List<Blog> GetAllBlogsForAdminPage()
        {
            return _blogRepo.GetAllForAndminPage();
        }

        public Blog GetSingleBlogForAdminPage(int id)
        {
           return _blogRepo.GetSingleBlogForAdminPage(id);
        }
    }
}
