using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithConstructorsAndPartials
{
   public partial class Player
    {
        //constructor with parameter
        public Player(string Name)
        {
            //set name to  parameter value
            this.Name = Name;
            //note: 'this' is refering to property
        }
    }
}
