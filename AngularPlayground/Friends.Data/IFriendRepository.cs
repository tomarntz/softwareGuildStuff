using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Friends.Models;

namespace Friends.Data
{
    public interface IFriendRepository
    {
        List<Friend> GetAll();
        void Add(Friend newFriend);
        void Delete(string name);
        void Edit(Friend friend);
        Friend GetById(string name);
    }
}
