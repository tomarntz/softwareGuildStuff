using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using Models;

namespace DVDLibrary.Controllers
{
    public class MovieController : ApiController
    {
        public List<Movie> Get()
        {
            var repo = Factory.CreaMovieRepository();
            return repo.GetAll();
        }


    }
}
