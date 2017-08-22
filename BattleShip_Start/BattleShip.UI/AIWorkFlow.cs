using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class AIWorkFlow
    {
        ArtificialIntelligence AI = new ArtificialIntelligence();
        public void PlaceShips(Board board, string name)
        {
            foreach(ShipType shiptype in Enum.GetValues(typeof(ShipType)))
            {
                bool isVslidPlacement = false;
                while (!isVslidPlacement)
                {
                    var request = new PlaceShipRequest();
                    request.Coordinate = ArtificialIntelligence.MakeCoordinate();
                    request.Direction = ArtificialIntelligence.GetDirection(request.Coordinate);
                    request.ShipType = shiptype;
                    ShipPlacement responce = board.PlaceShip(request);
                    if(responce == ShipPlacement.Ok)
                    {
                        isVslidPlacement = true;
                    }
                }
            }
        }

        public static FireShotResponse FireShot(Board board, string name)
        {
            bool isvalid = false;
            FireShotResponse response = null;
            ConsoleIO.BoardShotHistory(board);
            while (!isvalid)
            {
                Coordinate coordinate = ArtificialIntelligence.MakeCoordinate();
                response = board.FireShot(coordinate);
                switch (response.ShotStatus)
                {
                    case ShotStatus.Invalid:
                        isvalid = false;
                        break;
                    case ShotStatus.Duplicate:
                        isvalid = false;
                        break;
                    case ShotStatus.Miss:
                        isvalid = true;
                        break;
                    case ShotStatus.Hit:
                        isvalid = true;
                        break;
                    case ShotStatus.HitAndSunk:
                        isvalid = true;
                        break;
                    case ShotStatus.Victory:
                        isvalid = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return response;
        }

        public string SelectDifficulty()
        {
            Console.WriteLine("Select your dificualty");
            Console.WriteLine("1 for easy 2 for medium 3 for hard");
            var dificulty = Console.ReadLine();
            Console.Clear();
            switch (dificulty)
            {
                case "1":
                    AI.EasyMode();
                    return "1";
                case "2":
                    AI.MediumMode();
                    return "2";
                case "3":
                    AI.HardMode();
                    return "3";
                default:
                    return "";
            }
        }

        public void TakeTurnsWithAI(List<Player> players)
        {
            FireShotResponse response = new FireShotResponse();
            while (response.ShotStatus != ShotStatus.Victory)
            {
                for (int i = 1; i < 3; i++)
                {
                    Player current = players[i - 1];
                    Player opponite = players[i % 2];
                    Console.Clear();
                    response = GameWorkFlow.FireShot(opponite.Board, current.Name);

                    if (response.ShotStatus == ShotStatus.Victory)
                    {
                        break;
                    }
                }
            }

        }

    }
}
