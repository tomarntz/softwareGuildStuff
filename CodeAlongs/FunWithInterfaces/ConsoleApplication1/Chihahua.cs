using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Chihahua: IDog
    {
        public string Name { get; private set; }

        public Chihahua(string name)
        {
            Name = name;
        }
        public void bark()
        {
            Console.WriteLine("yip!");
        }

        public string GoForWalk()
        {
            return "going for a short walk";
        }
    }
}
