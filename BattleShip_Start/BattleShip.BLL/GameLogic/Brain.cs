﻿using System;
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
        public Dictionary<ShipType, Coordinate> InitialHitOfShip;

        public Dictionary<ShipType,bool> FoundEndOfShips;

        public Dictionary<ShipType, bool> FiringAtShip;

        public Dictionary<ShipType, bool?> ShipOnXAxis;

        public Dictionary<ShipType, List<Coordinate>> HitShots;

        public Dictionary<ShipType, Coordinate> ShipsToFireAtNext;


        public Brain()
        {

            InitialHitOfShip = new Dictionary<ShipType, Coordinate>();
            InitialHitOfShip.Add(ShipType.Battleship, null);
            InitialHitOfShip.Add(ShipType.Carrier, null);
            InitialHitOfShip.Add(ShipType.Cruiser, null);
            InitialHitOfShip.Add(ShipType.Destroyer, null);
            InitialHitOfShip.Add(ShipType.Submarine, null);

            FoundEndOfShips = new Dictionary<ShipType, bool>();
            FoundEndOfShips.Add(ShipType.Battleship, false);
            FoundEndOfShips.Add(ShipType.Carrier, false);
            FoundEndOfShips.Add(ShipType.Cruiser, false);
            FoundEndOfShips.Add(ShipType.Destroyer, false);
            FoundEndOfShips.Add(ShipType.Submarine, false);

            FiringAtShip = new Dictionary<ShipType, bool>();
            FiringAtShip.Add(ShipType.Battleship, false);
            FiringAtShip.Add(ShipType.Carrier, false);
            FiringAtShip.Add(ShipType.Cruiser, false);
            FiringAtShip.Add(ShipType.Destroyer, false);
            FiringAtShip.Add(ShipType.Submarine, false);


            ShipOnXAxis = new Dictionary<ShipType, bool?>();
            ShipOnXAxis.Add(ShipType.Battleship, null);
            ShipOnXAxis.Add(ShipType.Carrier, null);
            ShipOnXAxis.Add(ShipType.Cruiser, null);
            ShipOnXAxis.Add(ShipType.Destroyer, null);
            ShipOnXAxis.Add(ShipType.Submarine, null);

            HitShots = new Dictionary<ShipType, List<Coordinate>>();
            HitShots.Add(ShipType.Battleship, null);
            HitShots.Add(ShipType.Carrier, null);
            HitShots.Add(ShipType.Cruiser, null);
            HitShots.Add(ShipType.Destroyer, null);
            HitShots.Add(ShipType.Submarine, null);

            ShipsToFireAtNext = new Dictionary<ShipType, Coordinate>();
        }
    }
}
