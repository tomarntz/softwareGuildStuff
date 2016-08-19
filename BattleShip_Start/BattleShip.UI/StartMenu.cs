using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
   public class StartMenu
    {
       public void Start()
       {
           Console.WriteLine( @"                          ____        _   _   _           _     _       
                         | __ )  __ _| |_| |_| | ___  ___| |__ (_)_ __  
                         |  _ \ / _` | __| __| |/ _ \/ __| '_ \| | '_ \ 
                         | |_) | (_| | |_| |_| |  __/\__ \ | | | | |_) |
                         |____/ \__,_|\__|\__|_|\___||___/_| |_|_| .__/ 
                                                                 |_|");
            //Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            //Console.WriteLine(a);

            Console.ReadKey();
            Console.WriteLine("Player 1 enter name");
            string player1 = Console.ReadLine();

            Console.WriteLine("Player 2 please enter name");
            string player2 = Console.ReadLine();

           Console.Clear();
        }
    }
}
