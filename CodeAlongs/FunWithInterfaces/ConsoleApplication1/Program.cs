using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            GermanSheppard bigDog = new GermanSheppard();
            Console.WriteLine(bigDog.GoForAWalk());
            bigDog.Bark();

            bigDog.Name = "Gambit";
            Console.WriteLine(bigDog.Name);

            Chihahua smallDog = new Chihahua("Taco Bell");
            Console.WriteLine(smallDog.GoForWalk());
            smallDog.bark();

           // smallDog.Name = "Gambit";
            Console.WriteLine(smallDog.Name);

            Console.ReadLine();
        }
    }
}
