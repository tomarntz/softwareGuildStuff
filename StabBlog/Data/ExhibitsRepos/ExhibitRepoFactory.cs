using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ExhibitsRepos
{
    public class ExhibitRepoFactory
    {
        public static IExhibitRepo CreateRepo()
        {
            var mode = ConfigurationManager.AppSettings["mode"];

            switch (mode.ToLower())
            {
                case "test":
                    return new ExhibitInMemoryRepo();
                case "prod":
                    return new ExhibitDataBaseRepo();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
