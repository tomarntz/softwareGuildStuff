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
        public List<Coordinate> HitShotsIncreasing;
        public List<Coordinate> HitShotsDecreasing;
        public Coordinate InitialHitOfShip;
        public bool ShipOnX;
        public bool ShipOnY;

        public bool FoundDestroyer;
        public bool FoundSubmarine;
        public bool FoundCruiser;
        public bool FoundBattleship;
        public bool FoundCarrier;

        public bool FoundEndOfDestroyer;
        public bool FoundEndOfSubmarine;
        public bool FoundEndOfCruiser;
        public bool FoundEndOfBattleship;
        public bool FoundEndOfCarrier;

        public bool DestroyerOnXAxis;
        public bool SubmarineOnXAxis;
        public bool CruiserOnXAxis;
        public bool BattleshipOnXAxis;
        public bool CarrierOnXAxis;
        public Brain()
        {
            HitShotsIncreasing = new List<Coordinate>();
            HitShotsDecreasing = new List<Coordinate>();

        }
    }
}
