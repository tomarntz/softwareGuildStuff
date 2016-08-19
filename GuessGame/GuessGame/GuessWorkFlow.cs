using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessGame
{
    public class GuessWorkFlow
    {
        private Random _randGenerator = new Random();

        public void PlayGame(string playerName)
        {
            int numberToGuess = _randGenerator.Next(1, 21);
            bool guessedcorrectly = false;
            int guesses = 0;

            do
            {
                Console.Write("Please enter a number between 1 and 20:");
                string guess = Console.ReadLine();

                int guessInt = int.Parse(guess);

                if (guessInt == numberToGuess)
                {
                    Console.WriteLine("You guessed thee number!");
                }
                else if (guessInt <= 20 && guessInt >= 1)
                {
                    Console.WriteLine("Try again?");
                }
                else
                {
                    Console.WriteLine("Try a number between 1 and 20 this time!!!");
                }
            } while (!guessedcorrectly);

        }
    }
}
