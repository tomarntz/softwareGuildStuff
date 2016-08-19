using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    class Player
    {
        public Player()
        {
            Board = new Board();
        }
        public string Name { get; set; }
        public Board Board { get; set; }
    }
}
