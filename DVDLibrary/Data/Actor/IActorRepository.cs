using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public interface IActorRepository
    {
        List<Actor> GetActorsByMovie(int movieId);
        void Add(Actor actor);
        void Edit(Actor actor);
        void Delete(int actorId);
    }
}
