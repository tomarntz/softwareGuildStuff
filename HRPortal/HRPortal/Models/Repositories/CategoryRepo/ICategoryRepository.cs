using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models.Data;

namespace HRPortal.Models.Repositories.CategoryRepo
{
    interface ICategoryRepository
    {
         Category Create(Category category);

        List<Category> GetAll();
        Category Read(int id);

        bool Update(Category category, int categoryId);
        bool Delete(int categoryId);
    }
}
