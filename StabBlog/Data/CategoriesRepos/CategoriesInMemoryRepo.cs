using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data.CategoriesRepos
{
    public class CategoriesInMemoryRepo: ICategoryRepo
    {
        private static readonly List<Category> AllCategories;

        static CategoriesInMemoryRepo()
        {
            if (AllCategories == null)
            {
                AllCategories = new List<Category>();

                AllCategories.Add(new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Golden Era"
                });

                AllCategories.Add(new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Cave Man"
                });

                AllCategories.Add(new Category
                {
                    CategoryId = 3,
                    CategoryName = "Brown Era"
                });

                AllCategories.Add(new Category
                {
                    CategoryId = 4,
                    CategoryName = "Stone Age"
                });

                AllCategories.Add(new Category
                {
                    CategoryId = 5,
                    CategoryName = "Cat Era"
                });
            }
        }

        public List<Category> GetAll()
        {
            return AllCategories;
        }

        public void Post(Category categoryToAdd)
        {
            categoryToAdd.CategoryId = GetNewId();
            AllCategories.Add(categoryToAdd);
        }

        public Category GetCategoryById(int id)
        {
            return AllCategories.FirstOrDefault(c => c.CategoryId == id);
        }

        private int GetNewId()
        {
            int id = AllCategories.Max(m => m.CategoryId);
            id++;
            return id;
        }
    }
}
