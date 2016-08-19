using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public class MockUserRepository :  IUserRepository
    {
        private static List<User> _users;

        static MockUserRepository()
        {
            if (_users == null)
            {
                _users = new List<User>
                {
                    new User
                    {
                        UserId = 1,
                        MovieId = 2,
                        UserName = "Craig",
                        UserRating = 7/10,
                        UserNotes = "Fantastic",
                        DateBorrowed = DateTime.Today,
                        DateReturned = DateTime.Today.Add(TimeSpan.FromDays(1))
                    },
                    new User
                    {
                        UserId = 2,
                        MovieId = 1,
                        UserName = "Robert",
                        UserRating = 8/10,
                        UserNotes = "Loved it",
                        DateBorrowed = DateTime.Today,
                        DateReturned = DateTime.Today.Add(TimeSpan.FromDays(1))
                    },
                    new User
                    {
                        UserId = 3,
                        MovieId = 4,
                        UserName = "Max",
                        UserRating = 9/10,
                        UserNotes = "Best movie ever",
                        DateBorrowed = DateTime.Today,
                        DateReturned = DateTime.Today.Add(TimeSpan.FromDays(1))
                    },
                    new User
                    {
                        UserId = 4,
                        MovieId = 3,
                        UserName = "Thrasher",
                        UserRating = 2/10,
                        UserNotes = "Horrible Movie",
                        DateBorrowed = DateTime.Today,
                        DateReturned = DateTime.Today.Add(TimeSpan.FromDays(1))
                    }

                };
            }
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public void Add(User user)
        {
            user.MovieId = (_users.Any()) ? _users.Max(c => c.MovieId) + 1 : 1;
            _users.Add(user);
        }

        public void Delete(int userId)
        {
            _users.RemoveAll(m => m.UserId == userId);
        }

        public void Edit(User user)
        {
            Delete(user.UserId);
            _users.Add(user);
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(m => m.UserId == id);
        }
    }
}
