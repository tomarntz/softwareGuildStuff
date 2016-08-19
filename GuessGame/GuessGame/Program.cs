using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the guessing game");
            Console.Write("What is your name?");
            string name = Console.ReadLine();

            bool KeepPlaying = true;

            do
            {
                GuessWorkFlow game = new GuessWorkFlow();
               // game.PlayGame(name);

                Console.Write("Would you like to play again?");
                string response = Console.ReadLine();

                KeepPlaying = TranslateResponce(response);
            } while (KeepPlaying);

            Console.WriteLine("Thank you for Playing");
            Console.WriteLine("Hit enter key to exit");
            Console.ReadLine();

        }

        static bool TranslateResponce(string responce)
        {
            switch (responce)
            {
                case "Y":
                case "YES":
                case "SURE":
                    return true;
                default:
                    return false;

            }
            {
                    
            }
        }
    }
}
