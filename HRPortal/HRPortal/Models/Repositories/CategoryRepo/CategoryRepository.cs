using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRPortal.Models.Data;

namespace HRPortal.Models.Repositories.CategoryRepo 
{
    public class CategoryRepository
    {
        private static List<Category> _categories;

        static CategoryRepository()
        {
            _categories = new List<Category>
            {
                #region  list of categorys with policies
                new Category()
                {
                    CategoryId = 0,
                    Name = "Dragon",
                },
                new Category()
                {
                    CategoryId = 1,
                    Name = "Azor Ahai",
                },
#endregion
            };
        }

        public static List<Category> ReadAll()
        {
            return _categories;
        }

        public static Category Read(int cateoryId)
        {
            return _categories.FirstOrDefault(m => m.CategoryId == cateoryId);
        }

        public static void Create(string name)
        {
            Category category = new Category();
            category.Name = name;
            category.CategoryId = _categories.Max(m => m.CategoryId) + 1;
            _categories.Add(category);
        }

        public static void Update(Category category)
        {
            var selectedCategory = _categories.Find(m => m.CategoryId == category.CategoryId);
            selectedCategory.Name = category.Name;
            selectedCategory.Policies = category.Policies;
        }

        public static void Delete(int categoryId)
        {
            _categories.RemoveAll(m => m.CategoryId == categoryId);
        }
    }
}