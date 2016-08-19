using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data.AuthorRepo
{
    public interface IAuthorRepo
    {
        List<Author> GetAll();

        Author Get(int id);

        void Post(Author author);

        void Update(Author author);

        void Delete(int id);
    }
}
