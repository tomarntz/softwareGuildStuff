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
            bool isCheater = Cheats.CheckForCheater();
            foreach (Player player in players)
            {
                if (player.Name == "computer")
                {
                    PlaceShips(player.Board, player.Name);
                }
                else if(!isCheater)
                {
                    GameWorkFlow.PlaceShip(player.Board, player.Name);
                }
                else
                {
                    Console.WriteLine("Cheat activated placing ships");
                    PlaceShips(player.Board, player.Name);
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

        public static ShipType? CheckShipsToFireAtNext(Brain brain)
        {
            if(brain.ShipsToFireAtNext.Count != 0)
            {
                foreach(ShipType ship in Enum.GetValues(typeof(ShipType)))
                {
                    if(brain.ShipsToFireAtNext[ship] != null)
                    {
                        brain.ShipsToFireAtNext.Remove(ship);
                        UpdateFiringAtShip(ship, brain);
                        return ship;
                    }
                }
            }
            return null;
        }

        //set end of ship if x or y 10 before calc shot
        public static Coordinate CalcShot(Board board, Brain brain)
        {
            var ship = ShipCurrentlyUnderFire(brain);
            //found a ship dont know direction
            if (ship != null)
            {
                ShipType shippy = ConverStringToShip(ship.ToString());
                //found direction havent found end
                if (DoWeKnowShipDirection(brain, shippy) != null)
                {
                    // found end of ship
                    if (DoWeKnowTheEndOfShip(brain, shippy))
                    {
                        return FoundEndOfShipCalcShot(board, brain, shippy);
                    }
                    return FoundDirectionCalcShot(brain, shippy);
                }
                return FoundShipCalcDirection(board, brain, shippy);
            }
            //check queue for ships waiting to be sunk
            else if(CheckShipsToFireAtNext(brain) != null)
            {
                var shipType = CheckShipsToFireAtNext(brain);
                return FoundShipCalcDirection(board, brain, ConverStringToShip(shipType.ToString()));
            }
            //random gen cord
            return MakeCoordinate();
        }

        //still have issue with hit shots dictionary when searching for direction
        //I think its on the third hit that shit gets fucked

        public static Coordinate FoundEndOfShipCalcShot(Board board, Brain brain, ShipType ship)
        {
            Coordinate initHit = brain.InitialHitOfShip[ship];
            Coordinate startingPoint = new Coordinate(initHit.XCoordinate, initHit.YCoordinate);
            if (brain.ShipOnXAxis[ship].Value)
            {
                startingPoint.XCoordinate--;
            }
            else
            {
                startingPoint.YCoordinate--;
            }
            return startingPoint;
        }

        public static void UpdateBrainOnMiss(Brain brain, FireShotResponse response, Coordinate cord)
        {
           //determine if AI was even aiming at a ship
           //if it was did it know the ship direction
           //if AI didnt know ship direction
           //if it knew the direction it must of reached the end of the ship

            //ehhh still need logic to account for if the first shot is the end of ship
           foreach(KeyValuePair<ShipType, bool> ship in brain.FiringAtShip)
            {
                //AI was aiming at ship and missed
                if (ship.Value)
                {
                    //AI knows the ship direction
                    if(brain.ShipOnXAxis[ship.Key] != null)
                    {
                        //AI found then end of the ship
                        brain.FoundEndOfShips[ship.Key] = true;
                    }
                }
            }
        }

        public static void UpdateBrainOnHitAndSunk(Brain brain, FireShotResponse response)
        {
            var shipSunk = ConverStringToShip(response.ShipImpacted);
            brain.FiringAtShip[shipSunk] = false;
            ResetSearchingForDirection(brain);
        }

    
        public static ShipType? ShipCurrentlyUnderFire(Brain brain)
        {
            var shipUnderFire = new ShipType();
            try
            {
                shipUnderFire = brain.FiringAtShip.First(x => x.Value == true).Key;
            }
            catch
            {
                return null;
            }

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
            //Need to determine if this was the first hit and if so set initHit and FiringAtShip
            //continue with first step till the same ship is hit again to determine direction and set shipOnXAxis
            //continue hitting on axis determined by step 2 until a miss or a hit of a different ship set foundEndOfShip

            ShipType shipJustHit = ConverStringToShip(response.ShipImpacted);
            brain.HitShots[shipJustHit].Add(cord);
            var shipAimingAt = ShipCurrentlyUnderFire(brain);
            //we have a ship in site
            if(shipAimingAt != null)
            {
                //make sure ship just hit is the ship that was being aimed at 
                if (shipAimingAt == shipJustHit)
                {
                    //ship hit twice able to set ship direction
                    if(brain.HitShots[shipJustHit].Count >= 2)
                    {
                        //if we know ship direction
                        if (brain.ShipOnXAxis[shipJustHit] == null)
                        {
                            //determine direction and set shipOnXAxis
                            Coordinate firstHit = brain.HitShots[shipJustHit].Last();
                            Coordinate SecondHit = brain.HitShots[shipJustHit][brain.HitShots[shipJustHit].Count - 2];
                            Coordinate lastHit = new Coordinate(firstHit.XCoordinate, firstHit.YCoordinate);
                            Coordinate secLast = new Coordinate(firstHit.XCoordinate, firstHit.YCoordinate);

                            if (lastHit.XCoordinate == secLast.XCoordinate)
                            {
                                brain.ShipOnXAxis[shipJustHit] = true;
                            }
                            else
                            {
                                brain.ShipOnXAxis[shipJustHit] = false;
                            }
                        }
                        //AI know what axis ship is on check to make sure the edge of ship isnt on edge of board and if so set found end of ship
                        else
                        {
                            //if ship on x axis
                            if (brain.ShipOnXAxis[shipJustHit].Value)
                            {
                                //if x cord it is 10
                                if (cord.XCoordinate == 10)
                                {
                                    //then that is the end of the ship
                                    brain.FoundEndOfShips[shipJustHit] = true;
                                }
                            }
                            else
                            {
                                //if y cord it is 10
                                if (cord.YCoordinate == 10)
                                {
                                    //then that is the end of the ship
                                    brain.FoundEndOfShips[shipJustHit] = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    //hit a ship that wasnt aiming at
                    brain.ShipsToFireAtNext[shipJustHit] = cord;
                    brain.InitialHitOfShip[shipJustHit] = cord;
                }
            }
            else
            {
                //first hit of ship after random number gen
                brain.InitialHitOfShip[shipJustHit] = cord;
                UpdateFiringAtShip(shipJustHit, brain);
            }
        }

        public static bool HasAIFoundEndOfShip(Brain brain, ShipType ship)
        {
            //if its the ship currently under fire
            if (brain.FiringAtShip[ship])
            {
                // AI  has hit the ship
                if (brain.InitialHitOfShip[ship] != null)
                {
                    // AI Knows the direction of the ship
                    if(brain.ShipOnXAxis[ship] != null)
                    {
                        //found end of ship
                        if (brain.FoundEndOfShips[ship])
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static void ResetSearchingForDirection(Brain brain)
        {
            brain.SearchingForDirection["Right"] = true;
            brain.SearchingForDirection["Left"] = true;
            brain.SearchingForDirection["Up"] = true;
            brain.SearchingForDirection["Down"] = true;

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
                default:
                    return ShipType.Carrier;
            }
        }

        public static Coordinate FoundDirectionCalcShot(Brain brain, ShipType ship)
        {
            //what direction is the ship going
            //start increasing on that axis
            Coordinate LastHit = brain.HitShots[ship].Last();
            Coordinate lastHIt = new Coordinate(LastHit.XCoordinate, LastHit.YCoordinate);
            //ship on xaxis
            if (brain.ShipOnXAxis[ship].Value)
            {
                lastHIt.XCoordinate++;
            }
            else
            {
                lastHIt.YCoordinate++;
            }
            return lastHIt;
        }

        public static Coordinate FoundShipCalcDirection(Board board, Brain brain, ShipType ship)
        {
            //right to last hit
            if (brain.SearchingForDirection["Right"])
            {
                Coordinate initHitRight = brain.InitialHitOfShip[ship];
                Coordinate lastHitRight = new Coordinate(initHitRight.XCoordinate, initHitRight.YCoordinate);
                
                lastHitRight.XCoordinate++;
                if ((!board.HasCordBeenFiredAt(lastHitRight)) && (board.IsValidCoordinate(lastHitRight)))
                {
                    brain.SearchingForDirection["Right"] = false;
                    return lastHitRight;
                }
                lastHitRight.XCoordinate--;
            }
            
            //left to last hit
            if (brain.SearchingForDirection["Left"])
            {
                Coordinate initHitLeft = brain.InitialHitOfShip[ship];
                Coordinate lastHitLeft = new Coordinate(initHitLeft.XCoordinate, initHitLeft.YCoordinate);

                lastHitLeft.XCoordinate--;
                if ((!board.HasCordBeenFiredAt(lastHitLeft)))
                {
                    if ((board.IsValidCoordinate(lastHitLeft)))
                    {
                        brain.SearchingForDirection["Left"] = false;
                        return lastHitLeft;
                    }
                }
                lastHitLeft.XCoordinate++;
            }

            //up to last hit
            if (brain.SearchingForDirection["Up"])
            {
                Coordinate initHitUp = brain.InitialHitOfShip[ship];
                Coordinate lastHitUp = new Coordinate(initHitUp.XCoordinate, initHitUp.YCoordinate);

                lastHitUp.YCoordinate--;
                if ((!board.HasCordBeenFiredAt(lastHitUp)) && (board.IsValidCoordinate(lastHitUp)))
                {
                    brain.SearchingForDirection["Up"] = false;
                    return lastHitUp;
                }
                lastHitUp.YCoordinate++;
            }

            //down to last hit
            Coordinate initHitDown = brain.InitialHitOfShip[ship];
            Coordinate lastHitDown = new Coordinate(initHitDown.XCoordinate, initHitDown.YCoordinate);

            brain.SearchingForDirection["Down"] = false;
            lastHitDown.YCoordinate++;
            return lastHitDown;
        }
    }
}
