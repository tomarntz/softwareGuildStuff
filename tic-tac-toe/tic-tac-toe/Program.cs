using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    class Program
    {
        static void Main(string[] args)
        {
            askuser();
            drawboard();
        }

        static void askuser()
        {
            Console.WriteLine("Tic-Tac-Toe\n");
            Console.WriteLine("Player 1 please enter name\n");
            string player1 = Console.ReadLine();
            Console.WriteLine("Player 2 please enter name\n");
            string player2 = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Your turn " + player1);

        }
        static void drawboard()
        {
            Console.WriteLine("     |     |     \n" +
                              "     |     |     \n" +
                              "     |     |     \n" +
                              "------------------\n" +
                              "     |     |     \n" +
                              "     |     |     \n" +
                              "     |     |     \n" +
                              "------------------\n" +
                              "     |     |     \n" +
                              "     |     |     \n" +
                              "     |     |     ");

            Console.ReadLine();
        }
           

        
    }
}
