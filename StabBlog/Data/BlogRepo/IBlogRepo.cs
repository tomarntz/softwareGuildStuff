using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data.BlogRepo
{
    public interface IBlogRepo
    {
        List<Blog> GetAll();

        Blog Get(int id);

        List<Blog> GetAllForAndminPage();

        Blog GetSingleBlogForAdminPage(int id);

        void Post(Blog blog);

        void Update(Blog blog);

        void Delete(int id);

        Blog GetMostRecentBlog();

        void ChangePostStatus(int id);

        List<Blog> GetByTag(string id);

        List<Blog> GetAllBlogsByCategory(int categoryId);

        List<Category> CatsByPostStatus();

        IEnumerable<string> GetTagsByPostStatus();
    }
}
