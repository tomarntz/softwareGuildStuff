using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        void Add(Movie newMovie);
        void Delete(int id);
        void Edit(Movie movie);
        Movie GetMovieById(int id);
    }
}
