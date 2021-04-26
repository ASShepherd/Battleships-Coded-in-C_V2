using System;
using System.Collections.Generic;
using System.ComponentModel;
using BattleShips;

namespace BattleShips
{

    //Setup enums for the differing ship types and hit of miss values
    public enum EnumShipType
    {
        [Description("-")]
        Empty,

        [Description("B")]
        Battleship,

        [Description("D")]
        Destroyer,

        [Description("D")]
        Destroyer2,

        [Description("X")]
        Hit,

        [Description("M")]
        Miss
    }

    public enum EnumShotResult
    {
        Miss,
        Hit
    }
}