using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class Shape
    {
        //virtual = this  method can be overridden by the derived class
        public virtual string Draw()
        {
            return "Drawing a shape";
        }
    }
}
