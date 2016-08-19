using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithConstructorsAndPartials
{
    class Program
    {
        static void Main(string[] args)
        {
            //calling constructor with parameter
            Player p1 = new Player("Player 1");
            //Calling default constructor
            Player p2 = new Player();

            GameWoekFlow game = new GameWoekFlow()
            {
                //object initializer
                Player1 = p1,
                Player2 = p2
            };

            game.PlayGame();
            Console.ReadLine();
        }
    }
}
