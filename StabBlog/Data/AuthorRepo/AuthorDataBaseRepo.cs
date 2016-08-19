using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Data.AuthorRepo;
using Data.DapperRepo;
using Models;

namespace Data.AuthorRepo
{
    public class AuthorDataBaseRepo : IAuthorRepo
    {
        public List<Author> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
              return  conn.Query<Author>("select * from authors").ToList();
            }
        }

        public Author Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(DapperSetUp.ConnectionString))
            {
               return conn.Query<Author>("select * from authors where authorid = @id", new {id=id}).FirstOrDefault();
            }
            
        }

        public void Post(Author blog)
        {
            throw new NotImplementedException();
        }

        public void Update(Author blog)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
