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
            Console.WriteLine("Rock, Paper, Scissors");
            GamePlay newGame = new GamePlay();

            string input = "";
            do
            {
                newGame.PlayRound();

                Console.Write("Would you like to play again (Enter \"Q\" to quit): ");
                input = Console.ReadLine();
            } while (input.ToUpper()!= "Q");
        }
    }
}
