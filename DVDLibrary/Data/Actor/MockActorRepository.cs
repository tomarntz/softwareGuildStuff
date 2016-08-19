using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public class MockActorRepository : IActorRepository
    {
        private static List<Actor> _actors;

        static MockActorRepository()
        {
            if (_actors == null)
            {
                _actors = new List<Actor>
                {
                    new Actor
                    {
                        MovieId = 1,
                        ActorId = 1,
                        ActorName = "Bill Murray"
                    },
                    new Actor
                    {
                        MovieId = 1,
                        ActorId = 2,
                        ActorName = "Dan Aykroyd"
                    },
                    new Actor
                    {
                        MovieId = 2,
                        ActorId = 3,
                        ActorName = "Morgan Freeman"
                    },
                    new Actor
                    {
                        MovieId = 2,
                        ActorId = 4,
                        ActorName = "Tim Robbins"
                    },
                    new Actor
                    {
                        MovieId = 3,
                        ActorId = 5,
                        ActorName = "Noah Ringer"
                    },
                    new Actor
                    {
                        MovieId = 3,
                        ActorId = 6,
                        ActorName = "Dev Patel"
                    },
                    new Actor
                    {
                        MovieId = 4,
                        ActorId = 7,
                        ActorName = "Rumi Hiiragi"
                    },
                    new Actor
                    {
                        MovieId = 4,
                        ActorId = 8,
                        ActorName = "Miyu Irino"
                    }
                };
            }
        }

        public List<Actor> GetActorsByMovie(int movieId)
        {
            return _actors.FindAll(m => m.MovieId == movieId);
        }

        public void Add(Actor actor)
        {
            actor.MovieId = (_actors.Any()) ? _actors.Max(c => c.MovieId) + 1 : 1;
            _actors.Add(actor);
        }

        public void Edit(Actor actor)
        {
            Delete(actor.ActorId);
            _actors.Add(actor);
        }

        public void Delete(int actorId)
        {
            _actors.RemoveAll(m => m.ActorId == actorId);
        }
    }
}
