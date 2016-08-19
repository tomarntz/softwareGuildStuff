using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGinventory.iteams.Potions
{
    public class HealingPotion
    {
        public HealingPotion()
        {
            Name = "Healing Potion";
            Discription = "Red fizzy liquid smelling of bengay";
            Weight = 1;
            Type = IteamType.Potion;
        }
    }
}
