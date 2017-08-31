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
    public class GameWorkFlow
    {
        static Brain brain = new Brain();
        // ArtificialIntelligence AI = new ArtificialIntelligence();
        public void Start()
        {
            string a = ("Battleship");
           
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ReadKey();
            Console.Clear();
        }

        public void SelectMode()
        {
            Console.WriteLine("Would you like to play against a friend or the AI?");
            Console.WriteLine("1 for friend 2 for AI");
            var mode = Console.ReadLine();

            if (mode == "2")
            {
                Console.WriteLine("AI it is!");
                Console.ReadLine();
                Console.Clear();
                ArtificialIntelligence.SelectDifficulty();
            }
            else
            {
                PlayWithFriend();
            }
        }

        public void PlayWithFriend()
        {
            List<Player> Players = new List<Player>();
            Player Player1 = new Player();
            Player Player2 = new Player();

            Player1.Name = ConsoleIO.PromptString("Player 1 enter name", true);
            Console.Clear();
            Player2.Name = ConsoleIO.PromptString("Player 2 enter name", true);
            Console.Clear();
            Players.Add(Player1);
            Players.Add(Player2);

            foreach (var p in Players)
            {
                PlaceShip(p.Board, p.Name);
                Console.Clear();

            }
            TakeTurnsFiring(Players);
            //userinput = ConsoleIO.PlayAgain();
        }

        public static void PlaceShip(Board board, string playerName)
        {
            foreach (ShipType shiptype in Enum.GetValues(typeof(ShipType)))
            {
                bool isvalidPlacement = false;

                while (!isvalidPlacement)
                {
                    var request = new PlaceShipRequest();
                    ConsoleIO.Displaysetupboard(board);
                    request.Coordinate = ConsoleIO.PromptCoordinate($"{playerName} enter a coordinate to place your {shiptype}");
                    
                    if(request.Coordinate.XCoordinate == 69 || request.Coordinate.XCoordinate == 69)
                    {
                        ArtificialIntelligence.PlaceShips(board, playerName);
                    }

                    Console.Clear();

                    ConsoleIO.Displaysetupboard(board);
                    request.Direction = ConsoleIO.PromptDirection("");
                    Console.Clear();

                    request.ShipType = shiptype;
                    ShipPlacement responce = board.PlaceShip(request);
                    switch (responce)
                    {
                        case ShipPlacement.NotEnoughSpace:
                            ConsoleIO.Displaysetupboard(board);
                            ConsoleIO.Display("Not enough space hit enter to retry");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case ShipPlacement.Overlap:
                            ConsoleIO.Displaysetupboard(board);
                            ConsoleIO.Display("Overlap hit enter to retry");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case ShipPlacement.Ok:
                            isvalidPlacement = true;
                            break;
                        default:
                            Console.WriteLine("What have you done");
                            break;
                    }
                }
                ConsoleIO.Displaysetupboard(board);
            }
        }

        public static FireShotResponse FireShot(Board board, string playerName)
        {
            bool isvalid = false;
            FireShotResponse response = null;
            ConsoleIO.BoardShotHistory(board);
            
            if(playerName == "computer")
            {
                while (!isvalid)
                {
                    Coordinate cord = ArtificialIntelligence.CalcShot(board, brain);
                    response = board.FireShot(cord);
                    if(response.ShotStatus == ShotStatus.Hit && brain.FoundShip == false)
                    {
                        brain.InitialHitOfShip = cord;
                    }
                    switch (response.ShotStatus)
                    {
                        case ShotStatus.Miss:
                            if(brain.FoundShipDirection == true)
                            {
                                brain.FoundEndOfShip = true;
                            }
                            ConsoleIO.DisplayAIBoardShotHistory(board);
                            ConsoleIO.Display($"The AI fired and missed your ships");
                            isvalid = true;
                            break;
                        case ShotStatus.Hit:
                            if (brain.FoundEndOfShip == true)
                            {
                                brain.HitShotsDecreasing.Add(cord);
                            }
                            else
                            {
                                brain.HitShotsIncreasing.Add(cord);
                            }
                            if (brain.FoundShip == true)
                            {
                                brain.FoundShipDirection = true;
                            }
                            brain.FoundShip = true;
                            ConsoleIO.DisplayAIBoardShotHistory(board);
                            ConsoleIO.Display($"The AI hit your {response.ShipImpacted}");
                            isvalid = true;
                            break;
                        case ShotStatus.HitAndSunk:
                            ConsoleIO.DisplayAIBoardShotHistory(board);
                            brain.HitShotsIncreasing.Add(cord);
                            brain.FoundShip = false;
                            brain.FoundShipDirection = false;
                            brain.InitialHitOfShip = null;
                            brain.FoundEndOfShip = false;
                            ConsoleIO.Display($"The AI hit and sunk your {response.ShipImpacted}");
                            isvalid = true;
                            break;
                        case ShotStatus.Victory:
                            ConsoleIO.DisplayAIBoardShotHistory(board);
                            ConsoleIO.Display($"The AI sunk your last ship you are the loser");
                            isvalid = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                while (!isvalid)
                {
                    Coordinate coordinate = ConsoleIO.PromptCoordinate($"{playerName} Enter coordinate to fire shot");
                    response = board.FireShot(coordinate);
                    switch (response.ShotStatus)
                    {
                        case ShotStatus.Invalid:
                            Console.Clear();
                            ConsoleIO.BoardShotHistory(board);
                            ConsoleIO.Display("Invalid");
                            break;
                        case ShotStatus.Duplicate:
                            Console.Clear();
                            ConsoleIO.BoardShotHistory(board);
                            ConsoleIO.Display("Already shot there");
                            break;
                        case ShotStatus.Miss:
                            Console.Clear();
                            ConsoleIO.BoardShotHistory(board);
                            ConsoleIO.Display("Miss");
                            ConsoleIO.Display("select enter to continue");
                            isvalid = true;
                            break;
                        case ShotStatus.Hit:
                            Console.Clear();
                            ConsoleIO.BoardShotHistory(board);
                            ConsoleIO.Display("Hit");
                            ConsoleIO.Display("select enter to continue");
                            isvalid = true;
                            break;
                        case ShotStatus.HitAndSunk:
                            Console.Clear();
                            ConsoleIO.BoardShotHistory(board);
                            ConsoleIO.Display("Hit and sunk");
                            ConsoleIO.Display("select enter to continue");
                            isvalid = true;
                            break;
                        case ShotStatus.Victory:
                            Console.Clear();
                            ConsoleIO.BoardShotHistory(board);
                            ConsoleIO.Display($"{playerName} is the winner!");
                            ConsoleIO.Display("select enter to continue");
                            isvalid = true;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            Console.ReadLine();
            return response;
        }

        public static void TakeTurnsFiring(List<Player> Players)
        {
            FireShotResponse rs = new FireShotResponse();
            while (rs.ShotStatus != ShotStatus.Victory)
            {
                for (int i = 1; i < 3; i++)
                {
                    Player current = Players[i - 1];
                    Player opponite = Players[i % 2];
                    Console.Clear();
                    rs = GameWorkFlow.FireShot(opponite.Board, current.Name);

                    if (rs.ShotStatus == ShotStatus.Victory)
                    {
                        break;
                    }
                }
            }
        }
    }
}
