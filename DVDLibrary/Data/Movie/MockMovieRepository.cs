using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public class MockMovieRepository : IMovieRepository
    {
        private static List<Models.Movie> _movies;

        static MockMovieRepository()
        {
            if (_movies == null)
            {
                _movies = new List<Movie>
                {
                    new Movie
                    {
                        MovieId = 1,
                        Title = "GhostBusters",
                        RealseDate = new DateTime(1985,06,08),
                        MPAARating = "PG",
                        Studio = "Columbia Pictures"
                    },
                    new Movie
                    {
                        MovieId = 2,
                        Title = "The Shawshank Redemption",
                        RealseDate = new DateTime(1994,09,24),
                        MPAARating = "R",
                        Studio = "Columbia Pictures"
                    },
                    new Movie
                    {
                        MovieId = 3,
                        Title = "The Last Airbender",
                        RealseDate = new DateTime(2010,08,01),
                        MPAARating = "PG",
                        Studio = "Paramount Pictures"
                    },
                    new Movie
                    {
                        MovieId = 4,
                        Title = "Spirited Away",
                        RealseDate = new DateTime(2003,03,28),
                        MPAARating = "PG",
                        Studio = "Studio Ghibli"
                    }
                };
            }
        }

        public List<Movie> GetAll()
        {
            return _movies;
        }

        public void Add(Movie newMovie)
        {
            newMovie.MovieId = (_movies.Any()) ? _movies.Max(c => c.MovieId) + 1 : 1;
            _movies.Add(newMovie);
        }

        public void Delete(int id)
        {
            _movies.RemoveAll(m =>m.MovieId == id);
        }

        public void Edit(Movie movie)
        {
            Delete(movie.MovieId);
            _movies.Add(movie);
        }

        public Movie GetMovieById(int id)
        {
            return _movies.FirstOrDefault(m => m.MovieId == id);
        }

    }
}
