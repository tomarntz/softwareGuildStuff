using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class GermanSheppard
    {
        public string Name { get; set; }

        public void Bark()
        {
            Console.WriteLine("Woof!");

        }

        public string GoForAWalk()
        {
            return "Goin for a long walk";
        }
    }
}
