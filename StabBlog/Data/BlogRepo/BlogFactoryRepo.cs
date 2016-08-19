using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BlogRepo
{
    public class BlogFactoryRepo
    {
        public static IBlogRepo CreateBlogRepo()
        {
            var mode = ConfigurationManager.AppSettings["mode"];
            switch (mode.ToLower())
            {
                case "test":
                    return new BlogInMemoryRepo();
                case "prod":
                    return new BlogDataBaseRepo();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
