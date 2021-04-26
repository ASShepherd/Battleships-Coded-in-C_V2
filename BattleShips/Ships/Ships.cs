
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips;

namespace BattleShips
{
    public abstract class Ships
    {
        //Uses an abstract class as a base for all the different ship types
        //Contains all ship info and a simple logic check used to check if game has ended
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
    public class Destroyer1 : Ships
    {
        public Destroyer1()
        {
            Name = "Destroyer1";
            Width = 4;
            ShipType = EnumShipType.Destroyer;
        }
    }
    public class Destroyer2 : Ships
    {
        public Destroyer2()
        {
            Name = "Destroyer2";
            Width = 4;
            ShipType = EnumShipType.Destroyer2;
        }
    }

    public class Battleship : Ships
    {
        public Battleship()
        {
            Name = "Battleship";
            Width = 5;
            ShipType = EnumShipType.Battleship;
        }

    }
}