using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Data
{
    public static class Factory
    {
        public static IMovieRepository CreaMovieRepository()
        {
            switch (ConfigurationManager.AppSettings["mode"].ToLower())
            {
                case "test":
                    return new MockMovieRepository();
                case "prod":
                    return new DBRepository();
                default:
                    throw new NotSupportedException();
            }
        }


    }
}
