using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data.CategoriesRepos
{
    public interface ICategoryRepo
    {
        List<Category> GetAll();

        void Post(Category categoryToAdd);

        Category GetCategoryById(int id);
    }
}
