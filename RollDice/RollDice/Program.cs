using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollDice
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary <int,int> catdog = new Dictionary<int,int>();
            Random Dice = new Random();

            for (int i = 2; i < 13; i++)
            {
                catdog.Add(i, 0);
            }

            for (int i = 0; i < 100; i++)
            {
                catdog[Dice.Next(1, 7) + Dice.Next(1, 7)]++;
            }

            for (int i = 2; i < 13; i++)
            {
                Console.WriteLine($"{i} was rolled {catdog[i]} times");
            }
            Console.ReadLine();
        }
    }
}
