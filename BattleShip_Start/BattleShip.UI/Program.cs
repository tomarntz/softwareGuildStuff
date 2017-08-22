using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameWorkFlow gameWorkFlow = new GameWorkFlow();
            AIWorkFlow AI = new AIWorkFlow();
            gameWorkFlow.Start();
            gameWorkFlow.SelectMode();

            Console.Clear();
        }
    }
}

