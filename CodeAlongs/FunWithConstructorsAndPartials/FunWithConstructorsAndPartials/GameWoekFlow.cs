using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FunWithConstructorsAndPartials
{
   public class GameWoekFlow
    {
        //properties
       public Player Player1 { get; set; }
       public Player Player2 { get; set; }

        //private static read only field
        //private- only inside class
        //static- there is  only 1
        //read- only can set a constructor only
       private static readonly Random _randonGernerator;

        //static constructor
        //can only initialize static properties and fields
        //note: it can not interact with instances of the class
       static GameWoekFlow()
       {
           _randonGernerator= new Random();
       }
        //private method, only used in this class
       private int RollDie()
       {
           return _randonGernerator.Next(1, 7);
       }

       public void PlayGame()
       {
           do
           {
               Player1.Score += RollDie();
               Player2.Score += RollDie();
           } while (Player1.Score < 100 && Player2.Score < 100);

           Console.ForegroundColor = ConsoleColor.Yellow;
           Console.WriteLine("GAME OVER!");
           Console.WriteLine($"{Player1.Name}:{Player1.Score} vs {Player2.Name}:{Player2.Score}");
       }
    }
}
