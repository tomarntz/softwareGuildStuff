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
            ShipType ship = ShipCurrentlyUnderFire(brain);
            //found a ship dont know direction
            if (ship != ShipType.None)
            {
                //found direction havent found end
                if (DoWeKnowShipDirection(brain, ship) != null)
                {
                    // found end of ship
                    if (DoWeKnowTheEndOfShip(brain,ship))
                    {
                        return FoundEndOfShipCalcShot(board, brain, ship);
                    }
                    return FoundDirectionCalcShot(board, brain, ship);
                }
                return FoundShipCalcDirection(board, brain);
            }
            return MakeCoordinate();
        }

        public static Coordinate FoundEndOfShipCalcShot(Board board, Brain brain, ShipType ship)
        {
            Coordinate startingPoint = brain.InitialHitOfShip[ship];
            if(brain.HitShotsDecreasing[ship] == null)
            {
                if(brain.ShipOnXAxis[ship] == true)
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
                            brain.InitialHitOfShip[endOfShip.Key] = cord;
                        }
                    }
                }
            }
        }

        public static void UpdateBrainOnHitAndSunk(Brain brain, FireShotResponse response)
        {
            var ship = ConverStringToShip(response.ShipImpacted);
            UpdateFiringAtShip(ship, brain);
        }

    
        public static ShipType ShipCurrentlyUnderFire(Brain brain)
        {
            ShipType shipUnderFire = brain.FiringAtShip.FirstOrDefault(x => x.Value == true).Key;
            return shipUnderFire;
        }

        public static bool? DoWeKnowShipDirection(Brain brain, ShipType ship)
        {
            if (brain.ShipOnXAxis[ship] == true)
            {
                return true;
            }
            if(brain.ShipOnXAxis[ship] == false)
            {
                return false;
            }
            return null;
        }

        public static bool DoWeKnowTheEndOfShip(Brain brain, ShipType ship)
        {
            if(brain.FoundEndOfShips[ship] == true)
            {
                return true;
            }
            return false;
        }

        public static void UpdateBrainOnHit(Brain brain, FireShotResponse response, Coordinate cord)
        {
            string shipAimingAt = ShipCurrentlyUnderFire(brain).ToString();

            foreach (KeyValuePair<ShipType, Coordinate> initialHit in brain.InitialHitOfShip)
            {
                foreach (KeyValuePair<ShipType, bool> Firing in brain.FiringAtShip)
                {
                    //make sure the 2 dictionaries are on the same ship
                    if(initialHit.Key == Firing.Key)
                    {
                        //make sure that ship is the one just hit
                        if (response.ShipImpacted == initialHit.Key.ToString())
                        {
                            //very first hit of ship
                            if (initialHit.Value == null && !Firing.Value && shipAimingAt == null)
                            {
                                brain.InitialHitOfShip[initialHit.Key] = cord;
                                brain.FiringAtShip[Firing.Key] = true;
                                brain.HitShotsIncreasing[initialHit.Key] = new List<Coordinate> { cord };
                            }
                            //after first hit of ship
                            else if(shipAimingAt != )
                            {
                                brain.HitShotsIncreasing.Add(initialHit.Key, new List<Coordinate> { cord });
                            }
                        }
                    }
                }
            }
            ///////////////////////////////////////////////////////////////
            //uuuugggghh need to check for ship direction 
            //found a new ship when trying to sink differnent ship add to list for later use
                        else
                        {
                //adds ship to list of ships to fire at after sinking current ship and sets initial hit
                brain.ShipsToFireAtNext.Add(ConverStringToShip(response.ShipImpacted), cord);
                brain.InitialHitOfShip[ConverStringToShip(response.ShipImpacted)] = cord;

            }

            //if you not yet firing at ship just hit 
            if (!Firing.Value && ShipAimingAt == response.ShipImpacted)
        }
               

        public static void UpdateFiringAtShip(ShipType shipUnderFire, Brain brain)
        {
            switch (shipUnderFire)
            {
                case ShipType.Battleship:
                    brain.FiringAtShip[ShipType.Battleship] = true;
                    brain.FiringAtShip[ShipType.Destroyer] = false;
                    brain.FiringAtShip[ShipType.Submarine] = false;
                    brain.FiringAtShip[ShipType.Cruiser] = false;
                    brain.FiringAtShip[ShipType.Carrier] = false;
                    break;
                case ShipType.Destroyer:
                    brain.FiringAtShip[ShipType.Battleship] = false;
                    brain.FiringAtShip[ShipType.Destroyer] = true;
                    brain.FiringAtShip[ShipType.Submarine] = false;
                    brain.FiringAtShip[ShipType.Cruiser] = false;
                    brain.FiringAtShip[ShipType.Carrier] = false;
                    break;
                case ShipType.Submarine:
                    brain.FiringAtShip[ShipType.Battleship] = false;
                    brain.FiringAtShip[ShipType.Destroyer] = false;
                    brain.FiringAtShip[ShipType.Submarine] = true;
                    brain.FiringAtShip[ShipType.Cruiser] = false;
                    brain.FiringAtShip[ShipType.Carrier] = false;
                    break;
                case ShipType.Cruiser:
                    brain.FiringAtShip[ShipType.Battleship] = false;
                    brain.FiringAtShip[ShipType.Destroyer] = false;
                    brain.FiringAtShip[ShipType.Submarine] = false;
                    brain.FiringAtShip[ShipType.Cruiser] = true;
                    brain.FiringAtShip[ShipType.Carrier] = false;
                    break;
                case ShipType.Carrier:
                    brain.FiringAtShip[ShipType.Battleship] = false;
                    brain.FiringAtShip[ShipType.Destroyer] = false;
                    brain.FiringAtShip[ShipType.Submarine] = false;
                    brain.FiringAtShip[ShipType.Cruiser] = false;
                    brain.FiringAtShip[ShipType.Carrier] = true;
                    break;
            }
        }

        public static ShipType ConverStringToShip(string ship)
        {
            switch (ship)
            {
                case "Battleship":
                    return ShipType.Battleship;
                case "Destroyer":
                    return ShipType.Destroyer;
                case "Submarine":
                    return ShipType.Submarine;
                case "Cruiser":
                    return ShipType.Cruiser;
                case "Carrier":
                    return ShipType.Carrier;
                    //should never happen
                default:
                    return ShipType.Carrier;
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

        public static Coordinate FoundDirectionCalcShot(Board board, Brain brain, ShipType ship)
        {
            Coordinate lastHit = brain.HitShotsIncreasing[ship].Last();
            Coordinate secLast = brain.HitShotsIncreasing[ship][brain.HitShotsIncreasing[ship].Count-2];

            if (lastHit.XCoordinate == secLast.XCoordinate)
            {
                brain.ShipOnXAxis[ship] = true;
                lastHit.YCoordinate++;
                return lastHit;
            }
            else
            {
                brain.ShipOnXAxis[ship] = false;
                lastHit.XCoordinate++;
                return lastHit;
            }
        }

        public static Coordinate FoundShipCalcDirection(Board board, Brain brain)
        {
            ShipType ship = ShipCurrentlyUnderFire(brain);
            Coordinate lastHit = brain.InitialHitOfShip[ship];

            //right to last hit
            Coordinate right = lastHit;
            right.XCoordinate++;
            if((!board.HasCordBeenFiredAt(right)) && (board.IsValidCoordinate(right)))
            {
                return right;
            }

            //left to last hit
            Coordinate left = lastHit;
            left.XCoordinate--;
            if ((!board.HasCordBeenFiredAt(left)) && (board.IsValidCoordinate(right)))
            {
                return left;
            }

            //up to last hit
            Coordinate up = lastHit;
            up.YCoordinate--;
            if ((!board.HasCordBeenFiredAt(up)) && (board.IsValidCoordinate(right)))
            {
                return up;
            }
            //down to last hit
            Coordinate down = lastHit;
            down.YCoordinate++;
            return down;
        }
    }
}
