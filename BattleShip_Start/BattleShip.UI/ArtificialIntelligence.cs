using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;


namespace BattleShip.UI
{
    public class ArtificialIntelligence
    {
        GameWorkFlow gameWF = new GameWorkFlow();
        static Random _random = new Random();

        public void PlaceShips(Board board, string name)
        {
            foreach (ShipType shiptype in Enum.GetValues(typeof(ShipType)))
            {
                bool isVslidPlacement = false;
                while (!isVslidPlacement)
                {
                    var request = new PlaceShipRequest();
                    request.Coordinate = MakeCoordinate();
                    request.Direction = GetDirection(request.Coordinate);
                    request.ShipType = shiptype;
                    ShipPlacement responce = board.PlaceShip(request);
                    if (responce == ShipPlacement.Ok)
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
                Coordinate coordinate = MakeCoordinate();
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
                    EasyMode();
                    return "1";
                case "2":
                    MediumMode();
                    return "2";
                case "3":
                    HardMode();
                    return "3";
                default:
                    return "";
            }
        }

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
            PlaceShips(Player2.Board, Player2.Name);

            gameWF.TakeTurnsFiring(Players);

        }

        public void MediumMode()
        {

        }

        public void HardMode()
        {

        }

    }
}
