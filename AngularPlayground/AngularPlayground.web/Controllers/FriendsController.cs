using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Friends.Data;
using Friends.Models;

namespace AngularPlayground.web.Controllers
{
    public class FriendsController : ApiController
    {
        public List<Friend> Get()
        {
            var repo = new MockFriendRepository();
            return repo.GetAll();
        }

        public HttpResponseMessage Post(Friend newfriend)
        {
            var repo = new MockFriendRepository();
            repo.Add(newfriend);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
