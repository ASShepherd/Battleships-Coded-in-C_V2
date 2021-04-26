using System;
using System.IO;
using System.Collections.Generic;
using BattleShips;
using System.Linq;



namespace BattleShips
{
    class Battleships
    {
        public Player Player1 { get; set; }
        public Machine Machine1 { get; set; }

        public Battleships()
        {
            //Setup player class for game initialisation
            Player1 = new Player();
            Machine1 = new Machine();

        }
        static void Main()
        {
            string selection;
            Console.WriteLine("Please choose a manual game or a auomated game by inputting M or A");
            selection = Console.ReadLine();
            if (selection == "M")
            {
                Console.WriteLine("Initialising Manual Game");
                //Initialise the game by creating a playspace, placing ships and showing the board
                Battleships Game1 = new Battleships();
                Game1.Player1.PlaceShips();
                Game1.Player1.OutPutPlaySpace();

                do //Whilst not all ships are sunk, ask player for input and calculate it on the boardstate
                {
                    Coords playerinput = Game1.Player1.InputCoords();
                    Game1.Player1.ProcessShot(playerinput);
                    Game1.Player1.OutPutPlaySpace();
                } while (Game1.Player1.HasWon == false);
                //If player has sunk all the ships, print the message and wait for user input
                Console.WriteLine("You sunk all the battleships, you won the game!");
                Console.ReadKey();
            }
            else if (selection == "A")
            {
                int shotcount = 0;
                Console.WriteLine("Initialising Automated Game");
                //Initialise the game by creating a playspace, placing ships and showing the board
                Battleships Game1 = new Battleships();
                Game1.Machine1.PlaceShips();
                Game1.Machine1.OutPutPlaySpace();

                do //Whilst not all ships are sunk, ask player for input and calculate it on the boardstate
                {
                    Coords randomgen = Game1.Machine1.RandCoords();
                    shotcount++;
                    Game1.Machine1.ProcessShot(randomgen);
                    //Game1.Machine1.OutPutPlaySpace();
                } 
                while (Game1.Machine1.HasWon == false);
                Game1.Machine1.OutPutPlaySpace();
                //If player has sunk all the ships, print the message and wait for user input
                Console.WriteLine("The automated game finished after: " + shotcount + " shots");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("An invalid selection was made, please retry.");
                Main();
            }
        }

    }

    
}
