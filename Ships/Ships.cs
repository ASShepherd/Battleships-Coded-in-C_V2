
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips;

namespace BattleShips.Ships
{
    public abstract class Ships
    {
            public string Name { get; set; }
            public int Width { get; set; }
            public int Hits { get; set; }
            public EnumShipType ShipType { get; set; }
            public bool IsSunk
            {
                get
                {
                    return Hits >= Width;
                }
            }
    }
    public class Destroyer : Ships
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Width = "4";
            ShipTypes = ShipType.Destroyer;
        }

    }

    public class Battleship : Ships
    {
        public Battleship()
        {
            Name = "Battleship";
            Width = "5";
            ShipTypes = ShipType.Battleship;
        }

    }
}