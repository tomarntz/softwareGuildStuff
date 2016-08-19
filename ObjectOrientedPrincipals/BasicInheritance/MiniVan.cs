using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicInheritance
{
   public class MiniVan : Car
    {
        //Defult constructor calling the base
       public MiniVan() : base(60)
       {
           //to illustrate which is called first base or child
           MaxSpeed = 65; //base first, this second thus making maxspeed will be 65
       }

        //constructor calling car int, int
       public MiniVan(int max, int min) : base(max, min) { }

        //constructor not specifying base constructor 
        //hence,  call car()
       public MiniVan(int max) { }
    }
}
