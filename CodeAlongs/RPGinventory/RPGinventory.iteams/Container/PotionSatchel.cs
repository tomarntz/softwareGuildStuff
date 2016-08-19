using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGinventory.iteams.Container
{
   public class PotionSatchel:SpecificContainer
   {
       public PotionSatchel() : base(3, IteamType.Potion)
       {
           Name = "a potion satchel";
           Discription = "A satchel that holds potions";
           Weight = 1;
       }
   }
}
