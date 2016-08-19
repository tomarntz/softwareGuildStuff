using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type something to reverse");
            string input = Console.ReadLine();
            Console.WriteLine(input.Reverse());
            Console.ReadLine();

        }
    }
}
