using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Friends.Models;

namespace Friends.Data
{
    public class MockFriendRepository : IFriendRepository
    {
        public static List<Friend> _friends;

        static MockFriendRepository()
        {
            _friends = new List<Friend>()
            {
                new Friend() {Age=32, Name="Jenny", Phone="876-5309" },
                new Friend() {Age=33,Name="Joe",Phone="876-5310" },
                new Friend() {Age=34,Name="Mark",Phone="876-5311" },
                new Friend() {Age=35,Name="Bob",Phone="876-5312" }
            };
        }

        public List<Friend> GetAll()
        {
            return _friends;
        }

        public void Add(Friend newFriend)
        {
            _friends.Add(newFriend);
        }

        public void Delete(string name)
        {
            _friends.RemoveAll(f => f.Name == name);
        }

        public void Edit(Friend friend)
        {
            Delete(friend.Name);
            Add(friend);
        }

        public Friend GetById(string name)
        {
            return _friends.FirstOrDefault(f => f.Name == name);
        }
    }
}
