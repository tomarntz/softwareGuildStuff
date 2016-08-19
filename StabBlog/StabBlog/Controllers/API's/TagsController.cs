using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace StabBlog.Controllers.API_s
{
    public class TagsController : ApiController
    {
        public IEnumerable<string> GetAll()
        {
            PostManagement pm = new PostManagement();
            return pm.GetAllTags();
        }
    }
}
