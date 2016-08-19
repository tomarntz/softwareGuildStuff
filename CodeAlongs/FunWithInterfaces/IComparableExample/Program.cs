using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var temperature = new Temerature[]
            {
                new Temerature() {Farenheit = 71},
                new Temerature() {Farenheit = 120},
                new Temerature() {Farenheit = 74},
                new Temerature() {Farenheit = 60}
            };

            Array.Sort(temperature);

            foreach (var temp in temperature)
            {
                Console.WriteLine($"{temp.Farenheit}{temp.celsus}"); 
            }

            Console.ReadLine();
        }
    }
}
