using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data.AuthorRepo
{
    public class AuthorInMemoryRepo : IAuthorRepo
    {
        private static readonly List<Author> _authors;

        static AuthorInMemoryRepo()
        {
            #region Authors
                        if (_authors == null)
                        {
                            _authors = new List<Author>
                            {
                                new Author
                                {
                                    AuthorId = 1,
                                    FirstName = "Ben",
                                    LastName = "Dover"
                                },
                                new Author
                                {
                                    AuthorId = 2,
                                    FirstName = "Richard",
                                    LastName = "Head"
                                }
                            };
                        }
            #endregion
        }

        public List<Author> GetAll()
        {
            return _authors;
        }

        public Author Get(int id)
        {
            return _authors.FirstOrDefault(m => m.AuthorId == id);
        }

        public void Post(Author author)
        {
            author.AuthorId = (_authors.Any()) ? _authors.Max(c => c.AuthorId) + 1 : 1;
            _authors.Add(author);
        }

        public void Update(Author author)
        {
            Delete(author.AuthorId);
            _authors.Add(author);
        }

        public void Delete(int id)
        {
            _authors.RemoveAll(m => m.AuthorId == id);
        }
    }
}
