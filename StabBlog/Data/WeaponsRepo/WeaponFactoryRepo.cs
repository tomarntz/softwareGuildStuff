using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data.WeaponsRepo
{
    public class WeaponFactoryRepo 
    {
        public static IWeaponRepo CreateRepo()
        {
            var mode = ConfigurationManager.AppSettings["mode"];

            switch (mode.ToLower())
            {
                case "test":
                    return new WeaponInMemoryRepo();
                case "prod":
                    return new WeaponDataBaseRepo();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
