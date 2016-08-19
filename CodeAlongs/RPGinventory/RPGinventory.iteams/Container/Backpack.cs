using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGinventory.iteams.Container
{
   public class Backpack:Container
    {
       public Backpack() : base(4)
       {
           Name = "a leather backpack";
           Discription = "not quite big enough to fit body";
           Weight = 2;
       }
    }
}
