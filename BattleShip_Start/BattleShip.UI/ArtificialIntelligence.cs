using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System.Threading;

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
            LoadingBar("AI is placing its ships");
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
            LoadingBar("AI calculating shot");
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
                case "3":
                    HardMode();
                    break;
                default:
                    break;
            }
        }

        public static void LoadingBar(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("*");
            Thread.Sleep(250);
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("**");
            Thread.Sleep(250);
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("***");
            Thread.Sleep(250);
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("****");
            Thread.Sleep(250);
            Console.Clear();
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("*");
            Thread.Sleep(250);
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("**");
            Thread.Sleep(250);
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("***");
            Thread.Sleep(250);
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("****");
            Thread.Sleep(250);
            Console.Clear();
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("*");
            Thread.Sleep(250);
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("**");
            Thread.Sleep(250);
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("***");
            Thread.Sleep(250);
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("****");
            Thread.Sleep(250);
            Console.Clear();
        }

        public static void EasyMode()
        {
            Console.WriteLine("Panzy hit enter to continue");
            Console.ReadLine();
            List<Player> players = PrepareMatchAgainstAI();
            GameWorkFlow.TakeTurnsFiring(players);
        }

        public static void HardMode()
        {
            ConsoleIO.Display("Hard mode selected");
            Console.ReadLine();
            List<Player> players = PrepareMatchAgainstAI();
            GameWorkFlow.TakeTurnsFiring(players);

        }

        public static Coordinate CalcShot(Board board, Brain brain)
        {
            
        }

        public static Coordinate FoundEndOfShipCalcShot(Board board, Brain brain)
        {
            Coordinate startingPoint = brain.InitialHitOfShip;
            if(brain.HitShotsDecreasing == null)
            {
                if(brain.ShipOnX == true)
                {
                    startingPoint.YCoordinate--;
                    return startingPoint;
                }
                else
                {
                    startingPoint.XCoordinate--;
                    return startingPoint;
                }
            }
            else
            {
                var lastHit = brain.HitShotsDecreasing.Last();

                if (brain.ShipOnX == true)
                {
                    lastHit.YCoordinate--;
                    return startingPoint;
                }
                else
                {
                    lastHit.XCoordinate--;
                    return startingPoint;
                }
            }

        }

        public static void UpdateBrainOnMiss(Brain brain, FireShotResponse response, Coordinate cord)
        {
           foreach(KeyValuePair<ShipType, bool> ship in brain.FiringAtShip)
            {
                if (ship.Value)
                {
                    foreach(KeyValuePair<ShipType, Coordinate>endOfShip in brain.InitialHitOfShip)
                    {
                        if(ship.Key == endOfShip.Key)
                        {
                            brain.InitialHitOfShip.Remove(endOfShip.Key);
                            brain.InitialHitOfShip.Add(endOfShip.Key, cord);
                        }
                    }
                }
            }
        }

        public static void UpdateBrainOnHitAndSunk(Brain brain, FireShotResponse response)
        {
            if(response.ShipImpacted == "Battleship")
            {
                brain.firingAtBattleship = false;
            }
            if (response.ShipImpacted == "Destroyer")
            {
                brain.firingAtDestroyer = false;
            }
            if (response.ShipImpacted == "Submarine")
            {
                brain.firingAtSubmarine = false;
            }
            if (response.ShipImpacted == "Cruiser")
            {
                brain.firingAtCruiser = false;
            }
            if (response.ShipImpacted == "Carrier")
            {
                brain.firingAtCarrier = false;
            }
        }

        public static void UpdateBrainOnHit(Brain brain, FireShotResponse response, Coordinate cord)
        {
            foreach (KeyValuePair<ShipType, Coordinate> initialHit in brain.InitialHitOfShip)
            {
                if (initialHit.Value == null && response.ShipImpacted == initialHit.Key.ToString())
                {
                    brain.InitialHitOfShip.Remove(initialHit.Key);
                    brain.InitialHitOfShip.Add(initialHit.Key, cord);

                    brain.HitShotsIncreasing.Remove(initialHit.Key);
                    brain.HitShotsIncreasing.Add(initialHit.Key, new List<Coordinate> { cord });
                }
            }
            foreach (KeyValuePair<ShipType, bool> Firing in brain.FiringAtShip)
            {
                if (Firing.Key.ToString() == response.ShipImpacted)
                {
                    if (!Firing.Value)
                    {
                        brain.FiringAtShip.Remove(Firing.Key);
                        brain.FiringAtShip.Add(Firing.Key, true);
                    }
                    else
                    {
                        return
                    }
                }
                foreach (KeyValuePair<ShipType, Coordinate> Next in brain.ShipsToFireAtNext)
                {

                }

                  
            }
        }

        //switch (response.ShotStatus)
        //{
        //    case ShotStatus.Hit:
        //        if (brain.FoundEndOfShip == true)
        //        {
        //            brain.HitShotsDecreasing.Add(cord);
        //        }
        //        else
        //        {
        //            brain.InitialHitOfShip = cord;
        //            brain.HitShotsIncreasing.Add(cord);
        //        }
        //        if (brain.FoundShip == true)
        //        {
        //            brain.FoundShipDirection = true;
        //        }
        //        brain.FoundShip = true;
        //        break;
        //    case ShotStatus.HitAndSunk:
        //        ConsoleIO.DisplayAIBoardShotHistory(board);
        //        brain.HitShotsIncreasing.Add(cord);
        //        brain.FoundShip = false;
        //        brain.FoundShipDirection = false;
        //        brain.InitialHitOfShip = null;
        //        brain.FoundEndOfShip = false;
        //        break;
        //    case ShotStatus.Victory:
        //        isvalid = true;
        //        break;
        //    default:
        //        break;
        //}

        public static Coordinate FoundDirectionCalcShot(Board board, Brain brain)
        {
            Coordinate lastHit = brain.HitShotsIncreasing.Last();
            Coordinate secLast = brain.HitShotsIncreasing[brain.HitShotsIncreasing.Count - 2];

            if(lastHit.XCoordinate == secLast.XCoordinate)
            {
                brain.ShipOnX = true;
                if(brain.FoundEndOfShip == true)
                {

                }
                lastHit.YCoordinate++;
                return lastHit;
            }
            else
            {
                brain.ShipOnY = true;
                lastHit.XCoordinate++;
                return lastHit;
            }
        }

        public static Coordinate FoundShipCalcDirection(Board board, Brain brain)
        {
             var lastHit = brain.HitShotsIncreasing.Last();

            //right to last hit
            Coordinate right = Right(lastHit);
            if(board.HasCordBeenFiredAt(right) == false && board.IsValidCoordinate(right) == true)
            {
                return right;
            }

            //left to last hit
            Coordinate left = Left(lastHit);
            if (board.HasCordBeenFiredAt(left) == false && board.IsValidCoordinate(right) == true)
            {
                return left;
            }

            //up to last hit
            Coordinate up = Up(lastHit);
            if (board.HasCordBeenFiredAt(up) == false && board.IsValidCoordinate(right) == true)
            {
                return up;
            }
            //down to last hit
            Coordinate down = Down(lastHit);
            return down;
        }

        public static Coordinate Right(Coordinate lastHit)
        {
            lastHit.XCoordinate++;
            return lastHit;
        }

        public static Coordinate Left(Coordinate lastHit)
        {
            lastHit.XCoordinate--;
            return lastHit;
        }

        public static Coordinate Up(Coordinate lastHit)
        {
            lastHit.YCoordinate--;
            return lastHit;
        }

        public static Coordinate Down(Coordinate lastHit)
        {
            lastHit.YCoordinate++;
            return lastHit;
        }
    }
}
