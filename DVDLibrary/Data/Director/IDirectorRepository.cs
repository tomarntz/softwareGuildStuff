using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public interface IDirectorRepository
    {
        Director GetDirectorByMovie(int movieId);
        void Add(Director director);
        void Edit(Director director);
        void Delete(int directorId);
    }
}
