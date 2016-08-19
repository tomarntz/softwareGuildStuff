using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Data.DapperRepo;
using Models;

namespace Data.CategoriesRepos
{
    public class CategoriesDataBaseRepo:ICategoryRepo
    {
        public List<Category> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                return conn.Query<Category>(@"select *
                                                from Categories").ToList();
            }
        }

        public void Post(Category categoryToAdd)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                categoryToAdd.CategoryId =
                    conn.Query<int>(@"
                                    insert into categories(CategoryName) 
                                    values (@CategoryName) 
                                    select cast(scope_identity() as int)"
                                    , new {categoryToAdd.CategoryName}).First();
            }
            
        }

        public Category GetCategoryById(int id)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
                return conn.Query<Category>(@"select CategoryName, CategoryId
	                                            from Categories
		                                            where CategoryId = @id", new {id}).FirstOrDefault();
            }
        }
    }
}
