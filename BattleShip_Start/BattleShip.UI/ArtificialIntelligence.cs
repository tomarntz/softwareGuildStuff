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
        static Random _random = new Random();

        public static void PlaceShips(Board board, string name)
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

        public static List<Player> PrepareMatchAgainstAI()
        {
            List<Player> players = ConsoleIO.PromptName();
            foreach (Player player in players)
            {
                if (player.Name == "computer")
                {
                    PlaceShips(player.Board, player.Name);
                }
                else
                {
                    GameWorkFlow.PlaceShip(player.Board, player.Name);
                }
            }
            return players;
        }

        public static void SelectDifficulty()
        {
            Console.WriteLine("Select your dificualty");
            Console.WriteLine("1 for easy 2 for medium 3 for hard");
            var dificulty = Console.ReadLine();
            Console.Clear();
            switch (dificulty)
            {
                case "1":
                    EasyMode();
                    break;
                case "2":
                    MediumMode();
                    break;
                case "3":
                    HardMode();
                    break;
                default:
                    break;
            }
        }

        public static void EasyMode()
        {
            Console.WriteLine("Panzy hit enter to continue");
            Console.ReadLine();
            List<Player> players = PrepareMatchAgainstAI();
            GameWorkFlow.TakeTurnsFiring(players);
        }

        public static void MediumMode()
        {

        }

        public static void HardMode()
        {
            ConsoleIO.Display("Hard mode selected");
            Console.ReadLine();
            List<Player> players = PrepareMatchAgainstAI();
            GameWorkFlow.TakeTurnsFiring(players);

        }

        public static Coordinate CalculateWhereToFireNext(Board board, Brain brain)
        {
            
            var lastHit = brain.HitShots.Last();

            //right to last hit
            Coordinate right = lastHit;
            right.XCoordinate = lastHit.XCoordinate++;
            if(board.HasCordBeenFiredAt(right) == false)
            {
                return right;
            }

            //left to last hit
            Coordinate left = lastHit;
            left.XCoordinate = lastHit.XCoordinate--;
            if (board.HasCordBeenFiredAt(left) == false)
            {
                return left;
            }

            //up to last hit
            Coordinate up = lastHit;
            up.YCoordinate = lastHit.YCoordinate++;
            if (board.HasCordBeenFiredAt(up) == false)
            {
                return up;
            }

            //down to last hit
            Coordinate down = lastHit;
            down.YCoordinate = lastHit.YCoordinate--;
            if (board.HasCordBeenFiredAt(down) == false)
            {
                return down;
            }
        }

        public static Coordinate Right(Coordinate lastHit)
        {


            if (lastHit.XCoordinate < 10 || lastHit.XCoordinate > 1)
            {
                lastHit.XCoordinate++;
            }
            cordToReturn.XCoordinate = lastHit.XCoordinate;
            cordToReturn.XCoordinate = lastHit.YCoordinate;
            return cordToReturn;
        }
    }
}
