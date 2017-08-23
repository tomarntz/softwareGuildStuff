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
    public class ConsoleIO
    {
        public static void Display(string message)
        {
            Console.WriteLine(message);
        }

        public static void Displaysetupboard(Board board)
        {
            Console.Clear();
            Console.Write("{0,3}", " ");
            for (char letter = 'A'; letter < 'K'; letter++)
            {
                Console.Write("{0, -4}", letter);
            }
            Console.WriteLine("");
            for (int i = 1; i < 11; i++)
            {
                Console.Write("{0, -3}", i);
                for (int j = 1; j < 11; j++)
                {
                    string a = "-";
                    var result = from s in board.GetShips()
                                 where s != null && s.BoardPositions.Any(b => b.XCoordinate == j && b.YCoordinate == i)
                                 select s;
                    if (result.Count() > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        a = "S";
                    }
                    Console.Write("{0,-4}", a);
                    Console.ResetColor();
                }
                Console.WriteLine("");
            }
            Console.WriteLine();
        }

        public static void DisplayAIBoardShotHistory(Board board)
        {
            Console.Clear();
            Console.Write("{0,3}", " ");
            for (char letter = 'A'; letter < 'K'; letter++)
            {
                Console.Write("{0,-4}", letter);
            }
            Console.WriteLine("");
            for (int i = 1; i < 11; i++)
            {
                Console.Write("{0,-3}", i);
                for (int j = 1; j < 11; j++)
                {
                    string a = "-";
                    var resultShips = from s in board.GetShips()
                                      where s != null && s.BoardPositions.Any(b => b.XCoordinate == j && b.YCoordinate == i)
                                      select s;
                    if (resultShips.Count() > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        a = "S";
                    }
                    if (board.ShotHistory.ContainsKey(new Coordinate(j, i)))
                    {
                        ShotHistory result = board.ShotHistory[new Coordinate(j, i)];
                        switch (result)
                        {
                            case ShotHistory.Hit:
                                Console.ForegroundColor = ConsoleColor.Red;
                                a = "H";
                                break;
                            case ShotHistory.Miss:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                a = "M";
                                break;
                            case ShotHistory.Unknown:
                                break;
                            default:
                                break;
                        }
                    }
                    Console.Write("{0,-4}", a);
                    Console.ResetColor();
                }
                Console.WriteLine("");
            }
            Console.WriteLine();
        }

        public static void BoardShotHistory(Board board)
        {
            Console.Clear();
            Console.Write("{0,3}", " ");
            for (char letter = 'A'; letter < 'K'; letter++)
            {
                Console.Write("{0,-4}", letter);
            }
            Console.WriteLine("");
            for (int i = 1; i < 11; i++)
            {
                Console.Write("{0,-3}", i);
                for (int j = 1; j < 11; j++)
                {
                    string a = "-";
                    if (board.ShotHistory.ContainsKey(new Coordinate(j, i)))
                    {
                        ShotHistory result = board.ShotHistory[new Coordinate(j, i)];
                        switch (result)
                        {
                            case ShotHistory.Hit:
                                Console.ForegroundColor = ConsoleColor.Red;
                                a = "H";
                                break;
                            case ShotHistory.Miss:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                a = "M";
                                break;
                            case ShotHistory.Unknown:
                                break;
                            default:
                                break;
                        }
                    }
                    Console.Write("{0,-4}", a);
                    Console.ResetColor();
                }
                Console.WriteLine("");
            }
            Console.WriteLine();
        }

        public static string PromptString(string message, bool isRequired)
        {
            string result = "";
            if (isRequired)
            {
                do
                {
                    Display(message);
                    result = Console.ReadLine();
                    if (result == "")
                    {
                        Display("Input is required");
                        Console.ReadLine();
                        Console.Clear();
                    }
                } while (result == "");
            }
            else
            {
                Display(message);
                result = Console.ReadLine();
            }
            return result;
        }
        //place a delay after user does turn to make it seem like the AI is thinking and actually playing rather than just 
        public static Coordinate PromptCoordinate(string message)
        {
            bool isvalid = false;
            int xcord = 0;
            int ycord = 0;
            while (!isvalid)
            {
                Console.WriteLine(message);
                string userinput = Console.ReadLine();
                if (userinput == "")
                {
                    isvalid = false;
                    continue;
                }
                string letter = userinput.Substring(0, 1).ToUpper();
               
                string number = userinput.Substring(1);
                Int32.TryParse(number, out ycord);
                xcord = Convert.ToInt16(letter.ToUpper()[0]) - 64;
               
                isvalid = ((xcord >= 1 && xcord <= 10) && (ycord >= 1 && ycord <= 10) || ycord == 69 || xcord ==69);
                if (!isvalid)
                {
                    Display("Invalid");

                }
            }
            Coordinate coord = new Coordinate(xcord, ycord);
            return coord;
        }

        public static ShipDirection PromptDirection(string message)
        {
            bool isvald = false;
            ShipDirection result = ShipDirection.Up;
            while (!isvald)
            {
                Console.WriteLine();
                string direction = PromptOptions("Please enter a direction 1 = up, 2 = down, 3 = left, 4 = right", new []{"1","2","3","4"});
                Console.Clear();
                int dir = 0;
                if (Int32.TryParse(direction, out dir) && dir >= 1 && dir <= 4)
                {
                    isvald = true;
                    result = (ShipDirection) (dir -1);
                }
                else
                {
                    Display("Invalid entry");
                }
            }
            Console.Clear();
            return result;
        }

        public static string PromptOptions(string message, string[] options)
        {
            string result = "";
            do
            {
                result = PromptString(message, true);
                if (result == "" && !options.Contains(result))
                {
                    Display("Invalid Option");
                }
            } while (result == "" && !options.Contains(result));
            return result;
        }

        public static bool PlayAgain()
        {
            bool isValid = false;
            Console.WriteLine("Would you like to play again? (Y)es or hit enter to exit");
            string playAgain = Console.ReadLine();
            if (playAgain != null)
            {
                if (playAgain.ToUpper() == "Y")  
                {
                    isValid = true;
                    Console.Clear();
                }
            }
            return isValid;
        } 
    }
}
