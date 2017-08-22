using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class ArtificialIntelligence
    {
        GameWorkFlow gameWF = new GameWorkFlow();
        AIWorkFlow AIWF = new AIWorkFlow();
        static Random _random = new Random();

        public static ShipDirection GetDirection(Coordinate coord)
        {
            ShipDirection result = ShipDirection.Up;
            int dir = _random.Next(0, 5);
            result = (ShipDirection)(dir - 1);
            return result;
        }

        public static Coordinate MakeCoordinate()
        {

            int xcord = _random.Next(0, 11);
            int ycord = _random.Next(0, 11);

            Coordinate coord = new Coordinate(xcord, ycord);
            return coord;
        }

        public void EasyMode()
        {
            Console.WriteLine("Panzy hit enter to continue");
            Console.ReadLine();

            List<Player> Players = new List<Player>();
            Player Player1 = new Player();
            Player Player2 = new Player();

            Player1.Name = ConsoleIO.PromptString("Enter your name.", true);
            Console.Clear();
            Player2.Name = ("computer");
            Console.Clear();

            Players.Add(Player1);
            Players.Add(Player2);

            gameWF.PlaceShip(Player1.Board, Player1.Name);
            AIWF.PlaceShips(Player2.Board, Player2.Name);

            AIWF.TakeTurnsWithAI(Players);

        }

        public void MediumMode()
        {

        }

        public void HardMode()
        {

        }

    }
}
