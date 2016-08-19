using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public class MockDirectorRepository : IDirectorRepository
    {
        private static List<Director> _directors;

        static MockDirectorRepository()
        {
            if (_directors == null)
            {
                _directors = new List<Director>
                {
                    new Director
                    {
                        MovieId = 1,
                        DirectorId = 1,
                        DirectorName = "Ivan Reitman"
                    },
                    new Director
                    {
                        MovieId = 2,
                        DirectorId = 2,
                        DirectorName = "Frank Darabont"
                    },
                    new Director
                    {
                        MovieId = 3,
                        DirectorId = 3,
                        DirectorName = "M. Night Shyamalan"
                    },
                    new Director
                    {
                        MovieId = 4,
                        DirectorId = 4,
                        DirectorName = "Hayao Miyazaki"

                    }
                };
            }
        }

        public Director GetDirectorByMovie(int movieId)
        {
            return _directors.FirstOrDefault(m => m.MovieId == movieId);
        }

        public void Add(Director director)
        {
            director.DirectorId = (_directors.Any()) ? _directors.Max(c => c.DirectorId) + 1 : 1;
            _directors.Add(director);
        }

        public void Edit(Director director)
        {
            Delete(director.DirectorId);
            _directors.Add(director);
        }

        public void Delete(int directorId)
        {
            _directors.RemoveAll(m => m.DirectorId == directorId);
        }
    }
}
