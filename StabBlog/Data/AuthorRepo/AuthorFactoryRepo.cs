using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AuthorRepo
{
    public class AuthorFactoryRepo
    {
        public static IAuthorRepo CreateRepo()
        {
            var mode = ConfigurationManager.AppSettings["mode"];

            switch (mode.ToLower())
            {
                case "test":
                    return new AuthorInMemoryRepo();
                case "prod":
                    return new AuthorDataBaseRepo();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
