using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGinventory.iteams.Weapons
{
    public class WoodenSword:Iteam
    {
        public WoodenSword()
        {
            Name = "A wodden sword";
            Discription = "Its dangerous take this";
            Weight = 3;
            Type = IteamType.Weapon;
        }
    }
}
