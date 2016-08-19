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
        public void Start()
        {
            string a = ("Battleship");
           
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.ReadKey();
            Console.Clear();
        }

        public void PlaceShip(Board board, string playerName)
        {
            ConsoleIO.Displaysetupboard(board);
            foreach (ShipType shiptype in Enum.GetValues(typeof(ShipType)))
            {
                bool isvalidPlacement = false;

                while (!isvalidPlacement)
                {
                    var request = new PlaceShipRequest();
                    request.Coordinate = ConsoleIO.PromptCoordinate($"{playerName} enter a coordinate to place your {shiptype}");
                    request.Direction = ConsoleIO.PromptDirection("");
                    request.ShipType = shiptype;
                    ShipPlacement responce = board.PlaceShip(request);
                    switch (responce)
                    {
                        case ShipPlacement.NotEnoughSpace:
                            ConsoleIO.Display("Not enough space");
                            Console.Clear();
                            break;
                        case ShipPlacement.Overlap:
                            ConsoleIO.Display("Overlap");
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
            int xcord = 0;
            int ycord = 0;
            ConsoleIO.BoardShotHistory(board);

            while (!isvalid)
            {
                Coordinate coordinate = ConsoleIO.PromptCoordinate( $"{playerName} Enter coordinate to fire shot");
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
            Console.ReadLine();
            return response;
        }
    }
}
