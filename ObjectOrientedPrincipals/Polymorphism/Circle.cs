using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
   public class Circle : Shape
    {
        //property only avaible to circle 
        public decimal radius { get; set; }

        //override draw method 
       public override string Draw()
       {
           return "Draw a circle";
       }
    }
}
