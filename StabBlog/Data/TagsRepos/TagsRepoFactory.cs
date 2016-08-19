using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.BlogRepo;

namespace Data.TagsRepos
{
    public class TagsRepoFactory
    {
        public static ITagRepo CreateTagRepo()
        {
            var mode = ConfigurationManager.AppSettings["mode"];
            switch (mode.ToLower())
            {
                case "test":
                    return new TagsInMemoryRepo();
                case "prod":
                    return new TagsDataBaseRepo();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
