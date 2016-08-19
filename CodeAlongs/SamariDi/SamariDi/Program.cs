using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamariDi.Items;

namespace SamariDi
{
    class Program
    {
        static void Main(string[] args)
        {
            Samurai bob = new Samurai(new Sword());
            bob.Attack("The bad dudes");

            bob.SecondaryWweapon = new Shuriken();
            if (bob.SecondaryWweapon != null)
            {
                bob.SecondaryWweapon.Hit("The other guy");
            }

            Samurai jack = new Samurai(new Shuriken());
            jack.Attack("The evildoers");

            jack.PickUpItem(new Ration());
            jack.PickUpItem(new Ration());
            jack.PickUpItem(new Ration());
            jack.PickUpItem(new Ration());
            jack.PickUpItem(new Ration());
            jack.PickUpItem(new Ration());
            jack.PickUpItem(new Ration());

            Console.ReadLine();
        }
    }
}
