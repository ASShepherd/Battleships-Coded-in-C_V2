using BattleShips;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    /// The basic class that is a single square on the 10x10 playing board
    public class Block
    {
        public EnumShipType ShipType { get; set; }
        public Coords Coordinates { get; set; }

        public Block(int row, int column)
        {
            Coordinates = new Coords(row, column);
            ShipType = EnumShipType.Empty;
        }

        public string Status
        {
            get
            {
                //Simply returns the enumShiptype's description
                return ShipType.GetAttributeOfType<DescriptionAttribute>().Description;
            }
        }

        public bool IsOccupied
        {
            get
            {
                //Is used to check if a ship is located in a block for hit or miss detection
                return ShipType == EnumShipType.Battleship
                    || ShipType == EnumShipType.Destroyer
                    || ShipType == EnumShipType.Destroyer2;

            }
        }

    }
}
