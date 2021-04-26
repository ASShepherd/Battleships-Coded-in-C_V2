
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShips;

namespace BattleShips
{
    public class Machine
    {
        public string Name { get; set; }
        public PlaySpace PlayBoard { get; set; }
        public List<Ships> Ships { get; set; }
        public bool HasWon
        {
            get
            {
                return Ships.All(x => x.IsSunk);
            }
        }

        public Machine()
        {
            Ships = new List<Ships>()
        {
            //Creates a list containing all the ships to be used
            new Destroyer1(),
            new Destroyer2(),
            new Battleship(),
        };
            PlayBoard = new PlaySpace();
        }

        public void PlaceShips()
        {
            Random rand = new Random();
            foreach (var ship in Ships)
            {

                //For each ship in the list that was created, check all the positions are legal blocks, and if they are, place the ship and move on
                bool isPlaced = false;
                while (isPlaced == false)
                {
                    int startcolumn = rand.Next(1, 11);
                    int startrow = rand.Next(1, 11);
                    int endrow = startrow;
                    int endcolumn = startcolumn;
                    int direction = rand.Next(2); //use 0 for vertical placement, use 1 for horizontal placement

                    List<int> BlockCoords = new List<int>();

                    if (direction == 0)
                    {
                        for (int i=1; i<ship.Width; i++)
                        {
                            endcolumn++;
                        }
                    }

                    else
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endrow++;
                        }
                    }
                    if (endrow >10 || endcolumn > 10)
                    {
                        isPlaced = false;
                        continue;
                    }

                    List<Block> UsedBlocks = PlayBoard.Blocks.Where(x => x.Coordinates.Row >= startrow && x.Coordinates.Column >= startcolumn && x.Coordinates.Row <= endrow && x.Coordinates.Column <= endcolumn).ToList();
                    if (UsedBlocks.Any(x => x.IsOccupied))
                    {
                        isPlaced = false;
                        continue;
                    }
                    foreach (var block in UsedBlocks)
                    {
                        block.ShipType = ship.ShipType;
                    }
                    isPlaced = true;
                }
            }
        }

        public void OutPutPlaySpace()
        {
            //Prints out the current boardstate, hits misses and ships included
            for (int row =1;row <= 10; row++)
            {
                for (int Column = 1; Column <= 10; Column++)
                {
                    Console.Write(PlayBoard.Blocks.Where(x => x.Coordinates.Row == row && x.Coordinates.Column == Column).First().Status + " ");
                }
                Console.WriteLine();
            }
        }
        public Coords RandCoords()
        {
            Random randgen = new Random();
            int row , column;
            row = randgen.Next(1, 11);
            column = randgen.Next(1, 11);
            Coords ShotLocation = new Coords(row, column);
            var block = PlayBoard.Blocks.Where(x => x.Coordinates.Row == row && x.Coordinates.Column == column).First();
            if (block.ShipType == EnumShipType.Miss || block.ShipType == EnumShipType.Hit) 
            {
                Console.WriteLine("Duplicate coordinate, skipping");
                RandCoords();
            }
            //Console.WriteLine(ShotLocation.Column + " " + ShotLocation.Row);   //Testing 
            return ShotLocation;

        }


        public EnumShotResult ProcessShot(Coords fireLocation)
        {
            try
            {
                //Call the block the player specificed via coordinates
                var block = PlayBoard.Blocks.Where(x => x.Coordinates.Row == fireLocation.Row && x.Coordinates.Column == fireLocation.Column).First();

                if (!block.IsOccupied)
                {
                    //if the block had no ship in it, return a miss message, and change enum to miss
                    Console.WriteLine("Your shot did not hit any battleships.");
                    block.ShipType = EnumShipType.Miss;
                    return EnumShotResult.Miss;
                }
                //if the block had a ship in it, return a hit message, and change enum to hit
                //increment the hit value to track how many times a ship has been hit
                var ship = Ships.First(Z => Z.ShipType == block.ShipType);
                ship.Hits++;
                Console.WriteLine("Hit: " + ship.ShipType.ToString() + "!");
                if (ship.IsSunk)
                {
                    Console.WriteLine("Your shot sunk a " + ship.ShipType.ToString());
                }
                block.ShipType = EnumShipType.Hit;
                return EnumShotResult.Hit;
            }
            catch (Exception ex)
            {
                Console.WriteLine("The selected coordinate was not found in the array");
                return EnumShotResult.Miss;
                
            }
        }
    }
}
