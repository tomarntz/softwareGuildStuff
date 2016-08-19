using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Enums;

namespace ConsoleApplication1.Implementations
{
   public class ComputerPlayer : Player
    {
        private static Random _randomGenerator = new Random();

       public ComputerPlayer(string name) : base(name)
       {
       }

       public override Choice GetChoice()
       {
           int choice = _randomGenerator.Next(1, 4);
           return (Choice) choice;
       }
    }
}
