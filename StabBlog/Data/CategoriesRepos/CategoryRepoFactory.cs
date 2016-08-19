using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.BlogRepo;

namespace Data.CategoriesRepos
{
    public class CategoryRepoFactory
    {
        public static ICategoryRepo CreateCategoryRepo()
        {
            var mode = ConfigurationManager.AppSettings["mode"];
            switch (mode.ToLower())
            {
                case "test":
                    return new CategoriesInMemoryRepo();
                case "prod":
                    return new CategoriesDataBaseRepo();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
