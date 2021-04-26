using BattleShips;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public class PlaySpace
    {
        //Sets up a 10x10 list of the class "Block" to create the playing field for use in the game
        public List<Block> Blocks { get; set; }

        public PlaySpace()
        {
            Blocks = new List<Block>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Blocks.Add(new Block(i, j));
                }
            }
        }
    }
}
