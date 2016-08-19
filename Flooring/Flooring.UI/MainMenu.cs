using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.BLL;

namespace Flooring.UI
{
    public class MainMenu
    {
        public static void Flow()
        {
            bool quit = false;
            do
            {
                int userInput = Prompts.intPrompt("*******************\n\n" +
                                                  "SG Flooring\n\n" +
                                                  "1. Display Orders\n" +
                                                  "2. Add an Order\n" +
                                                  "3. Edit an Order\n" +
                                                  "4. Remove an Order\n" +
                                                  "5. Quit\n\n" +
                                                  "*******************");
                Console.Clear();
                switch (userInput)
                {
                    case 1:
                        //DisplayOrders();
                        Prompts.Display("Not done yet");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        //AddOrders
                        Prompts.Display("not done yet");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        //Editorder();
                        Prompts.Display("Not  done yet");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        //RemoveOrder
                        Prompts.Display("Not done yet");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        quit = true;
                        break;
                }
                Console.ReadLine();
            } while (!quit);
        }

     //   private static void DisplayOrders(Dictionary<int, > )
    }
}
