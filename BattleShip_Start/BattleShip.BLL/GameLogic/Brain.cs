using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.BLL.GameLogic
{
    public class Brain
    {
        public List<Coordinate> HitShots;
        public Coordinate InitialHitOfShip;
        public bool FoundShip;
        public bool FoundShipDirection;
        public bool FoundEndOfShip;
    }
}
