using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool userinput = false;

            do
            {
                GameWorkFlow a = new GameWorkFlow();
                a.Start();

                List<Player> Players = new List<Player>();
                Player Player1 = new Player();
                Player Player2 = new Player();

                Player1.Name = ConsoleIO.PromptString("Player 1 enter name", true);
                Player2.Name = ConsoleIO.PromptString("Player 2 enter name", true);

                Players.Add(Player1);
                Players.Add(Player2);

                foreach (var p in Players)
                {
                    a.PlaceShip(p.Board, p.Name);
                    Console.Clear();
                }
                TakeTurnsFiring(Players);
                userinput = ConsoleIO.PlayAgain();
            } while (userinput);
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

