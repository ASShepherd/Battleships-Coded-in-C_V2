using System;
using System.IO;
using System.Collections.Generic;
using BattleShips;


namespace BattleShips
{
    public class Coords
    {

        //Setup values for coords to be used in other classes
        public int Row { get; set; }
        public int Column { get; set; }

        public Coords (int row, int column)
        {
            Row = row;
            Column = column;
        }
    }

}
