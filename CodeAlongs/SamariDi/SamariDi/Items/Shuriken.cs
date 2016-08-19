using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamariDi.Items
{
    public class Shuriken : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine($"Pierced {target}'s armor!");
        }
    }
}
