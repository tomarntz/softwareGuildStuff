using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamariDi.Items
{
    public class Ration : IIteam
    {
        public void Use()
        {
            Console.WriteLine("Eating a ration");
        }
    }
}
