using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            int number, x;
            Console.WriteLine("Enter a number to factor: ");
            string input = Console.ReadLine();

            number = int.Parse(input);
            Console.WriteLine("The factors of " +input+ " are:");
            for (x = 1; x < number; x++)
            {
                if (number % x == 0)
                {
                    Console.WriteLine(x);
                }
            }
            if()
            {
                Console.WriteLine(input+" is a perfect number.");
            }
        else
            {
                Console.WriteLine(input+" is not a perfect number.");
            }
                 
            Console.ReadLine();
        }
    }
}
