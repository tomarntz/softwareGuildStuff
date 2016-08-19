using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL
{
    public class Prompts
    {
        public static void Display(string message)
        {
            Console.WriteLine(message);
        }

        public static int intPrompt(string message)
        {
            bool isValid = false;
            int i = 0;
            string userInput = "";
            do
            {
                Console.WriteLine(message);
                userInput = Console.ReadLine();
                isValid = int.TryParse(userInput, out i);
                if (!isValid)
                {
                    Display("Not a valid number");
                    Console.ReadLine();
                }
                Console.Clear();
            } while (!isValid);
            return i;
        }

        public static string Prompt(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }

}
