using BattleShip.BLL.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class Cheats
    {
        public static bool CheckForCheater()
        {
            string cheat = Console.ReadLine();
            if(cheat == "Catdog")
            {
                PlaceAllShips();
                return true;
            }
            return false;
        }
        public static void PlaceAllShips()
        {

        }
    }
}
