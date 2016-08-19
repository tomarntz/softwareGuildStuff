using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Enums;
using ConsoleApplication1.Interrfaces;

namespace ConsoleApplication1.Implementations
{
   public abstract class Player : IChoiceSelector
    {
       public string Name { get; }

       public Player(string name)
       {
           Name = Name;
       }

       public abstract Choice GetChoice();
    }
}
