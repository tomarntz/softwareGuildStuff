using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Data
{
    public static class Factory
    {
        public static IContactRepository CreateContactRepository()
        {
            switch (ConfigurationManager.AppSettings["mode"].ToLower())
            {
                case "test":
                    return new MockContactRepository();
                case "prod":
                    return new ContactRepository();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
